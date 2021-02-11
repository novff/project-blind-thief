using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;
//public float smoothTime = 0.3F;
            //private Vector3 velocity = Vector3.zero;
            //public float PRotation = 0
            //Vector3 rot = (0, PRotation, 0)
public class MovementBehaviourScript : MonoBehaviour

{
    public int MonsterTick = 0; 
    public int kastyl = 0;
    //public float speed = 0.2f;
    void Start() 
        {
            
        }

    void MovementCheck ()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
                {
                    MonsterTick++;
                    if (kastyl == 0)
                        {
                            transform.position += Vector3.forward;
                        } 
                    if (kastyl == 90)
                        {
                            transform.position += Vector3.right;
                        }
                    if (kastyl == -90)
                        {
                            transform.position += Vector3.left;
                        } 
                    if (kastyl == 180)
                        {
                            transform.position += Vector3.back;
                        } 
                    if (kastyl == -180)
                        {
                            transform.position += Vector3.back;
                        } 
                }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    kastyl = kastyl -90;
                    Quaternion rotationYw = Quaternion.AngleAxis(-90, Vector3.up);
                    transform.rotation*= rotationYw;     
                    //transform.Rotate(Vector3.up, -90);
                    
                }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    kastyl = kastyl + 90;
                    Quaternion rotationYs = Quaternion.AngleAxis(90, Vector3.up);
                    transform.rotation*=rotationYs; 
                    //transform.Rotate(Vector3.up, 90);
                }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    MonsterTick++;
                    if (kastyl == 0)
                        {
                            transform.position += Vector3.back;
                        } 
                    if (kastyl == 90)
                        {
                            transform.position += Vector3.left;
                        }
                    if (kastyl == -90)
                        {
                            transform.position += Vector3.right;
                        } 
                    if (kastyl == 180)
                        {
                            transform.position += Vector3.forward;
                        } 
                    if (kastyl == -180)
                        {
                            transform.position += Vector3.forward;
                        }
                    
                }
        }

    // Update is called once per frame
    void Update()
        {
            MovementCheck ();
            if (kastyl == 270)
                {
                    kastyl = -90;
                }
        
            if  (kastyl == -270)  
                {
                    kastyl = 90;
                }

        }
}