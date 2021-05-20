using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSHealth : MonoBehaviour
{
    public int gunshipHealth;
    public int currentHealth;
    public bool deadOrAlive = false;

    public GameObject miniexplosion;
    public GameObject kuolemaExplosion;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = gunshipHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (deadOrAlive == true)
            {
                Instantiate(kuolemaExplosion, transform.position, transform.rotation);

                Invoke("Tuhoutuminen", 0.5f);
            }
        }
    }

    void Tuhoutuminen()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Instantiate(miniexplosion, other.transform.position, other.transform.rotation);
            currentHealth--;
            Destroy(other.gameObject);
        }
    }
}
