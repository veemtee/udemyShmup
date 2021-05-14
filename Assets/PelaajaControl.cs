using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Boundary
{
    public float xmin, xMax, zMin, Zmax;
}

public class PelaajaControl : MonoBehaviour
{
    public Joystick joysick;
    public Button plasma;
    public Button railgun;

    public Rigidbody rig;
    public float speed = 1;
    public float tilt;
    public float panning;
    public Boundary boundary;

    public GameObject bullet;
    public GameObject[] concentradedSpawn;
    public GameObject[] spreadSpawn;
    public GameObject railgunSpawn;
    public GameObject spaceShip;
    public GameObject rigRoot;

    int shotIndex = 0;
    public float fireRate;
    public float lastFire = 0.0f;

    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHor, 0.0f, moveVer);
        rig.velocity = movement * speed;


        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xmin, boundary.xMax), 0.0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.Zmax));
        rig.rotation = Quaternion.Euler(rig.rotation.x,/* 0.0f*/ rig.velocity.x * panning + 180, rig.velocity.x * tilt);


        if (joysick.Horizontal <= .2f)
        {
            spaceShip.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (joysick.Horizontal >= -.2f)
        {
            spaceShip.transform.Translate(Vector2.right * -speed * Time.deltaTime);
        }
        else
        {
            spaceShip.transform.Translate(Vector2.right * 0);
        }


        if (joysick.Vertical <= .2f)
        {
            spaceShip.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (joysick.Vertical >= -.2f)
        {
            spaceShip.transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        else
        {
            spaceShip.transform.Translate(Vector3.forward * 0);
        }
    }
}
