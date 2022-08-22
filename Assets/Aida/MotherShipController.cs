using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipController : MonoBehaviour
{
    [Header("エネミーのタグの名前"), SerializeField] string _enemyTagName;
    [SerializeField] GameObject m_effectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemyと接触したときの処理
        if(collision.gameObject.tag == _enemyTagName)
        {
            //自身をデストロイする。
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
