using UnityEngine;
using System.Collections;

public class PlayerDisc : MonoBehaviour
{
    public float speed = 0.0f;

    private Vector3 velocity = Vector3.zero;
    
    public static PlayerDisc instance;
    
    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        speed = PowerSlider.instance.shotForce;

        velocity = transform.TransformDirection(Vector3.forward);
	}
	
	void FixedUpdate ()
    {
        if (speed > 0)
        {
            //move the disc in world space
            transform.Translate(velocity * speed * Time.deltaTime, Space.World);
            //slow it down
            speed -= Time.deltaTime * 5;
        }

        if (speed <= 0 || GameMaster.instance.enemyCount == 0)
        {
            //stop moving
            velocity = Vector3.zero;
            speed = 0;
        }
	}


    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Wall")
        {
            //ricochet off the walls and count the bounce hits.
            velocity = Vector3.Reflect(velocity, col.contacts[0].normal);

            GameMaster.instance.bounceCount++;
        }

        if (col.transform.name == "fall block")
        {
            velocity = Vector3.Reflect(velocity, col.contacts[0].normal);
        }
    }
}
