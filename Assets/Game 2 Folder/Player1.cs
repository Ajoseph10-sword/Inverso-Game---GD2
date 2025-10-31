using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //These are the player's Variables, the raw info that defines them

    //The Rigidbody2D is a component that gives the player physics, and is what we use to move
    public Rigidbody2D RB;
    public Collider2D Coll;

    //TextMeshPro is a component that draws text on the screen.
    //We use this one to show our score.
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI timetext;
    //This will control how fast the player moves
    public float Speed = 4;
    public float Jumpy = 10;
    public float Grav = 10;
    //Variables I use to track my state
    public bool OnGround = false;
    public bool FacingLeft = false;
    //If this is over 0, I'm stunned and can't move
    public float Stunned = 0;
 

    //Start automatically gets triggered once when the objects turns on/the game starts
    void Start()
    {

        //Set our rigidbody's gravity to match our stats 
        RB.gravityScale = Grav;
        Physics2D.gravity = new Vector2(0, -4.38f);
    }

    public bool CanJump()
    {
        return OnGround;
    }
    //Update is a lot like Start, but it automatically gets triggered once per frame
    //Most of an object's code will be called from Update--it controls things that happen in real time
    void Update()
    {
        //The code below controls the character's movement
        //First we make a variable that we'll use to record how we want to move
        Vector2 vel = new Vector2(0, RB.linearVelocity.y);


        //If I collide with something solid, mark me as being on the ground
        OnGround = true;
        //Then we use if statement to figure out what that variable should look like

        //If I hold the right arrow key, the player should move right. . .
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
            FacingLeft = false;
        }
        //If I hold the left arrow, the player should move left. . .
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
            FacingLeft = true;
        }
        //If I hold the up arrow, the player should move up. . .
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Jumpy;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Physics2D.gravity = new Vector2(0, 4.38f);
        }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                vel.y = -Jumpy;
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
            vel.x = -Speed;
            }

            if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
            else if (Input.GetKey(KeyCode.S))
            {
                Physics2D.gravity = new Vector2(0, -3.81f);
            }
        

            //Finally, I take that variable and I feed it to the component in charge of movement
            RB.linearVelocity = vel;

        Timer90 -= Time.deltaTime;
        timetext.text = "Time: " + Timer90.ToString("0.0");
        if (Timer90 <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }

        if (transform.position.y < -4)
        {
            //Give me a game over
            SceneManager.LoadScene("Game Over");
            
        }

    }

    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)

    {
        //Bump into the goal zone
        //If it does...
        golazo GOAL = other.gameObject.GetComponent<golazo>();
        if (other.gameObject.CompareTag("GOAL"))
        {
            //Run your 'you win' function!
            SceneManager.LoadScene("Win Game");
        }
       
        //This checks to see if the thing you bumped into has the CoinScript script on it
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        //If it does, run the code block belows
        if (coin != null)
        {
            //Tell the coin that you bumped into them so they can self destruct or whatever
            coin.GetBumped();
            //Make your score variable go up by one. . .
      

        }
        hoodbending Hazard = other.gameObject.GetComponent<hoodbending>();
        if (other.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene("Game Over");
        }
        hoodbending BadMan = other.gameObject.GetComponent<hoodbending>();
        if (other.gameObject.CompareTag("BadMan"))
        {
            SceneManager.LoadScene("Game Over");
        }



    }

 
    //If this function is called, the player character dies. The game goes to a 'Game Over' screen.
    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }
    public float Timer90 = 999;
    
}
