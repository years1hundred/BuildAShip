using UnityEngine;

namespace LD45Jam
{
    public class Player : Ship
    {
        // Input
        private PlayerInputActions _input;
        //private bool _leftPressed;
        //private bool _rightPressed;

        //[SerializeField]
        //private float _doubleTapTimeout = 0.25f;
        //private float _doubleTapElapsed;

        public int Scrap { get; set; }

        protected override void Awake()
        {
            base.Awake();

            _input = GC.Input;
        }

        private void Update()
        {
            Move(_input.Move.Value.x, _input.Look.Value.x, _input.Move.Value.y);

            HandleInputActions();
        }

        private void HandleInputActions()
        {
            // Handle guns
            if (_input.Button1.IsPressed)
            {
                Shoot();
            }

            //if (_input.Left.WasPressed)
            //{
            //    _leftPressed = true;
            //    _rightPressed = false;
            //    _doubleTapElapsed += Time.deltaTime;

            //    if (_doubleTapElapsed > _doubleTapTimeout)
            //    {
            //        _doubleTapElapsed = 0;
            //    }
            //}
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Scrap")
            {
                Scrap++;
            }
        }
    }
}
