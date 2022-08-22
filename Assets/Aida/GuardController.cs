using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    [Header("�G�l�~�[�̃^�O�̖��O"), SerializeField] string _enemyTagName;
    [SerializeField] GameObject m_effectPrefab;
    [SerializeField] GameObject m_enemyBulletPrefab = null;
    float m_timer;
    [SerializeField] float m_fireInterval = 1f;
    [SerializeField] Transform[] m_muzzles = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _enemyTagName)
        {
            Destroy(this.gameObject);
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, m_effectPrefab.transform.rotation);
            }
        }
    }
    private void Update()
    {
        if (m_enemyBulletPrefab)
        {
            // ���Ԋu�Œe�𔭎˂���
            m_timer += Time.deltaTime;
            if (m_timer > m_fireInterval)
            {
                m_timer = 0f;

                // �e muzzle ����e�𔭎˂���
                foreach (Transform t in m_muzzles)
                {
                    Instantiate(m_enemyBulletPrefab, t.position, Quaternion.identity);
                }
            }
        }
    }
}
