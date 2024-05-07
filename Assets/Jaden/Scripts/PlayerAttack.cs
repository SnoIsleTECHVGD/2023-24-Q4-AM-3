using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool swinging;
    Movement movement;
    public Vector3 attackPosition;
    public float attackRadius, damage;
    public int maxObjectsHit = 5;
    public Collider2D[] objectsHit;
    public LayerMask selectObjectsToHit;
    public AnimationClip clip;
    public AnimationClip tpClip;
    [SerializeField] private List<Vector3> randomPos;
    private Vector3 startingPos;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<Movement>();
        objectsHit = new Collider2D[maxObjectsHit];
        startingPos = boss.transform.position;
        randomPos.AddRange(new List<Vector3>() { startingPos + new Vector3(4, 7), startingPos + new Vector3(-5, 8),
        startingPos + new Vector3(-3, -6), startingPos + new Vector3(4, -6), startingPos});
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && !swinging)
        {
            GetComponent<Animator>().SetBool("IsAttacking", true);
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
            Physics2D.OverlapCircleNonAlloc(attackPosition, attackRadius, objectsHit = new Collider2D[maxObjectsHit], selectObjectsToHit);
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
                            if (hit.GetComponent<Boss>() != null)
                                boss.GetComponent<Animator>().SetBool("IsTeleporting", true);
                                Invoke(nameof(RandomizePos), tpClip.length);
                        }
                    } catch (Exception)
                    {

                    }
                }
                
            }
        }
    }

    public IEnumerator swing()
    {
        swinging = true;
        yield return new WaitForSeconds(clip.length);
        swinging = false;
        GetComponent<Animator>().SetBool("IsAttacking", false);
    }
    public void RandomizePos()
    {
        int g = UnityEngine.Random.Range(0, 5);
        boss.transform.position = randomPos[g];
        boss.GetComponent<Animator>().SetBool("IsTeleporting", false);
    }
}

