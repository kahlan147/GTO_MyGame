using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera ExplorationCamera;
    public Camera CombatCamera;
    

	// Use this for initialization
	void Start () {
        CombatCamera.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchCamera()
    {
        if (ExplorationCamera.isActiveAndEnabled)
        {
            CombatCamera.gameObject.SetActive(true);
            ExplorationCamera.gameObject.SetActive(false);
        }
        else
        {
            ExplorationCamera.gameObject.SetActive(true);
            CombatCamera.gameObject.SetActive(false);
        }
    }
}
