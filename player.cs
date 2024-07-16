using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

public Animator anim;
public float jumpPower = 1000f;
Rigidbody2D myRigidbody;
bool isGround = false;
bool isGameover = false;
public float xPos = -11f;
    void Start()
    {
      myRigidbody = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      
    }

    void FixedUpdate()
    {
       

        if(isGameover) return ;
        if(transform.position.x < xPos)
{
    Gameover();
}


        if(Input.GetKey(KeyCode.Space) && isGround )
        {
           
            myRigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime * myRigidbody.mass * myRigidbody.gravityScale);
          
        anim.SetBool("jump",true);
     
        }

         if(Input.GetKey(KeyCode.DownArrow) && isGround )
        {
            
            myRigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime * myRigidbody.mass * myRigidbody.gravityScale);
        anim.SetBool("MoveDown",true);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow) && isGround)
        {
           anim.SetBool("Movedown",false); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("jump",false);
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
        }
       if(collision.collider.tag == "challenges")
        {
            Gameover();
        }

    }

      private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("jump",true);
        if(collision.collider.tag == "Ground")
        {
            isGround = false;
        }
    }
      private void OnCollisionStay2D(Collision2D collision)
    {
        anim.SetBool("jump",false);
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
        }
    }
    public void Gameover()
    {
        myRigidbody.gravityScale = 0f;
        isGameover = true;
      
        FindObjectOfType<challengescroller>().Gameover();
        FindObjectOfType<scroll>().xVel = 0f;
       FindObjectOfType<scrollclouds>().xVel = 0f;
       anim.SetBool("GameOver",true);
       FindObjectOfType<Score>().GameOver();
       FindObjectOfType<BirdScroll>().Gameover();
    }
}
