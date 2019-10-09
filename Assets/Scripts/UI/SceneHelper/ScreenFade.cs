using LD45Jam.Utils.Easing;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LD45Jam
{
    [RequireComponent(typeof(MaskableGraphic))]
    public class ScreenFade : MonoBehaviour
    {
        [Header("Fade In/Out")]
        [Range(0.5f, 5)]
        public float fadeDuration = 1;
        public EaseType fadeEase = EaseType.InSine;

        [Header("Flash")]
        [Range(0.25f, 5)]
        public float flashDuration = 0.5f;
        public EaseType flashEase = EaseType.OutQuint;

        private MaskableGraphic _fade;
        private bool _isFadeAnimating;

        private void Awake()
        {
            _fade = GetComponent<MaskableGraphic>();
            _isFadeAnimating = false;
        }

        public Coroutine FadeToClear()
        {
            return DoFadeCoroutine(Color.black, Color.clear, fadeDuration, fadeEase, false, true);
        }

        public Coroutine FadeToBlack()
        {
            return DoFadeCoroutine(Color.clear, Color.black, fadeDuration, fadeEase, true, false);
        }

        public Coroutine Flash(float duration = 0.5f)
        {
            Color c = Color.white;
            return DoFadeCoroutine(c.WithAlpha(0.7f), c.WithAlpha(0), duration, flashEase);
        }

        private Coroutine DoFadeCoroutine(Color from, Color to, float duration, EaseType ease, bool enableOnStart = true, bool disableOnComplete = true)
        {
            if (_isFadeAnimating)
                return null;

            return StartCoroutine(DoFade(from, to, duration, ease, enableOnStart, disableOnComplete));
        }

        private IEnumerator DoFade(Color from, Color to, float duration, EaseType ease, bool enableOnStart, bool disableOnComplete)
        {
            _isFadeAnimating = true;

            _fade.enabled |= enableOnStart;

            _fade.color = from;
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                _fade.color = Ease.Color(from, to, t / duration, ease);
                yield return null;
            }
            _fade.color = to;

            _fade.enabled &= !disableOnComplete;

            _isFadeAnimating = false;
        }
    }
}
