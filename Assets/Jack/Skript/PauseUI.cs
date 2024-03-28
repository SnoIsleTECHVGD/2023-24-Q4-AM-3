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
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void Settings()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Settings");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title screen");
    }
}
