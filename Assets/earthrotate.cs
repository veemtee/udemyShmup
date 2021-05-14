using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthrotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 5 * Time.deltaTime);
        //transform.Translate(Vector3.up * 2 * Time.deltaTime);
    }
}
