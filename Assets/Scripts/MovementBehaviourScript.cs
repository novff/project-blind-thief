﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MovementBehaviourScript : MonoBehaviour
{
    private IEnumerator CheckTheFloor (Vector3 downVector)
    {
        RaycastHit Shit;
        Ray LoadNextLvlRay = new Ray(transform.position,  downVector);
        if (Physics.Raycast(LoadNextLvlRay, out Shit, 2F))
            {
                UnityEngine.Debug.Log("aaaaaaa");
                if (Shit.collider.gameObject.name == "End(Clone)")
                    {
                        UnityEngine.Debug.Log("bbbbbbb");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        yield return null;
                    }
                if (Shit.collider.gameObject.name == "Abyss(Clone)")
                    {
                        UnityEngine.Debug.Log("bbbbbbb");
                        //ПОЧЕМУ ЭТА ЕБАНАЯ ХУЙНЯ НЕ РАБОТАЕТ БЛЯИТЬ СУККА БЫОВШПОЫВЛЗАОРГШЩРКАМКАМ
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        yield return null;
                    }
            }
    }
//smooth movement coroutine and variables
    bool IsColliding = false;
    public Vector3 PlayerOgPos, PlayerTrgtPos, RcColDir, direction;
    private float MovTime = 0.5F;
    private bool isMoving = false;
    private IEnumerator MovePlayerForward (Vector3 direction)
        {
            RaycastHit hit;
            Ray ColRay = new Ray(transform.position,  direction);
            if (Physics.Raycast(ColRay, out hit, 0.5F))
                {
                    if (hit.collider.gameObject.name == "Wall(Clone)")
                        {
                            IsColliding = true;
                            FindObjectOfType<AudioManager>().Play("HeadWall");
                        }
                    else
                        {
                            IsColliding = false;
                        }
                }
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
        }
//smooth rotation coroutine and variables
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
                //NOTE: NEED TO FIX IMEPRFECT ROTATION afaik comment bellow doesnt work 
                //transform.rotation *= Quaternion.AngleAxis(rotationY, Vector3.up); is a way to do this without smoothness
            isRotating = false;
        }
//lines  a and d start rotation coroutine and also change fake angles for tank like movement
//i could use switch cases for fake angle check in movement but im to lazy to do that and there's no way im rewriting this shit
//fake angle is a workaround for afaik no way to get transfrom.rotation in a useable way
    void MovementCheck ()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isMoving == false) 
                {
                    FindObjectOfType<AudioManager>().Play("PlayerStep");
                    StartCoroutine(CheckTheFloor(Vector3.down));
                    if (FakeAngle == 0)
                        {   
                            StartCoroutine(MovePlayerForward(Vector3.forward));
                        } 
                    if (FakeAngle == 90)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.right));
                        }
                    if (FakeAngle == -90)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.left));
                        } 
                    if (FakeAngle == 180)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.back));
                        } 
                    if (FakeAngle == -180)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.back));
                        } 
                }
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isRotating == false)
                {
                    StartCoroutine(CheckTheFloor(Vector3.down));
                    FakeAngle = FakeAngle -90;
                    StartCoroutine(RotateCamera(FakeAngle));
                }
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isRotating == false)
                {
                    StartCoroutine(CheckTheFloor(Vector3.down));
                    FakeAngle = FakeAngle + 90;
                    StartCoroutine(RotateCamera(FakeAngle));
                }
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isMoving == false)
                {
                    FindObjectOfType<AudioManager>().Play("PlayerStep");
                    StartCoroutine(CheckTheFloor(Vector3.down));
                    if (FakeAngle == 0)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.back));
                        } 
                    if (FakeAngle == 90)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.left));
                        }
                    if (FakeAngle == -90)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.right));
                        } 
                    if (FakeAngle == 180)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.forward));
                        } 
                    if (FakeAngle == -180)
                        {
                            StartCoroutine(MovePlayerForward(Vector3.forward));
                        }
                }
        }
//this one updates every frame and calls for movement voids
    void Update()
        {
//raycast collision attached way to rotate the ray along with the player instance
            if (FakeAngle == 0)
                    {
                        RcColDir = Vector3.forward;
                    } 
            if (FakeAngle == 90)
                    {
                        RcColDir = Vector3.right;
                    }
            if (FakeAngle == -90)
                    {
                        RcColDir = Vector3.left;
                    } 
                if (FakeAngle == 180)
                    {
                        RcColDir = Vector3.back;  
                    } 
                if (FakeAngle == -180)
                    {
                        RcColDir = Vector3.back; 
                    }
            MovementCheck ();
//fake angle reset for better management
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