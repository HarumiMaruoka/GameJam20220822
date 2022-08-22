using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("プレイヤーのヒットポイント"), SerializeField] int _HP;
    [Header("プレイヤーの移動速度"), SerializeField] float _moveSpeed = 5f;
    [SerializeField] GameObject _bulletPrefab = null;
    [SerializeField] Transform _muzzle = null;

    Rigidbody2D _rigidbody2D;
    Vector2 _dir;
    float _inputH;
    float _inputV;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        Fire1();
    }

    // 移動処理
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
        //速度を与える
        _rigidbody2D.velocity = newVelocity * _moveSpeed;

    }

    // 左クリック処理
    void Fire1()
    {
        //入力を判定
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
