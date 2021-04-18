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
            tiles [0,1] = 1;
            tiles [0,2] = 1;
            tiles [0,3] = 1;
            tiles [0,4] = 1;
            tiles [0,5] = 1;
            tiles [0,6] = 1;
            tiles [0,7] = 1;
            tiles [0,8] = 1;
            tiles [0,9] = 1;
            tiles [0,10] = 1;
            tiles [0,11] = 1;
            tiles [0,12] = 1;
            tiles [0,13] = 1;
            tiles [0,14] = 1;
            tiles [0,15] = 1;
            tiles [0,16] = 1;
            tiles [0,17] = 1;
            tiles [0,18] = 1;
            tiles [0,19] = 1;
            tiles [0,20] = 1;
            tiles [0,21] = 1;
            tiles [0,22] = 1;
            tiles [0,23] = 1;
            tiles [0,24] = 1;
            tiles [0,25] = 1;
            tiles [0,26] = 1;
            tiles [0,27] = 1;
            tiles [0,28] = 1;
            tiles [0,29] = 1;

            tiles [29,0] = 1;
            tiles [29,1] = 1;
            tiles [29,2] = 1;
            tiles [29,3] = 1;
            tiles [29,4] = 1;
            tiles [29,5] = 1;
            tiles [29,6] = 1;
            tiles [29,7] = 1;
            tiles [29,8] = 1;
            tiles [29,9] = 1;
            tiles [29,10] = 1;
            tiles [29,11] = 1;
            tiles [29,12] = 1;
            tiles [29,13] = 1;
            tiles [29,14] = 1;
            tiles [29,15] = 1;
            tiles [29,16] = 1;
            tiles [29,17] = 1;
            tiles [29,18] = 1;
            tiles [29,19] = 1;
            tiles [29,20] = 1;
            tiles [29,21] = 1;
            tiles [29,22] = 1;
            tiles [29,23] = 1;
            tiles [29,24] = 1;
            tiles [29,25] = 1;
            tiles [29,26] = 1;
            tiles [29,27] = 1;
            tiles [29,28] = 1;
            tiles [29,29] = 1;

            tiles [1,0] = 1;
            tiles [2,0] = 1;
            tiles [3,0] = 1;
            tiles [4,0] = 1;
            tiles [5,0] = 1;
            tiles [6,0] = 1;
            tiles [7,0] = 1;
            tiles [8,0] = 1;
            tiles [9,0] = 1;
            tiles [10,0] = 1;
            tiles [11,0] = 1;
            tiles [12,0] = 1;
            tiles [13,0] = 1;
            tiles [14,0] = 1;
            tiles [15,0] = 1;
            tiles [16,0] = 1;
            tiles [17,0] = 1;
            tiles [17,0] = 1;
            tiles [18,0] = 1;
            tiles [19,0] = 1;
            tiles [20,0] = 1;
            tiles [21,0] = 1;
            tiles [22,0] = 1;
            tiles [23,0] = 1;
            tiles [24,0] = 1;
            tiles [25,0] = 1;
            tiles [26,0] = 1;
            tiles [27,0] = 1;
            tiles [28,0] = 1;

            tiles [1,29] = 1;
            tiles [2,29] = 1;
            tiles [3,29] = 1;
            tiles [4,29] = 1;
            tiles [5,29] = 1;
            tiles [6,29] = 1;
            tiles [7,29] = 1;
            tiles [8,29] = 1;
            tiles [9,29] = 1;
            tiles [10,29] = 1;
            tiles [11,29] = 1;
            tiles [12,29] = 1;
            tiles [13,29] = 1;
            tiles [14,29] = 1;
            tiles [15,29] = 1;
            tiles [16,29] = 1;
            tiles [17,29] = 1;
            tiles [18,29] = 1;
            tiles [19,29] = 1;
            tiles [20,29] = 1;
            tiles [21,29] = 1;
            tiles [22,29] = 1;
            tiles [23,29] = 1;
            tiles [24,29] = 1;
            tiles [25,29] = 1;
            tiles [25,29] = 1;
            tiles [26,29] = 1;
            tiles [27,29] = 1;
            tiles [28,29] = 1;

            
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