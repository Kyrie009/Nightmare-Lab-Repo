using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tiletype { Empty, Enemy, Stairs, Entrance}
public enum FloorDirection { Up, Down}

public class LevelManager : Singleton<LevelManager>
{
    int floor = 0;


    Leveltiles[] floorTiles;

    Leveltiles[] floor0 = new Leveltiles[49];
    Leveltiles[] floor1 = new Leveltiles[49];
    Leveltiles[] floor2 = new Leveltiles[49];

    public Leveltiles[] levelStairs;
    public Leveltiles[] levelEntrance;


    // Start is called before the first frame update
    void Start()
    {
        floorTiles = FindObjectsOfType<Leveltiles>();
        SetUpFloor(0, floor0);
        SetUpFloor(1, floor1);
        SetUpFloor(2, floor2);
        floorTiles = floor0;

    }

    public void ChangeFloor(FloorDirection _direction)
    {
        if (floor == 0 || floor == levelStairs.Length)
        {
            return;
        }
        floor = _direction == FloorDirection.Up ? floor - 1 : floor + 1;
        if (floor == 0)
        {
            floorTiles = floor0;
        }

        if (floor == 1)
        {
            floorTiles = floor1;
        }

        if (floor == 2)
        {
            floorTiles = floor2;
        }

        for (int i = 0; i < floorTiles.Length; i++)
        {
            floorTiles[i].ResetColor();
        }
    }

    public void SetUpFloor(int _floor, Leveltiles[] _thisfloor)
    {
        //_thisfloor = new Leveltiles[floorTiles.Length];
        _thisfloor = floorTiles;
        for (int i = 0; i<floorTiles.Length; i++)
        {
           
            _thisfloor[i].SetupTile();
        }

        levelStairs[_floor].myType = Tiletype.Stairs;
        levelEntrance[_floor].myType = Tiletype.Entrance;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
