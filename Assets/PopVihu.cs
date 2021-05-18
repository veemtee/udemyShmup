using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopVihu : MonoBehaviour
{
    public GameObject explosion;
    public GameObject popBolt;
    float bulletRandomTime;

    void Start()
    {
        bulletRandomTime = Random.Range(3.25f, 5.5f);
        Invoke("bullet", bulletRandomTime);
        Invoke("delete", 20f);
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Invoke("delete", 0.2f);
        }

        if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    private void bullet()
    {
        Instantiate(popBolt, transform.position, transform.rotation);
    }

    private void delete()
    {
        Destroy(gameObject);
    }
}
