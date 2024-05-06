using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monologue : MonoBehaviour
{
    public GameObject monologue1;
    public GameObject monologue2;
    public GameObject monologue3;
    public GameObject monologue4;
    public GameObject monologue5;
    public GameObject pressE;
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Movement>().enabled = false;
            collision.gameObject.GetComponent<PlayerAttack>().enabled = false;
            pressE.SetActive(true);
            monologue1.SetActive(true);
            yield return waitForKeyPress(KeyCode.E);
            monologue1.SetActive(false);
            monologue2.SetActive(true);
            yield return waitForKeyPress(KeyCode.E);
            monologue2.SetActive(false);
            monologue3.SetActive(true);
            yield return waitForKeyPress(KeyCode.E);
            monologue3.SetActive(false);
            monologue4.SetActive(true);
            yield return waitForKeyPress(KeyCode.E);
            monologue4.SetActive(false);
            monologue5.SetActive(true);
            yield return waitForKeyPress(KeyCode.E);
            monologue5.SetActive(false);
            pressE.SetActive(false);
            collision.gameObject.GetComponent<Movement>().enabled = true;
            collision.gameObject.GetComponent<PlayerAttack>().enabled = true;
        }
        IEnumerator waitForKeyPress(KeyCode key)
        {
            bool done = false;
            while (!done) // essentially a "while true", but with a bool to break out naturally
            {
                if (Input.GetKeyDown(key))
                {
                    done = true; // breaks the loop
                }
                yield return null; // wait until next frame, then continue execution from here (loop continues)
            }

            // now this function returns
        }

    }
}
