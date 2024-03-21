using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public float speed, dashCooldown, cooldown;
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
            movement2.x = Input.GetAxisRaw("Horizontal");
            movement2.y = Input.GetAxisRaw("Vertical");
            movement2.Normalize();
            rb.velocity = movement2 * speed;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(cooldown <= 0)
            {
               StartCoroutine(Dash());
            }
        }
        cooldown -= .01f;
    }
    private IEnumerator Dash()
    {
        cooldown = dashCooldown;
        dashing = true;
        canMove = false;
        rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y * 2);
        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 2);
        canMove = true;
        dashing = false;
    }
}