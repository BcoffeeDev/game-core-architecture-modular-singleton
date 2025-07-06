using System;
using System.Collections.Generic;
using UnityEngine;

namespace BCF.Core.ModularSingleton
{
    public class BaseContainer<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected bool persistentSingleton = true;
        [SerializeField] protected List<BaseModule> modules = new();
        
        protected Dictionary<Type, BaseModule> _indexedModules = new();
        private static readonly Dictionary<Type, bool> _containerInitMap = new();
        private static readonly Dictionary<Type, Action> _onInitializedCallbackMap = new();

        protected static bool IsInitialized => _containerInitMap.TryGetValue(typeof(T), out var val) && val;

        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (!Instance)
            {
                Instance = this as T;
                if (persistentSingleton)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogError($"More than one instance of {typeof(T)}!");
#endif
                Destroy(gameObject);
            }
            
            InitializeModule();
        }

        protected virtual void InitializeModule()
        {
            foreach (var module in modules)
            {
                if (_indexedModules.TryAdd(module.GetType(), module))
                {
                    module.transform.SetParent(transform); // if set to persistent, stay together.
                    module.Initialize();
                }
            }
            
            _containerInitMap[typeof(T)] = true;
            if (_onInitializedCallbackMap.TryGetValue(typeof(T), out var callback))
                callback?.Invoke();
        }

        public M GetModule<M>() where M : BaseModule
        {
            if (_indexedModules.TryGetValue(typeof(M), out var value))
                return (M)value;
            return null;
        }
        
        /// <summary>
        /// Registers a callback to be invoked once all modules have been initialized.
        /// If modules are already initialized, the callback is invoked immediately.
        /// </summary>
        public static void RegisterInitializeCallback(Action callback)
        {
            if (_onInitializedCallbackMap.TryGetValue(typeof(T), out var existing))
                _onInitializedCallbackMap[typeof(T)] = existing + callback;
            else
                _onInitializedCallbackMap[typeof(T)] = callback;

            if (IsInitialized)
                callback?.Invoke();
        }

        /// <summary>
        /// Unregisters a previously registered initialization callback.
        /// </summary>
        public static void UnregisterInitializeCallback(Action callback)
        {
            if (_onInitializedCallbackMap.TryGetValue(typeof(T), out var existing))
            {
                existing -= callback;
                if (existing == null)
                    _onInitializedCallbackMap.Remove(typeof(T));
                else
                    _onInitializedCallbackMap[typeof(T)] = existing;
            }
        }
    }
}