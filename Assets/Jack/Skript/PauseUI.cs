using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject PauseMenu;

    public static bool GamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Title screen");
    }
}
