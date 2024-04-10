using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public float speed, dashCooldown, cooldown, LastMovement = 0;
    public bool dashing;
    public bool canMove = true;
    private Vector2 movement2;
    private Rigidbody2D rb;
    private void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        if (canMove)
        {
            if(!(Time.timeScale == 0f))
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    GetComponent<Animator>().SetBool("IsWalking", true);
                    GetComponent<Animator>().SetInteger("Direction", 3);
                    LastMovement = 0;
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    GetComponent<Animator>().SetBool("IsWalking", true);
                    GetComponent<Animator>().SetInteger("Direction", 2);
                    LastMovement = 1;
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    GetComponent<Animator>().SetBool("IsWalking", true);
                    GetComponent<Animator>().SetInteger("Direction", 1);
                    LastMovement = 2;
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    GetComponent<Animator>().SetBool("IsWalking", true);
                    GetComponent<Animator>().SetInteger("Direction", 0);
                    LastMovement = 3;
                }
                else
                {
                    GetComponent<Animator>().SetBool("IsWalking", false);
                }
                movement2.x = Input.GetAxisRaw("Horizontal");
                movement2.y = Input.GetAxisRaw("Vertical");
                movement2.Normalize();
                rb.velocity = movement2 * speed;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(cooldown <= 0 && dashing == false)
            {
               cooldown = dashCooldown;
               StartCoroutine(Dash());
            }
        }
        cooldown -= .01f;
    }
    private IEnumerator Dash()
    {
        dashing = true;
        canMove = false;
        rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y * 2);
        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 2);
        canMove = true;
        dashing = false;
    }
}