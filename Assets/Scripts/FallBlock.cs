using UnityEngine;
using System.Collections;

public class FallBlock : MonoBehaviour
{
    public static FallBlock instance;

    public bool hasBrokenRope = false;

    public float speed = 10.0f;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        rigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //make the block fall when the rope has broken
        if (hasBrokenRope)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(Vector3.back * speed, ForceMode.Acceleration);
        }
	}

    void OnCollisionEnter(Collision col)
    {
        //stop the block from moving
        if (col.transform.tag == "Wall")
        {
            rigidbody.isKinematic = true;
            hasBrokenRope = false;
        }
    }
}
