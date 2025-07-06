using System;
using System.Collections.Generic;
using UnityEngine;

namespace BCF.Core.ModularSingleton.Samples
{
    public class AudioModule : BaseModule
    {
        [Serializable]
        public struct AudioProfile
        {
            public string Label;
            public AudioClip Clip;
        }
        
        [SerializeField] private AudioSource source;
        [SerializeField] private List<AudioProfile> profiles = new();

        public override void Initialize()
        {
            base.Initialize();
#if UNITY_EDITOR
            Debug.Log($"[{nameof(AudioModule)}] Initializing...");
#endif
        }
        
        public void PlayProfile(string label)
        {
#if UNITY_EDITOR
            Debug.Log($"Playing audio profile: {label}...");
#endif
            var profile = profiles.Find(x => x.Label == label);
            PlayProfile(profile);
        }

        public void PlayProfile(AudioProfile? profile)
        {
            if (profile == null)
                return;
            source.clip = profile.Value.Clip;
            source.Play();
        }
    }
}
