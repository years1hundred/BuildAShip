using UnityEngine;

namespace LD45Jam
{
    public class Scrap : GameBehaviour
    {
        public AudioClip pickup;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(pickup, Camera.main.transform.position, 0.5f);

                Destroy(gameObject);
            }
        }
    }
}
