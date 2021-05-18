using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delete", 25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void delete()
    {
        Destroy(gameObject);
    }
}
