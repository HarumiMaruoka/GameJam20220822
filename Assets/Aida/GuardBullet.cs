using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GuardBullet : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    void Start()
    {
        GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Enemy)
        {
            Vector2 v = Enemy.transform.position - this.transform.position;
            v = v.normalized * m_speed;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
