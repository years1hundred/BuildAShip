using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
    [Header("Projectile Attributes")]
    [SerializeField]
    protected float _speed;

    [SerializeField]
    protected float _damage = 1f;

    [SerializeField]
    protected float _lifeTime = 10f;
}
