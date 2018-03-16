﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class Level : MonoBehaviour {

    public List<Tile> Tiles;
    public TextAsset LevelFile;

    private List<List<int>> LevelArray;

	// Use this for initialization
	void Start () {
        ReadLevelTextFile();
        BuildLevel();   
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BuildLevel()
    {
        if (LevelArray == null)
        {
            Debug.Log("LEVEL ARRAY = NULL. CAN NOT GENERATE A LEVEL");
            return;
        }
        int y = 0;
        int x = 0;
        int SpawnDistance = 10;
        foreach (List<int> row in LevelArray)
        {
            foreach (int number in row)
            {
                Vector3 spawnLocation = new Vector3(x * SpawnDistance, 0, y * SpawnDistance);
                Tile levelTile = Instantiate(Tiles[number], spawnLocation, this.transform.rotation, this.transform);
                x++;
            }
            x = 0;
            y++;
        }
    }

    private void ReadLevelTextFile()
    {
        LevelArray = new List<List<int>>();
        string levelText = LevelFile.text;
        List<int> row = new List<int>();
        foreach (char letter in levelText)
        {
            int reformed;
            if (Int32.TryParse(letter.ToString(), out reformed))
            {
                row.Add(reformed);
            }
            if (letter == ';')
            {
                LevelArray.Add(row);
                row = new List<int>();
            }
        }

        //Testing purposes, uncomment to test.
        /*int y = 0;
        int x = 0;
        foreach (List<int> rowz in LevelArray)
        {
            
            foreach (int number in rowz)
            {
                Debug.Log("("+ x + "," + y +")" + number);
                x++;
            }
            x = 0;
            y++;
        }*/
    }
}
