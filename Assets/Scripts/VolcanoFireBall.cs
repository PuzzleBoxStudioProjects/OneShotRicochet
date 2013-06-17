using UnityEngine;
using System.Collections;

public class VolcanoFireBall : MonoBehaviour
{
    public static GameObject fireBallInstance = null;

    public float launchForce = 10.0f,
                 downSpeed = 20.0f;

	// Use this for initialization
	void Start ()
    {
        //record this object so the volcano won't spawn another while there is already one alive
        fireBallInstance = gameObject;

        //give a force when the fire ball is first launched
        rigidbody.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //apply "gravity"
        rigidbody.velocity = new Vector3(0, 0, rigidbody.velocity.z - downSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
}
