using UnityEngine;
using System.Collections;

public class FallBlockRope : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //cut the rope and activate the block to fall
        if (col.transform.tag == "Player")
        {
            FallBlock.instance.hasBrokenRope = true;
            Destroy(gameObject);
        }
    }
}
