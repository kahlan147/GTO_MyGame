using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public ExploringEnemy enemy;
    public bool NotWalkable;
    public bool SpawnTile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public bool CanWalkHere()
    {
        if (NotWalkable)
        {
            return false;
        }
        

        return true;
    }
    

}
