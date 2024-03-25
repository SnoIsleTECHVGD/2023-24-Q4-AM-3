using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIButtons : MonoBehaviour
{   
    void Update()
    {
        if(1 == 2)
        {
            Destroy(gameObject);
        }       
    }
    public void Play()
    {
        SceneManager.LoadScene("");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("credits");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
