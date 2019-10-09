using LD45Jam;
using UnityEngine;

namespace LD45Jam
{
    public abstract class Gun : MonoBehaviour
    {
        [Header("Gun Attributes")]
        public float cooldown = 0.2f;

        public Projectile bullet;
        public float bulletSpeed = 15f;
        public float bulletLifeTime = 15f;

        private bool _isShooting;
        private float _shotTimer;

        private void Update()
        {
            if (_isShooting)
            {
                _shotTimer += Time.deltaTime;
                if (_shotTimer > cooldown)
                {
                    _isShooting = false;
                    _shotTimer -= cooldown;
                }
            }
        }

        public virtual void Fire()
        {
            if (_isShooting)
            {
                return;
            }

            _isShooting = true;
        }

        //protected void CreateBullet(int rotate)
        //{
        //    GameObject bulletInst = Instantiate(bullet);
        //    bulletInst.transform.rotation = transform.rotation;
        //    bulletInst.transform.position = transform.position;
        //    bulletInst.transform.Translate(0, 0, transform.localScale.z);
        //    //bulletInst.transform.Rotate(0, rotate + Random.Range(-randomInaccuracy, randomInaccuracy), 0);

        //    bulletInst.GetComponent<Bullet>().speed = bulletSpeed;
        //    bulletInst.GetComponent<Destroy>().timeToDestroy = bulletLifeTime;
        //}
    }
}
