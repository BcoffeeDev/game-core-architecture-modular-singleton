using UnityEngine;

namespace BCF.Core.ModularSingleton.Samples
{
    public class DisplayModule : BaseModule
    {
        public override void Initialize()
        {
            base.Initialize();
#if UNITY_EDITOR
            Debug.Log($"[{nameof(DisplayModule)}] Initializing...");
#endif
        }

        public void SetRefreshRate(int fps)
        {
#if UNITY_EDITOR
            Debug.Log($"Setting refresh rate to: {fps} fps.");
#endif
            Application.targetFrameRate = fps;
        }
    }
}
