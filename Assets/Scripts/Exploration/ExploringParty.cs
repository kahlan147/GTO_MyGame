using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploringParty : MonoBehaviour {

    public Tile myTile;
    public int tileDistance;
    public delegate void ChangedPosition();
    public static event ChangedPosition positionChanged;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        CheckMovement();
	}

    private void CheckMovement()
    {
        string ButtonVertical = "P1Vertical";
        string ButtonHorizontal = "P1Horizontal";
        float delay = 0.005f;

        if (Input.GetButtonUp(ButtonVertical)){
            if (Input.GetAxis(ButtonVertical) > delay)
            {
                MoveToTile(new Vector3(0, 0, tileDistance));
            }
            else if (Input.GetAxis(ButtonVertical) < -delay)
            {
                MoveToTile(new Vector3(0, 0, -tileDistance));
            }
        }
        if (Input.GetButtonUp(ButtonHorizontal))
        {
            if (Input.GetAxis(ButtonHorizontal) > delay)
            {
                MoveToTile(new Vector3(tileDistance,0,0));
            }
            else if (Input.GetAxis(ButtonHorizontal) < -delay)
            {
                MoveToTile(new Vector3(-tileDistance,0,0));
            }
        }
    }

    private void MoveToTile(Vector3 direction)
    {
        Vector3 potentialNewPosition = this.transform.position + direction;

        RaycastHit hit;
        Physics.Raycast(potentialNewPosition, Vector3.down * 3, out hit);

        if (hit.collider != null)
        {
            if (hit.collider.transform.parent.gameObject.tag == "Tile")
            {
                Tile tile = hit.collider.transform.parent.gameObject.GetComponent<Tile>();
                if (tile.CanWalkHere())
                {
                    myTile = tile;
                    this.transform.position = potentialNewPosition;
                    positionChanged();
                }
            }
        }
    }
    
}
