using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD45Jam
{
    public class SceneHelper : MonoBehaviour
    {
        private LoadingIcon _loadingIcon;
        private ScreenFade _screenFade;

        public bool IsLoading { get; private set; }

        private void Awake()
        {
            _loadingIcon = GetComponentInChildren<LoadingIcon>();
            _screenFade = GetComponentInChildren<ScreenFade>();
        }

        public void GoTo(string sceneName, bool fastLoad)
        {
            if (IsLoading)
            {
                return;
            }

            StartCoroutine(AsyncLoad(sceneName));
        }

        private IEnumerator AsyncLoad(string sceneName)
        {
            IsLoading = true;

            // Fade to black
            yield return _screenFade.FadeToBlack();

            // Fade in loading icon
            yield return _loadingIcon.FadeIn();

            // Fake some loading time
            yield return new WaitForSeconds(0.5f);

            // Load level asynchronously
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;
            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.9f)
                {
                    // Fade out loading icon
                    yield return _loadingIcon.FadeOut();
                    yield return new WaitForSeconds(1);

                    asyncLoad.allowSceneActivation = true;
                }
                yield return null;
            }

            // Fade to clear and level
            yield return _screenFade.FadeToClear();

            IsLoading = false;
        }
    }
}
