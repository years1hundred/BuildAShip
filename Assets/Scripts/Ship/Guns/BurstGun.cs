using System.Collections;
using UnityEngine;

namespace LD45Jam
{
    public class BurstFire : Gun
    {
        public int bullets = 3;
        public float burstSpeed = 0.1f;

        public override void Fire()
        {
            base.Fire();

            Debug.Log("Burst Gun Fired!");

            //StartCoroutine(BurstShot());
        }

        //private IEnumerator BurstShot()
        //{
        //    for (int i = 0; i < bullets; i++)
        //    {
        //        CreateBullet(0);
        //        yield return new WaitForSeconds(burstSpeed);
        //    }
        //}
    }
}
