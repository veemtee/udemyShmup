using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int armoryMaxHealth;
    public int armoryCurrentHealth;
    public bool deadorAlive = false;

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject pikkuAsteroidi;

    //public GameController gameController;

    private void Start()
    {
        armoryCurrentHealth = armoryMaxHealth;
        //gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (armoryCurrentHealth <= 0)
        {
            if (deadorAlive == true)
            {

                Instantiate(pikkuAsteroidi, transform.position, transform.rotation);
                Invoke("Tuhoutuminen", 0.0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            
            armoryCurrentHealth--;
            Destroy(other.gameObject);
           
        }
        if (other.tag == "RailGun")
        {

            armoryCurrentHealth -= 50;
            Destroy(other.gameObject);

        }

        if (other.tag == "Boundary")
        {
            return;
        }
        //Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);
            
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }



    void Tuhoutuminen()
    {
        //gameController.ScoreCount(6667);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
