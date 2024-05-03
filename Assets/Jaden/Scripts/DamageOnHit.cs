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
        if (collision.gameObject.CompareTag("Entity") && collision.gameObject.layer != ignore )
        {
            if(collision.gameObject.GetComponent<Health>().isImmune == false ) 
            {
                player = collision.gameObject;
                collision.gameObject.GetComponent<Health>().health -= damage;
                collision.gameObject.GetComponent<Health>().isImmune = true;
                collision.gameObject.GetComponent<Animator>().SetBool("IsInvincible", true);
                player.GetComponent<Health>().RevokeAfterDelay();
            }
        }
    }
}
