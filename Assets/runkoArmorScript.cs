using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runkoArmorScript : MonoBehaviour
{
    public int armoryMaxHealth;
    public int armoryCurrentHealth;
    public GameObject armory;

    //public GameObject Raato;
    public bool deadorAlive = false;
    public GameObject possaus;
    public GameObject sparks;
    public GameObject lopppuexplosion;

    public GameObject[] sarjaExplosion;
    public GameObject explosion;
    int expIndex;
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
                Instantiate(explosion, sarjaExplosion[expIndex].transform.position, sarjaExplosion[expIndex].transform.rotation);
                expIndex++;
                if (expIndex > 6)
                    expIndex = 0;
                //Instantiate(Raato.gameObject, transform.position, transform.rotation);
                Invoke("loppuexplosion", 2.0f);
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

    void loppuexplosion()
    {
        Instantiate(lopppuexplosion.gameObject, transform.position, transform.rotation);
        Invoke("Tuhoutuminen", 0.5f);
    }

    void Tuhoutuminen()
    {

        armory.SetActive(false);
    }
}
