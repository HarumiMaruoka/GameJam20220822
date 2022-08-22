using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBulletController : MonoBehaviour
{
    /// <summary>’e‚Ì”ò‚Ô‘¬“x</summary>
    [SerializeField] float _bulletSpeed = 10f;
   
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up* _bulletSpeed;
    }
}
