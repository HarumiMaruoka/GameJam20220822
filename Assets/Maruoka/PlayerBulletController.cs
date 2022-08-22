using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBulletController : MonoBehaviour
{
    /// <summary>’e‚Ì”­ŽË•ûŒü</summary>
    [SerializeField] Vector2 m_direction = Vector2.up;
    /// <summary>’e‚Ì”ò‚Ô‘¬“x</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    Rigidbody2D m_rb;
   
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Vector3 v = m_direction.normalized * m_bulletSpeed; 
        m_rb.velocity = v;
    }
}
