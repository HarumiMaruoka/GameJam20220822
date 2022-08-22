using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class BossCotroller : MonoBehaviour
{
    Transform _matherShipTransform;
    [Tooltip("�񎟈ړ��Ɉڂ鋗��")]
    [SerializeField] float _distance = default;
    [Tooltip("�ړ����x")]
    [SerializeField] float _moveSpeed = default;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _matherShipTransform = GameObject.FindWithTag("MatherShip").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_matherShipTransform.position, this.transform.position) > _distance)
        {
            _rb.velocity = (_matherShipTransform.position - transform.position).normalized * _moveSpeed;
        }
        else if (Vector3.Distance(_matherShipTransform.position, this.transform.position) <= _distance)
        {
            //���̊֐��́A�������͉�]�̒��S�A�������͉�]���A��O�����͈ړ����x
            _rb.velocity = Vector2.zero;
            transform.RotateAround(_matherShipTransform.position, new Vector3(0f, 0f, 1f), _moveSpeed * 30 * Time.deltaTime);
        }
    }
}
