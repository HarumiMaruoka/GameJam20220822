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
        //���̊֐��́A�������͉�]�̒��S�A�������͉�]���A��O�����͈ړ����x
        transform.RotateAround(Vector3.zero, new Vector3(0f, 0f, 1f), 30 * Time.deltaTime);
    }
}
