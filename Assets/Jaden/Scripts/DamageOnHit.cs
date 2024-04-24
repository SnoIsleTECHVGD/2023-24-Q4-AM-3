using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public int damage;
    public LayerMask ignore;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Entity") && collision.gameObject.layer != ignore)
        {
            collision.gameObject.GetComponent<Health>().health -= damage;
            //StartCoroutine(InvincibilityFrames);
        }
    }

    private IEnumerator InvincibilityFrames()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
    }
}
