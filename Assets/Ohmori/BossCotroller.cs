using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCotroller : MonoBehaviour
{
    Transform _matherShipTransform;
    // Start is called before the first frame update
    void Start()
    {
        _matherShipTransform = GameObject.FindWithTag("MatherShip").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //この関数は、第一引数は回転の中心、第二引数は回転軸、第三引数は移動速度
        transform.RotateAround(Vector3.zero, new Vector3(0f, 0f, 1f), 30 * Time.deltaTime);
    }
}
