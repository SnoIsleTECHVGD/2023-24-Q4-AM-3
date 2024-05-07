using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public int damage;
    public LayerMask ignore;
    private GameObject player;
    public AnimationClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Entity") || collision.gameObject.CompareTag("Player")) && collision.gameObject.layer != ignore)
        {
            if(collision.gameObject.GetComponent<Health>().isImmune == false ) 
            {
                collision.gameObject.GetComponent<Health>().DealDamage(damage, gameObject);
            }
        }
    }
}
