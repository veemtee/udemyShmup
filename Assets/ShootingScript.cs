using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    int shotIndex = 0;
    public float fireRate;
    private float lastFire = 0.0f;

    public GameObject bullet;
    public GameObject[] sarjaSpawn;
    public GameObject[] spreadSpawn;
    public GameObject railgunSpawn;
    public GameObject railBolt;

    public int shootMode;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (shootMode == 1)
            {
                shootMode = 0;
            }
            else
            {
                shootMode += 1;
            }


        }

        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(ShootModeChange());
        }

        if (Input.GetButton("Fire3"))
        {
            
            Railgun();
            Debug.Log("fire3");
        }

    }

    public void Railgun()
    {
        Instantiate(railBolt, railgunSpawn.transform.position, railgunSpawn.transform.rotation);
    }

    IEnumerator ShootModeChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (shootMode == 0)
        {
            concentraded();
        }
        if (shootMode == 1)
        {
            spreadi();
        }
    }

    public void concentraded()
    {
        lastFire = Time.time + fireRate;

        Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
        //suuliekki.Play();
        shotIndex++;
        if (shotIndex > 3)
            shotIndex = 0;
    }

    public void spreadi()
    {
        lastFire = Time.time + fireRate;

        Instantiate(bullet, spreadSpawn[shotIndex].transform.position, spreadSpawn[shotIndex].transform.rotation);
        //suuliekki.Play();
        shotIndex++;
        if (shotIndex > 3)
            shotIndex = 0;
    }
}
