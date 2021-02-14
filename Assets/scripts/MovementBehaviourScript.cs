using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class MovementBehaviourScript : MonoBehaviour
{
    public int MonsterTick = 0; 
    public int FakeAngle = 0;
    Vector3 OgPos, TrgtPos;
    private float MovTime = 0.6F;
    private bool isMoving = false;
    private IEnumerator MovePlayer (Vector3 direction)
        {
            isMoving = true;
            float ElTime = 0;
            OgPos = transform.position;
            TrgtPos = OgPos + direction;
            while (ElTime < MovTime)
                {
                    transform.position = Vector3.Lerp(OgPos, TrgtPos, (ElTime / MovTime));
                    ElTime += Time.deltaTime;
                    yield return null;
                }
                transform.position = TrgtPos;
            isMoving = false;
        }

    //int RotDelay = 60;

    void MovementCheck ()
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isMoving == false) 
                {
                    MonsterTick++;
                    if (FakeAngle == 0)
                        {   
                            StartCoroutine(MovePlayer(Vector3.forward));
                        } 
                    if (FakeAngle == 90)
                        {
                            StartCoroutine(MovePlayer(Vector3.right));
                        }
                    if (FakeAngle == -90)
                        {
                            StartCoroutine(MovePlayer(Vector3.left));
                        } 
                    if (FakeAngle == 180)
                        {
                            StartCoroutine(MovePlayer(Vector3.back));
                        } 
                    if (FakeAngle == -180)
                        {
                            StartCoroutine(MovePlayer(Vector3.back));
                        } 
                }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    FakeAngle = FakeAngle -90;
                    Quaternion rotationYa = Quaternion.AngleAxis(-1, Vector3.up);
                    for (int rotSmooth = 0; rotSmooth < 90; rotSmooth++)
                        {
                            transform.rotation*= rotationYa;
                            
                            //await Task.Delay(RotDelay);
                        }     
                    
                }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    FakeAngle = FakeAngle + 90;
                    Quaternion rotationYd = Quaternion.AngleAxis(1, Vector3.up);
                    for (int rotSmooth = 0; rotSmooth < 90; rotSmooth++)
                        {
                            transform.rotation*=rotationYd;
                            
                            //Sleep(80);
                        }    
                }

            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isMoving == false)
                {
                    MonsterTick++;
                    if (FakeAngle == 0)
                        {
                            StartCoroutine(MovePlayer(Vector3.back));
                        } 
                    if (FakeAngle == 90)
                        {
                            StartCoroutine(MovePlayer(Vector3.left));
                        }
                    if (FakeAngle == -90)
                        {
                            StartCoroutine(MovePlayer(Vector3.right));
                        } 
                    if (FakeAngle == 180)
                        {
                            StartCoroutine(MovePlayer(Vector3.forward));
                        } 
                    if (FakeAngle == -180)
                        {
                            StartCoroutine(MovePlayer(Vector3.forward));
                        }
                    
                }
        }
    void Update()
        {
            MovementCheck ();
            if (FakeAngle == 270)
                {
                    FakeAngle = -90;
                }
        
            if  (FakeAngle == -270)  
                {
                    FakeAngle = 90;
                }

        }
}