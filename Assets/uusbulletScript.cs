using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uusbulletScript : MonoBehaviour
{

    public Rigidbody rig;
    public float speed;
    public GameObject asteroidDust;

    // Start is called before the first frame update
    void Start()
    {
        rig.velocity = transform.forward * speed;
        Invoke("timeDestroy", 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Enemy"))
        {
            Destroy(gameObject);
        }

        if (other.tag == ("Asteroid"))
        {
            Instantiate(asteroidDust, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void timeDestroy()
    {
        Destroy(gameObject);
    }

}
