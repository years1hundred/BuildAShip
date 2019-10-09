using UnityEngine;

namespace LD45Jam
{
    public class Enemy : Ship
    {
        [Header("Enemy Attributes")]
        [SerializeField]
        private float fireRadius = 30;

        [SerializeField]
        private float visibleRadius = 40;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            Rotate();
            Move(0, 1, 0);
            Shoot();
        }

        private float PlayerDistance {
            get { return Vector3.Distance(GC.PlayerTransform.position, _transform.position); }
        }

        private bool IsPlayerSpotted {
            get { return PlayerDistance < visibleRadius; }
        }

        private bool IsEnemyShooting {
            get { return PlayerDistance < fireRadius; }
        }

        private void Rotate()
        {
            if (IsPlayerSpotted)
            {
                Vector3 direction = GC.PlayerTransform.position - _transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                _transform.rotation = Quaternion.RotateTowards(_transform.rotation, rotation, TurnSpeed * Time.deltaTime);
            }
        }

        // Show range when the enemy will get activated to shoot
        //private void OnDrawGizmosSelected()
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawWireSphere(transform.position, visibleRadius);

        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(transform.position, fireRadius);
        //}
    }
}
