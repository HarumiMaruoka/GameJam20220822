using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMotherHP : MonoBehaviour
{
    [Header("�n�[�g�̃X�v���C�g : �v���n�u"), SerializeField] GameObject _heartSpritePrefab;
    MotherShipController _motherShipHitPoint;
    [Header("player�̃^�O"), SerializeField] string _motherShipTagName;

    void Start()
    {
        _motherShipHitPoint = GameObject.FindGameObjectWithTag(_motherShipTagName).GetComponent<MotherShipController>();
        //�n�[�g�𐶐�����B
        for (int i = 0; i < _motherShipHitPoint._hitPoint; i++)
        {
            Instantiate(_heartSpritePrefab, transform);
        }
    }


    private void OnEnable()
    {

    }

    void Update()
    {
        if (transform.childCount != _motherShipHitPoint._hitPoint)
        {
            if (transform.childCount < _motherShipHitPoint._hitPoint)
            {
                for (int i = 0; i < Mathf.Abs(transform.childCount - _motherShipHitPoint._hitPoint); i++)
                {
                    Instantiate(_heartSpritePrefab, transform);
                }
            }

            else if (transform.childCount > _motherShipHitPoint._hitPoint)
            {
                for (int i = 0; i < Mathf.Abs(transform.childCount - _motherShipHitPoint._hitPoint); i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
