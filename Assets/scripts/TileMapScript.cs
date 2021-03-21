using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapScript : MonoBehaviour
{
    public GameObject CollidableSurface;
    public TileType[] tileTypes;
    int[ , ] tiles;


    int SizeX = 30;
    int SizeZ = 30;

    void Start ()
        {
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
            tiles [15,15] = 0;
            tiles [15,14] = 0;
            tiles [15,13] = 1;
            tiles [15,12] = 0;
            tiles [15,11] = 0;
            tiles [15,10] = 3;
            tiles [15,9] = 0;
            tiles [15,8] = 0;
            tiles [15,7] = 0;
            tiles [15,6] = 2;
            tiles [1,1] = 3;


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