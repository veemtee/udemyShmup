using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihuBolt : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    public GameObject explosion;
    //public AudioSource audios;
    //public PlayerController PC;

    void Start()
    {
        
        rig.velocity = transform.forward * speed;
        //PC.GetComponent<PlayerController>();
        //audios.Play();
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
