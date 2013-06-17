using UnityEngine;
using System.Collections;

public class FallPortalBlock : MonoBehaviour
{
    private GameObject outPort;

	// Use this for initialization
	void Start ()
    {
        outPort = GameObject.FindWithTag("OutPort");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "InPort")
        {
            transform.position = new Vector3(outPort.transform.position.x, transform.position.y, outPort.transform.position.z);
        }
    }
}
