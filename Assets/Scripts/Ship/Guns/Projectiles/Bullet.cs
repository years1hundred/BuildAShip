using LD45Jam;
using UnityEngine;

public class Bullet : Projectile
{
    [Header("Bullet Attributes")]
    [SerializeField]
    private GameObject _bulletPrefab;

    //private void OnTriggerEnter(Collider col)
    //{
    //    Debug.Log("Hit" + col.gameObject);
    //    if (col.gameObject.GetComponent<Ship>())
    //    {
    //        col.gameObject.GetComponent<Ship>().TakeDamage(1);
    //    }
    //}
}
