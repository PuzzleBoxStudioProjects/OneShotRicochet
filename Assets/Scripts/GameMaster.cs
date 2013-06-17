using UnityEngine;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
    public int bounceCount = 0,
               enemyCount = 0;

    private List<GameObject> enemyList;

    public static GameMaster instance;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        //find all enemies
        enemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        enemyCount = enemyList.Count;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
