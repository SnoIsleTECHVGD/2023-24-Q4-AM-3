using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDie();
    }
    void CheckDie()
    {
        if(health <= 0)
        {
            if(name == "Player")
            {
                SceneManager.LoadScene("Jack");
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
