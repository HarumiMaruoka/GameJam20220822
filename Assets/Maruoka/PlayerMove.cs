using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("�v���C���[�̃q�b�g�|�C���g"), SerializeField] int _HP;
    [Header("�v���C���[�̈ړ����x"), SerializeField] float _moveSpeed = 5f;
    //���@�̒e
    [SerializeField] GameObject _bulletPrefab = null;
    //�e�̔��ˈʒu
    [SerializeField] Transform _muzzle = null;

    Rigidbody2D _rigidbody2D;
    Vector2 _dir;
    float _inputH;
    float _inputV;

    Quaternion _targetRotation;
    [Header("��]���x"), SerializeField] float _rotationSpeed;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        Fire1();
    }

    // �ړ�����
    void Move()
    {
        float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
        Vector2 newVelocity = new Vector2(inputH, inputV).normalized;

        if (newVelocity != Vector2.zero)
        {
            float rad = Mathf.Atan2(newVelocity.x, newVelocity.y) * -Mathf.Rad2Deg;

            Vector3 angles = transform.localEulerAngles;
            angles.z = rad;
            transform.localEulerAngles = angles;
        }
        //���x��^����
        _rigidbody2D.velocity = newVelocity * _moveSpeed;

    }

    // ���N���b�N����
    void Fire1()
    {
        //���͂𔻒�
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }

    void test()
    {
        float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
        Vector3 newVelocity = new Vector3(inputH, inputV, 0f).normalized;

        // �ړ�����������
        if (newVelocity.magnitude > 0.5f)
        {
            _targetRotation = Quaternion.LookRotation(newVelocity, Vector3.up);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        //���x��^����
        _rigidbody2D.velocity = newVelocity * _moveSpeed + Vector3.up * _rigidbody2D.velocity.y;

    }
}