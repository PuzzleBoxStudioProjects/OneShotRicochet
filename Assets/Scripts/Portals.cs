using UnityEngine;
using System.Collections;

public class Portals : MonoBehaviour
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
        //when the disc hits the in portal set its position to the out portal
        if (col.transform.tag == "InPort")
        {
            transform.position = new Vector3(outPort.transform.position.x, transform.position.y, outPort.transform.position.z);
        }
    }
}
