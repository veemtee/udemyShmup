using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterroidMover : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rig.velocity = transform.forward * speed;
    }
}
