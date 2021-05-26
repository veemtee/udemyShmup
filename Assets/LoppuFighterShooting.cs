using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoppuFighterShooting : MonoBehaviour
{
    public GameObject popBolt;
    float bulletRandomTime;

    // Start is called before the first frame update
    void Start()
    {
        transform.forward
        bulletRandomTime = Random.Range(1.25f, 2.5f);
        InvokeRepeating("bullet", bulletRandomTime, bulletRandomTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void bullet()
    {
        Instantiate(popBolt, transform.position, transform.rotation);
    }
}
