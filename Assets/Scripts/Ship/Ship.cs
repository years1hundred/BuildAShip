using UnityEngine;
using LD45Jam.Utils.Easing;

namespace LD45Jam
{
    public abstract class Ship : GameBehaviour
    {
        // TODO: Tweak and give these values some default starting base values
        // Note: I changed to float because floats are easier to manipulate when adding effects (buffs or detrimental)
        public Transform _modelTransform;

        protected Transform _transform;
        protected Gun[] _guns;

        // Health
        [Header("Health")]
        public float HealthBase;
        public float HealthComponent;

        // Armor
        [Header("Armor")]
        public float ArmorBase;
        public float ArmorComponent;

        // Shield
        [Header("Shield")]
        public float ShieldBase;
        public float ShieldComponent;

        // Shield Recharge
        [Header("Shield Recharge")]
        public float ShieldRechargeSpeed;

        // Move Speed
        [Header("Move Speed")]
        public float MoveSpeedBase = 5;
        public float MoveSpeedComponent;

        // Turn Speed
        [Header("Turn Speed")]
        public float TurnSpeedBase = 5;
        public float TurnSpeedComponent;

        public float Shields { get { return ShieldBase + ShieldComponent; } }
        public float Armor { get { return ArmorBase + ArmorComponent; } }
        public float Health
        {
            get { return HealthBase + HealthComponent; }
            set => throw new System.NotImplementedException();
        }

        public float MoveSpeed { get { return MoveSpeedBase + MoveSpeedComponent; } }
        public float TurnSpeed { get { return TurnSpeedBase + TurnSpeedComponent; } }

        protected virtual void Awake()
        {
            _transform = GetComponent<Transform>();
            _modelTransform = _transform.Find("Model").GetComponent<Transform>();
            _guns = GetComponentsInChildren<Gun>();
        }

        protected void Move(float mx, float my, float mz)
        {
            // XZ Position
            Vector3 direction = (mx * _transform.right) + (mz * _transform.forward);
            _transform.position += direction.normalized * MoveSpeed * Time.deltaTime;

            // Y Rotation
            _transform.Rotate(Vector3.up, my * TurnSpeed * Time.deltaTime);

            // Ship swaying motion;
            _modelTransform.localRotation = Ease.Quaternion(_modelTransform.localRotation, Quaternion.Euler(mz * 5 + _transform.rotation.x, my * 5 + _transform.rotation.y, mx * -20), Time.deltaTime * MoveSpeed);
        }

        public void TakeDamage(float damage)
        {
            HealthBase -= damage;
        }

        protected void Shoot()
        {
            foreach (Gun gun in _guns)
            {
                gun.Fire();
            }
        }
    }
}
