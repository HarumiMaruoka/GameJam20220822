using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int m_HP;
    [SerializeField] int m_enemyDamage;
   //自機の速度
   [SerializeField] float m_moveSpeed = 5f;
    //自機の弾
    [SerializeField] GameObject m_bulletPrefab = null;
    //弾の発射位置
    [SerializeField] Transform m_muzzle = null;
    //一画面の最大弾数
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
    //やられたときの爆発エフェクト
    [SerializeField] GameObject m_explosionEffect = null;
    Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");  
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v).normalized; 
        m_rb.velocity = dir * m_moveSpeed;
        if (Input.GetButtonDown("Fire1"))
        {
            if (m_bulletLimit == 0 || this.GetComponentsInChildren<PlayerBulletController>().Length < m_bulletLimit)    // 画面内の弾数を制限する
            {
                Fire1();
            }
        }
    }
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab にプレハブが設定されている時 かつ m_muzzle に弾の発射位置が設定されている時
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // インスペクターから設定した m_bulletPrefab をインスタンス化する
            go.transform.SetParent(this.transform);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵か敵の発射する弾に接触したら、やられる
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            m_HP -= m_enemyDamage;
                // 爆発エフェクトを生成する
                if (m_HP <= 0)
                {
                    GameObject go = Instantiate(m_explosionEffect);
                    go.transform.position = this.transform.position;
                }
             Destroy(this.gameObject);   // 自分を破棄する
            }
        }
    }
