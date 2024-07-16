using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     private CharacterAnimation player_anim;
    private Rigidbody myBody;
    public float walk_speed = 2f;
    public float z_speed = 1.5f;

    private float rotation_y = -90f;
    private float rotation_speed = 15f;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        player_anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
       RotatePlayer(); 
       AnimatePlayerWalk();
    }
    
    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement(){

        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.horizontal_axis)*(-walk_speed),
            myBody.velocity.y,Input.GetAxisRaw(Axis.vertical_axis)*(-z_speed));
        }
    

    void RotatePlayer()
    {
        if(Input.GetAxisRaw(Axis.horizontal_axis)>0){
            transform.rotation = Quaternion.Euler(0f,rotation_y,0f);
        }
        else if(Input.GetAxisRaw(Axis.horizontal_axis)<0){
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_y),0f);
        }
    }

    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.horizontal_axis) != 0 || Input.GetAxisRaw(Axis.vertical_axis) != 0)
       {
         player_anim.Walk(true);
         }
         else
         {
            player_anim.Walk(false);
         }

    }

}
