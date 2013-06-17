using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
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
        //if the enemy hits the player or the fall block decrease the number of enemies
        if (col.transform.tag == "Player" || col.transform.name == "fall block")
        {
            Destroy(gameObject);
            GameMaster.instance.enemyCount--;
        }
    }
}
