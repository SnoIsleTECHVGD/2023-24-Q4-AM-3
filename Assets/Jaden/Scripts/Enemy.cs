using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player, weapon;
    public float speed, attackDistance, sightDistance;
    Transform target;
    Vector3 newTargetPosition;
    Rigidbody2D rb2d;
    public bool attacking = false, hit; 
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = player.GetComponent<Transform>();
        weapon.GetComponent<SpriteRenderer>().enabled = false;
        weapon.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        //print("Distance to other: " + distance);
        if (MathF.Abs(distance) <= sightDistance)
        {
            if(target.position.x >= 0)
            {
                newTargetPosition.x = target.position.x - 1;
            } else
            {
                newTargetPosition.x = target.position.x - 1;
            }
            if(target.position.y >= 0)
            {
                newTargetPosition.y = target.position.y - 1;
            } else
            {
                newTargetPosition.y = target.position.y - 1;
            }
            hit = Physics2D.Raycast(transform.position, newTargetPosition, Vector3.Distance(transform.position, newTargetPosition), LayerMask.GetMask("Walls"));
            if (hit)
                Debug.Log("hi");
            if (!hit)
            { 
                print("stupid");
                Vector3 localPosition = target.position - transform.position;
                localPosition = localPosition.normalized;
                if (MathF.Abs(distance) <= attackDistance)
                {
                    if (!attacking)
                        StartCoroutine(Attack());
                }
                else
                {
                    rb2d.transform.transform.transform.transform.transform.transform.transform.transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
                }
                
            }
        }
        if(attacking)
        {
            weapon.transform.RotateAround(transform.position, Vector3.back, 720 * Time.deltaTime);
        }
    }
    IEnumerator Attack()
    {
        attacking = true;
        weapon.GetComponent<SpriteRenderer>().enabled = true;
        weapon.GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(1);
        weapon.GetComponent<SpriteRenderer>().enabled = false;
        weapon.GetComponent<CapsuleCollider2D>().enabled = false;
        attacking = false;
        counter = 0;
    }
}
