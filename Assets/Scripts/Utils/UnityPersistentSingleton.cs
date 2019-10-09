using UnityEngine;

namespace LD45Jam
{
    public class UnityPersistentSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Instance field and property

        private static T _instance;

        public static T Instance {
            get {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        #endregion

        protected virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
