using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class BossCotroller : MonoBehaviour
{
    Transform _matherShipTransform;
    [Tooltip("二次移動に移る距離")]
    [SerializeField] float _distance = default;
    [Tooltip("下降の移動速度")]
    [SerializeField] float _moveSpeed1 = default;
    [Tooltip("回転時の移動速度")]
    [SerializeField] float _moveSpeed2 = default;
    Rigidbody2D _rb;
    int _hitPoint=300;
    // Start is called before the first frame update
    void Start()
    {
        _matherShipTransform = GameObject.FindWithTag("MotherShip").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_matherShipTransform != null)
        {
            if (Vector3.Distance(_matherShipTransform.position, this.transform.position) > _distance)
            {
                _rb.velocity = (_matherShipTransform.position - transform.position).normalized * _moveSpeed1;
            }
            else if (Vector3.Distance(_matherShipTransform.position, this.transform.position) <= _distance)
            {
                //この関数は、第一引数は回転の中心、第二引数は回転軸、第三引数は移動速度
                _rb.velocity = Vector2.zero;
                transform.RotateAround(_matherShipTransform.position, new Vector3(0f, 0f, 1f), _moveSpeed2 * 30 * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            _hitPoint--;
            if (_hitPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
