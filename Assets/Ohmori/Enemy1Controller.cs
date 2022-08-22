using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy1Controller : MonoBehaviour
{
    Transform _targetTransform;
    /// <summary>�ړ����x</summary>
    [Tooltip("�ړ����x")]
    [SerializeField] float _moveSpeed = default;
    /// <summary>�^�[�Q�b�g�̃^�O��</summary>
    [Tooltip("�^�[�Q�b�g�̃^�O��")]
    [SerializeField] string _targetTag = default;
    [Tooltip("�֍s")]
    [SerializeField] bool _isMoveWave = false;
    Rigidbody2D _rb;
    void Start()
    {
        _targetTransform = GameObject.FindWithTag(_targetTag).transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_targetTransform != null)
        {
            _rb.velocity = (_targetTransform.position - transform.position).normalized * _moveSpeed;

            if (_rb.velocity != Vector2.zero)
            {
                float rad = Mathf.Atan2(_rb.velocity.x, _rb.velocity.y) * -Mathf.Rad2Deg;

                Vector3 angles = transform.localEulerAngles;
                angles.z = rad;
                transform.localEulerAngles = angles;
            }

            if (_isMoveWave)
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("MotherShip"))
        {
            Destroy(this.gameObject);
        }
    }
}
