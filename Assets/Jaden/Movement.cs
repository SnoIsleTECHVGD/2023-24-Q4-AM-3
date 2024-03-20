using System.Collections;
using System.Collections.Generic;using UnityEngine;
public class Movement:MonoBehaviour
{
    public float speed,dashCooldown;
    public bool dashing, canMove;
    private Vector2 movement2;
    private Rigidbody2D rb;
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        if (canMove)
        {
        movement2.x = Input.GetAxisRaw("Horizontal");
        movement2.y = Input.GetAxisRaw("Vertical");
        movement2.Normalize();

        rb.velocity = movement2 * speed;
        }
    }
    private IEnumerator Dash()
    {
        dashing = true;
        canMove = false;
        rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y * 2);
        yield return new WaitForSeconds(dashCooldown);
        canMove = true;
        dashing = false;    
    }
}