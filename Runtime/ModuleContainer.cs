using System;
using System.Collections.Generic;
using UnityEngine;

namespace BCF.MSA
{
    public class ModuleContainer : MonoBehaviour
    {
        [SerializeField] private bool persistentSingleton = true;
        [SerializeField] private List<BaseModule> modules = new();
        
        private Dictionary<Type, BaseModule> _indexedModules = new();
        private static bool _initialized = false;

        private static event Action OnInitialized;
        public static ModuleContainer Instance { get; private set; }

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                if (persistentSingleton)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogError($"More than one instance of {nameof(ModuleContainer)}!");
                Destroy(gameObject);
            }
            
            InitializeModule();
        }

        private void InitializeModule()
        {
            foreach (var module in modules)
            {
                if (_indexedModules.TryAdd(module.GetType(), module))
                {
                    module.transform.SetParent(transform); // if set to persistent, stay together.
                    module.Initialize();
                }
            }
            
            _initialized = true;
            OnInitialized?.Invoke();
        }

        /// <summary>
        /// Retrieves a registered module of the specified type.
        /// Returns null if the module is not found.
        /// </summary>
        public T GetModule<T>() where T : BaseModule
        {
            if (_indexedModules.TryGetValue(typeof(T), out var value))
                return (T)value;
            return null;
        }

        /// <summary>
        /// Registers a callback to be invoked once all modules have been initialized.
        /// If modules are already initialized, the callback is invoked immediately.
        /// </summary>
        public static void RegisterInitializeCallback(Action callback)
        {
            OnInitialized += callback;
            if (_initialized)
                OnInitialized?.Invoke();
        }

        /// <summary>
        /// Unregisters a previously registered initialization callback.
        /// </summary>
        public static void UnregisterInitializeCallback(Action callback)
        {
            OnInitialized -= callback;
        }
    }
}