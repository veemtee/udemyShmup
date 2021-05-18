using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunBolt : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    public GameObject explosion;
    public ParticleSystem RailEffect;
    Vector3 rotation;

    //public GameController gameController;

    void Start()
    {
        rig.velocity = transform.forward * speed;
        rotation = new Vector3(0, 0, 2400);

        //gameController = GameObject.Find("GameController").GetComponent<GameController>();
        RailEffect.Play();
    }

    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        rig.MoveRotation(rig.rotation * deltaRotation);
    }


    private void OnTriggerEnter(Collider other)
    {
        //gameController.ScoreCount(3);
        //Debug.Log("lisääscoreajooko");
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
