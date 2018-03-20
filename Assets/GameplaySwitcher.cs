using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySwitcher : MonoBehaviour {

    public CameraController cameraController;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        Tile.CombatTriggered += combatTriggered;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void combatTriggered(ExploringEnemy enemy) {
        cameraController.SwitchCamera();
        Destroy(enemy.gameObject);
        //TO BE WORKED ON.
    }
}
