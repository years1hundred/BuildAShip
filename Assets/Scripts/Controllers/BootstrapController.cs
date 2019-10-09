using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace LD45Jam
{
    public class BootstrapController : GameBehaviour
    {
        public enum BootScene
        {
            MainMenuScene,
            GameScene,
            AJScene,
            SimonScene,
            Will,
            MikeScene
        }

        public BootScene bootScene = BootScene.MainMenuScene;

        public bool fastLoad = false;

        private void Awake()
        {
            DOTween.Init();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            GC.Scene.GoTo(bootScene.ToString(), fastLoad);
        }
    }
}
