using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player, weapon;
    public float speed, attackDistance, sightDistance;
    Transform target;
    public bool attacking = false; 
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
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
            print("stupid");
            Vector3 localPosition = target.position - transform.position;
            localPosition = localPosition.normalized;
            if (MathF.Abs(distance) >= attackDistance)
            {
                if (!attacking)
                    StartCoroutine(Attack());
            }
            else
            {
                transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
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
