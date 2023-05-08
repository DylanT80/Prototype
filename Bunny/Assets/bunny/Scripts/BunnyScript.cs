using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyScript : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    public float speed = 3f;

    Vector2 movement;
    
    //camera variables
    private Camera mainCam;
    private Vector3 mousePos;

    void Start()
    {
    
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void FaceTarget()
    {
    


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        FaceTarget();
        Movement();
    }

    void Movement()
    {
        // Keep player parallel
        transform.rotation = Quaternion.identity;
        // Speed buffs
        speed = GetComponent<PlayerInfo>().speed;
        Vector3 pos = transform.position;
    
        // "w" can be replaced with any key
        // this section moves the character up
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
            
        }

        // "s" can be replaced with any key
        // this section moves the character down
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            
        }

        // "d" can be replaced with any key
        // this section moves the character right
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            animator.SetBool("FaceRight", true);
            animator.SetBool("FaceLeft", false);
            
        }

        // "a" can be replaced with any key
        // this section moves the character left
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            animator.SetBool("FaceRight", false);
            animator.SetBool("FaceLeft", true);
        }
        transform.position = pos;
    } 
}
