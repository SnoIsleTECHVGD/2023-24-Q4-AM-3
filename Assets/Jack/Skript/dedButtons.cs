using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dedButtons : MonoBehaviour
{
    void Update()
    {
        if (1 == 2)
        {
            //Destroy(gameObject);
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("Tutorial Level");
    }
    public void Title()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
