using UnityEngine;

namespace LD45Jam
{
    public class BasicGun : Gun
    {
        public override void Fire()
        {
            base.Fire();

            Debug.Log("Basic Gun Fired!");

            //CreateBullet(0);
        }
    }
}
