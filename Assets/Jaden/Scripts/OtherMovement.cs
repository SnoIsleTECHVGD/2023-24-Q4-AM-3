using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OtherMovement : MonoBehaviour
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
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                LastMovement = 0;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                LastMovement = 1;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                LastMovement = 2;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                LastMovement = 3;
            }
            movement2.x = Input.GetAxisRaw("Horizontal");
            movement2.y = Input.GetAxisRaw("Vertical");
            movement2.Normalize();
            rb.velocity = movement2 * speed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (cooldown <= 0 && dashing == false)
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
        yield return new WaitForSecondsRealtime(.5f);
        rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 2);
        canMove = true;
        dashing = false;
    }
}