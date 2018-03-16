using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    [Header("Values")]
    [Tooltip("Negative values to heal a target")]
    public int Damage;
    public int APCost;
    public int ManaCost;
    [Tooltip("True if the attack may only target allied characters")]
    public bool TargetAllies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
