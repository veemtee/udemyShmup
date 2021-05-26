using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loppufighterScript : MonoBehaviour
{
    public int armoryMaxHealth;
    public int armoryCurrentHealth;
    public GameObject armory;

    //public GameObject Raato;
    public bool deadorAlive = false;
    public GameObject possaus;
    public GameObject sparks;
    public GameObject bullet;

    //public GameObject keulaPanssariTrigger;
    //public GameObject muuPanssariTrigger;

    private void Start()
    {
        armoryCurrentHealth = armoryMaxHealth;
    }

    private void Update()
    {
        if (armoryCurrentHealth <= 0)
        {
            if (deadorAlive == true)
            {
                Instantiate(possaus.gameObject, transform.position, transform.rotation);
                //Instantiate(Raato.gameObject, transform.position, transform.rotation);
                Invoke("Tuhoutuminen", 0.0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("LuotiOsuPerään");
            Instantiate(sparks.gameObject, other.transform.position, other.transform.rotation);
            armoryCurrentHealth--;
            Destroy(other.gameObject);

        }

        if (other.tag == "Railgun")
        {
            Debug.Log("kranuOsuPerään");
            armoryCurrentHealth = -21;
        }
    }



    void Tuhoutuminen()
    {
        armory.SetActive(false);
    }
}
