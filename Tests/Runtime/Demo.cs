using UnityEngine;

namespace BCF.Core.ModularSingleton.Samples
{
    public class Demo : MonoBehaviour
    {
        [SerializeField] private string audioProfileName = "Demo";
        [SerializeField] private int targetRefreshRate = 60;
        
        private void OnEnable()
        {
            DemoContainer.RegisterInitializeCallback(CallModules);
        }

        private void OnDisable()
        {
            DemoContainer.UnregisterInitializeCallback(CallModules);
        }

        private void CallModules()
        {
            var audioModule = DemoContainer.Instance.GetModule<AudioModule>();
            if (audioModule)
                audioModule.PlayProfile(audioProfileName);
            var displayModule = DemoContainer.Instance.GetModule<DisplayModule>();
            if (displayModule)
                displayModule.SetRefreshRate(targetRefreshRate);
        }
    }
}
