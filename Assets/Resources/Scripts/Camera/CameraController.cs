using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //allows the camera movement
    private bool doMovement = true;
    //camera speed
    public float panSpeed = 30f;
     
    void Update () {
        //if(GameManager.gameIsOver){
        //    this.enabled = false;
        //    return;
        //}

        if(Input.GetKeyDown("m")){
            doMovement = !doMovement;
        }

        if(!doMovement){
            return;
        }

        //camera movement up
        if(Input.GetKey("w")){
            
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment down
        if(Input.GetKey("s")){
            
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment left
        if(Input.GetKey("a")){
            
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment right
        if(Input.GetKey("d")){
            
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
