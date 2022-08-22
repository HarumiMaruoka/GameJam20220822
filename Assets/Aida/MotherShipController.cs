using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipController : MonoBehaviour
{
    [Header("�G�l�~�[�̃^�O�̖��O"), SerializeField] string _enemyTagName;
    [SerializeField] GameObject m_effectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy�ƐڐG�����Ƃ��̏���
        if(collision.gameObject.tag == _enemyTagName)
        {
            //���g���f�X�g���C����B
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
