using UnityEngine;

namespace LD45Jam
{
    public class ShotGun : Gun
    {
        public int spread = 15;
        public int bullets = 3;

        public override void Fire()
        {
            base.Fire();

            Debug.Log("Shotgun Fired!");
            //for (int i = -(bullets / 2); i < (bullets / 2) + 1; i++)
            //{
            //    CreateBullet(i * spread);
            //}
        }
    }
}
