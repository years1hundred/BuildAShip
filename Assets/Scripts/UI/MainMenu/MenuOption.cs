using DG.Tweening;
using TMPro;

namespace LD45Jam
{
    [System.Serializable]
    public class MenuOption
    {
        public TextMeshProUGUI textMesh;
        public string sceneName;
        public Tween tween;

        public void CreateTween(float to, float duration, Ease ease = Ease.InOutQuad)
        {
            tween = textMesh
              .DOFade(to, duration)
              .SetLoops(-1, LoopType.Yoyo)
              .SetEase(ease)
              .Pause();
        }

        public void StopTween()
        {
            tween.Rewind();
        }

        public void PlayTween()
        {
            tween.Play();
        }

        public string GetText()
        {
            return textMesh.text;
        }
    }
}
