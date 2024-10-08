using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float Move;

    public float Speed;

    public float jump;

    public Vector2 boxSize;

    public float castDistance;

    public LayerMask groundLayer;

    bool grounded;


    private Animator anim;

    public 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Move * Speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
        }

        if(Move != 0)
        {
            anim.SetBool("isRunning?", true);
        }
        else
        {
            anim.SetBool("isRunning?", false);
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.CompareTag("Ground"))
    //    {
    //        Vector3 normal = other.GetContact(0).normal;
    //        if(normal == Vector3.up)
    //        {
    //            grounded = true;
    //        }
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = false;
    //    }
    //}
}