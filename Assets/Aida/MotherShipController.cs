using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipController : MonoBehaviour
{
    [Header("�G�l�~�[�̃^�O�̖��O"), SerializeField] string _enemyTagName;
    [Header("�}�U�[�V�b�v�̃q�b�g�|�C���g"), SerializeField] public int _hitPoint = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy�ƐڐG�����Ƃ��̏���
        if(collision.gameObject.tag == _enemyTagName)
        {
            if (_hitPoint > 0)
            {
                _hitPoint--;
            }
            //���g���f�X�g���C����B
            else
            {
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
