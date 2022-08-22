using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotTestScript : MonoBehaviour
{
    [SerializeField] Transform Guard;

    bool frag = false;
    Vector3 defDir;
    // Start is called before the first frame update
    void Start()
    {
        defDir = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (frag)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Guard.position - transform.position, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Guard" || hit.collider.tag == "MainCamera")
                {
                    this.gameObject.SetActive(false);
                }
                else
                {
                    this.gameObject.SetActive(true);
                }
            }
        }
    }
}