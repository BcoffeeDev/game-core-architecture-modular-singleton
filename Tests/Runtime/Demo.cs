using UnityEngine;

namespace BCF.MSA.Samples
{
    public class Demo : MonoBehaviour
    {
        private void OnEnable()
        {
            ModuleContainer.RegisterInitializeCallback(CallModules);
        }

        private void OnDisable()
        {
            ModuleContainer.UnregisterInitializeCallback(CallModules);
        }

        private void CallModules()
        {
            var audioModule = ModuleContainer.Instance.GetModule<AudioModule>();
            if (audioModule) audioModule.PlayProfile("Demo");
            var displayModule = ModuleContainer.Instance.GetModule<DisplayModule>();
            if (displayModule) displayModule.SetRefreshRate(60);
        }
    }
}
