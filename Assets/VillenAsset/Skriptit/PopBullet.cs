using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopBullet : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rig.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            //Debug.Log("vihuboltScript");
            //PC.armoryCurrentHealth--;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
