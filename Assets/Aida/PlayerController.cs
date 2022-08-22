using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int m_HP;
    [SerializeField] int m_enemyDamage;
   //���@�̑��x
   [SerializeField] float m_moveSpeed = 5f;
    //���@�̒e
    [SerializeField] GameObject m_bulletPrefab = null;
    //�e�̔��ˈʒu
    [SerializeField] Transform m_muzzle = null;
    //���ʂ̍ő�e��
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
    //���ꂽ�Ƃ��̔����G�t�F�N�g
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
            if (m_bulletLimit == 0 || this.GetComponentsInChildren<PlayerBulletController>().Length < m_bulletLimit)    // ��ʓ��̒e���𐧌�����
            {
                Fire1();
            }
        }
    }
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // �C���X�y�N�^�[����ݒ肵�� m_bulletPrefab ���C���X�^���X������
            go.transform.SetParent(this.transform);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // �G���G�̔��˂���e�ɐڐG������A�����
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            m_HP -= m_enemyDamage;
                // �����G�t�F�N�g�𐶐�����
                if (m_HP <= 0)
                {
                    GameObject go = Instantiate(m_explosionEffect);
                    go.transform.position = this.transform.position;
                }
             Destroy(this.gameObject);   // ������j������
            }
        }
    }
