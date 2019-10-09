using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LD45Jam
{
    public class LoadingIcon : MonoBehaviour
    {
        [Header("Loading Fade")]
        [SerializeField]
        [Range(0.1f, 2)]
        private float _fadeDuration = 0.5f;

        [SerializeField]
        private Ease _ease = Ease.OutCubic;

        [Header("Loading Icon Rotation")]
        [SerializeField]
        [Range(-16f, 16f)]
        private float _rotateSpeed = -8f;

        // [SerializeField]
        // private TextMeshProUGUI _text;

        private MaskableGraphic _icon;
        private Transform _transform;
        private Tween _fadeIn, _fadeOut;
        private bool _isLoading = false;

        public bool Enabled {
            get { return _icon.enabled; }
            set { _icon.enabled = value; }
        }

        private void Awake()
        {
            _icon = GetComponent<MaskableGraphic>();
            _icon.color = Colors.clearWhite;
            _icon.enabled = false;
            _transform = _icon.transform;

            TweenParams commonTweenParams = new TweenParams()
                .SetEase(_ease)
                .SetRecyclable(true)
                .SetAutoKill(false);
            _fadeIn = _icon
                .DOColor(Color.white, _fadeDuration)
                .SetAs(commonTweenParams)
                .OnStart(OnStartLoading)
                .Pause();
            _fadeOut = _icon
                .DOColor(Colors.clearWhite, _fadeDuration)
                .SetAs(commonTweenParams)
                .OnComplete(OnCompleteLoading)
                .Pause();

            // _text.color = Colors.clearWhite;
            // _text.enabled = false;
        }

        private void Update()
        {
            if (_isLoading)
            {
                _transform.Rotate(Vector3.forward, _rotateSpeed);
            }
        }

        private void OnStartLoading()
        {
            _icon.enabled = true;
            // _text.enabled = true;
            _isLoading = true;
        }

        private void OnCompleteLoading()
        {
            _icon.enabled = false;
            // _text.enabled = false;
            _isLoading = false;
            _transform.rotation = Quaternion.identity;
        }

        public IEnumerator FadeIn()
        {
            // // return StartCoroutine(FadeLoading(ease, Colors.clearWhite, Color.white, fadeDuration, OnStartLoading, null));
            // yield return _tween.Play();
            yield return _fadeIn.Play().WaitForCompletion();
        }

        public IEnumerator FadeOut()
        {
            // // return StartCoroutine(FadeLoading(_ease, Color.white, Colors.clearWhite, _fadeDuration, null, OnCompleteLoading)); return null;
            // yield return _tweenPlayBackwards();
            yield return _fadeOut.Play().WaitForCompletion();
        }
    }
}
