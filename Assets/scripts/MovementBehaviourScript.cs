using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class MovementBehaviourScript : MonoBehaviour
{
    bool IsColliding = false;

    public Vector3 PlayerOgPos, PlayerTrgtPos;
    private float MovTime = 0.2F;
    private bool isMoving = false;
    private IEnumerator MovePlayer (Vector3 direction)
        {
            if (IsColliding == false)
                {
                    isMoving = true;
                    float ElTime = 0;
                    PlayerOgPos = transform.position;
                    PlayerTrgtPos = PlayerOgPos + direction;
                    while (ElTime < MovTime)
                        {
                            transform.position = Vector3.Lerp(PlayerOgPos, PlayerTrgtPos, (ElTime / MovTime));
                            ElTime += Time.deltaTime;
                            yield return null;
                        }
                    transform.position = PlayerTrgtPos;
                    isMoving = false;
                }
            else
                {
                    IsColliding = false;
                }

        }

    public int FakeAngle = 0;
    private float RotTime = 0.4F;
    private bool isRotating = false;
    private IEnumerator RotateCamera (float rotationY)
        {
            isRotating = true;
            //Quaternion RotationQuantizer = Quaternion.AngleAxis(-90, Vector3.up);
            float ElTime = 0;
            Quaternion OgRot = transform.rotation;
            Quaternion TrgtRot = Quaternion.AngleAxis (rotationY, Vector3.up);
            while (ElTime < RotTime)
                {
                    transform.rotation = Quaternion.Lerp(OgRot, TrgtRot, (ElTime / RotTime));
                    ElTime += Time.deltaTime;
                    yield return null;
                }
                //NOTE: NEED TO FIX IMEPRFECT ROTATION
                //transform.rotation *= Quaternion.AngleAxis(rotationY, Vector3.up);
            isRotating = false;
        }

    void MovementCheck ()
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isMoving == false) 
                {
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

            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isRotating == false)
                {
                    FakeAngle = FakeAngle -90;
                    StartCoroutine(RotateCamera(FakeAngle));
                    
                }

            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isRotating == false)
                {
                    FakeAngle = FakeAngle + 90;
                    StartCoroutine(RotateCamera(FakeAngle));
                }

            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isMoving == false)
                {
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
    void Start()
        {
        }
    
    void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "wall")
                {
                    
                    IsColliding = true;
                    UnityEngine.Debug.Log("Do something here");
                }
            else
                {
                    IsColliding = false;
                }
        }
    
}