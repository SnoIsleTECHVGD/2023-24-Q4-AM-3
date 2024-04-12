using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool swinging;
    OtherMovement movement;
    public Vector3 attackPosition;
    public float attackRadius, damage;
    public int maxObjectsHit = 5;
    public Collider2D[] objectsHit;
    public LayerMask selectObjectsToHit;
    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<OtherMovement>();
        objectsHit = new Collider2D[maxObjectsHit];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && !swinging)
        {
            if (movement.LastMovement == 0)
            {
                attackPosition = transform.position + new Vector3(0, .5f, 0);
            }
            else if (movement.LastMovement == 1)
            {
                attackPosition = transform.position + new Vector3(.5f, 0, 0);
            }
            else if (movement.LastMovement == 2)
            {
                attackPosition = transform.position + new Vector3(0, -.5f, 0);
            }
            else
            {
                attackPosition = transform.position + new Vector3(-.5f, 0, 0);
            }
            attackPosition = transform.position + new Vector3(0, 0, 0);
            Physics2D.OverlapCircleNonAlloc(attackPosition, attackRadius, objectsHit, selectObjectsToHit);
            StartCoroutine(swing());

            if (objectsHit.Length > 0)
            {
                foreach (Collider2D hit in objectsHit)
                {
                    try
                    {
                        if (hit.GetComponent<Health>() != null)
                        {
                            hit.GetComponent<Health>().health -= damage;
                        }
                    } catch (Exception e)
                    {

                    }
                }
            }
        }
    }

    public IEnumerator swing()
    {
        swinging = true;
        yield return new WaitForSeconds(.25f);
        swinging = false;
    }
}

