using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD45Jam
{
    public class MainMenuController : GameBehaviour
    {
        private PlayerInputActions _input;

        [Header("Main Menu Options")]
        private int _index;
        private int _count;

#pragma warning disable CS0649

        [SerializeField]
        private MenuOption[] _options;
#pragma warning restore CS0649
        private MenuOption _currentOption;

        [Header("Tween Options")]
        [SerializeField]
        [Range(0f, 1f)]
        private float _fadeTo = 0.7f;

        [SerializeField]
        [Range(0f, 3f)]
        private float _duration = 0.5f;

        [SerializeField]
        private Ease _easeType = Ease.InOutQuad;

        private void Awake()
        {
            _input = GC.Input;

            // Set up option count
            _index = 0;
            _count = _options.Length;
            _currentOption = _options[_index];

            // Create tweens
            foreach (MenuOption option in _options)
            {
                option.CreateTween(_fadeTo, _duration, _easeType);
            }
        }

        private void Start()
        {
            _currentOption.PlayTween();
        }

        private void Update()
        {
            if (_input.Move.Up.WasPressed)
            {
                ChangeOption(-1);
            }
            else if (_input.Move.Down.WasPressed)
            {
                ChangeOption(1);
            }

            if (_input.Start.WasPressed)
            {
                if (_currentOption.sceneName.Length > 0)
                {
                    SceneManager.LoadSceneAsync(_currentOption.sceneName);
                }
                else
                {
                    Debug.Log("Scene Name field is empty...");
                }
            }
        }

        private void ChangeOption(int i)
        {
            _currentOption.StopTween();
            _index = (int)Mathf.Repeat(_index + i, _count);
            _currentOption = _options[_index];
            _currentOption.PlayTween();
        }
    }
}
