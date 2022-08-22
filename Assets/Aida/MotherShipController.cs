using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipController : MonoBehaviour
{
    [Header("エネミーのタグの名前"), SerializeField] string _enemyTagName;
    [Header("マザーシップのヒットポイント"), SerializeField] public int _hitPoint = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemyと接触したときの処理
        if(collision.gameObject.tag == _enemyTagName)
        {
            if (_hitPoint > 0)
            {
                _hitPoint--;
            }
            //自身をデストロイする。
            else
            {
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
