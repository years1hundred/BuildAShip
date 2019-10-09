using UnityEngine;

namespace LD45Jam
{
    public class GameBehaviour : MonoBehaviour
    {
        private GameController _gc;

        public GameController GC {
            get {
                if (_gc == null)
                {
                    _gc = GameController.Instance;
                }

                return _gc;
            }
        }
    }
}
