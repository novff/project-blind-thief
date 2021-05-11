using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMSLevel1 : MonoBehaviour
{
    public GameObject CollidableSurface;
    public TileType[] tileTypes;
    int[ , ] tiles;
    public Vector3 startTile;
    public GameObject PlayerInstanceSpawn;


    int SizeX = 30;
    int SizeZ = 30;

    void Start ()
        {

            startTile.Set (6, 0, 6);
            
            //map allocation
            tiles = new int [SizeX,SizeZ];
            //map initialization
            for (int x = 0; x < SizeX; x++)
                {
                    for (int z = 0; z < SizeZ; z++)
                        {
                            tiles[x,z] = 0;
                        }
                }
//map thinigies
// tile types 0 = floor
//            1 = wall
//            2 = level end  
//            3 = abyss
            tiles [0,0] = 1;
            tiles [3,5] = 2;
            tiles [3,8] = 3;
            //rendering/generating
            GenVisuals();
        }
    void GenVisuals()
    {
        for (int x = 0; x < SizeX; x++)
                {
                    for (int z = 0; z < SizeZ; z++)
                        {
                            TileType ttype = tileTypes [tiles[x,z]];
                            GameObject CollidableSurface=(GameObject) Instantiate(ttype.VisualTilePrefab, new Vector3(x, 0, z), Quaternion.identity);

                            TileGridPosition tgpos = CollidableSurface.GetComponent<TileGridPosition>();
                            tgpos.tileX = x;
                            tgpos.tileZ = z;
                        }
                }
    }
}