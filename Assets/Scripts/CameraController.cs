using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //allows the camera movement
    private bool doMovement = true;
    //camera speed
    public float panSpeed = 30f;

    public float panBorderThickness = 10f;
    //limit for the movement
    public float minY = 10f;
    public float maxY = 80f;
     
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
        if(Input.GetKey("w") || Input.mousePosition.y <= panBorderThickness){
            
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment down
        if(Input.GetKey("s") || Input.mousePosition.y >= Screen.height - panBorderThickness){
            
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment left
        if(Input.GetKey("a") || Input.mousePosition.x >= Screen.width - panBorderThickness){
            
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment right
        if(Input.GetKey("d") || Input.mousePosition.x <= panBorderThickness){
            
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
