using UnityEngine;

namespace LD45Jam
{
    [RequireComponent(typeof(SceneHelper))]
    public class GameController : UnityPersistentSingleton<GameController>
    {
        public SceneHelper Scene { get; private set; }
        public PlayerInputActions Input { get; private set; }

        private Transform _playerTransform;
        public Transform PlayerTransform
        {
            get
            {
                if (_playerTransform == null)
                {
                    _playerTransform = GameObject.FindWithTag("Player").transform;
                }

                return _playerTransform;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            Scene = GetComponent<SceneHelper>();
            Input = new PlayerInputActions();
        }

        private void OnDestroy()
        {
            Input.Destroy();
        }


        public static class Settings
        {
            public static bool Sound
            {
                get => bool.Parse(PlayerPrefs.GetString("sound", "true"));
                set => PlayerPrefs.SetString("sound", value.ToString());
            }
        }
    }
}
