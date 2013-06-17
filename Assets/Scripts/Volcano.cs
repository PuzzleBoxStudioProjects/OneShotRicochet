using UnityEngine;
using System.Collections;

public class Volcano : MonoBehaviour
{
    public float launchRate = 2.0f,
                 fireBallForce = 10.0f,
                 lastTime = 0.0f;

    public Rigidbody fireBall;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //launch the fire ball every set amount of time
        if (Time.time - lastTime >= launchRate && VolcanoFireBall.fireBallInstance == null)
        {
            Instantiate(fireBall, transform.position + Vector3.forward * 1.5f, transform.rotation);
        
            lastTime = Time.time;
        }
	}
}
