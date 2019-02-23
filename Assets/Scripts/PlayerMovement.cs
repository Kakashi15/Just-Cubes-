using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public float forceSpeed;
    public float jumpForce;
    public float rayLength;
    public float timer;

    public bool shrink;
    public bool giantCube;
    public bool jump;
    public bool Grounded;
    

    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        rb.velocity = new Vector3(forceSpeed, 0f, 0f);
        CheckIfGrounded();
        Jump();
    }
    void Update()
    {
        TouchControls();
    //Check for Touch
        if (!shrink)
        {
            if (CrossPlatformInputManager.GetButtonDown("Shrink"))
            {
                shrink = true;
            }
            Debug.Log("Pressed");
        }
//Shrink the Player
        if (shrink)
        {
            SizeResize();
            Invoke("delay", 2f);
            Debug.Log("Shrink");
        }
        else if(!shrink)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("Normal");
        }
    }
    void SizeResize()
    { 
      transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);     
    }
    void delay()
    {
        shrink = false;
    }
    void Jump()
    {
        if (Grounded && jump)
        {
            //rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
        }
        //Grounded = false;
    }

    void TouchControls()
    {
       if(CrossPlatformInputManager.GetButtonDown("Jump"))
       {
            jump = true;
       }
       else
       {
            jump = false;
       }     
    }
    void CheckIfGrounded()
    {
        Ray ray = new Ray(new Vector3(transform.position.x,transform.position.y-transform.localScale.y/2 + 0.1f,transform.position.z),Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            Vector3 distance = ray.origin - hit.point;
            if(distance.y <= rayLength)
            {
                Debug.DrawLine(ray.origin, hit.point,Color.red);
                Grounded = true;
            }
            else
            {
                Debug.DrawLine(ray.origin, hit.point,Color.blue);
                Grounded = false;
            }
        }
    }
}
