using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public Slider slider;
    public bool isPlayer;
    private void Start()
    {
        if (slider == null)
            isPlayer = false;
        else
        {
            isPlayer = true;
            slider.maxValue = health;
            slider.value = health;
        }
    }
    void Update()
    {
        CheckDie();
        if (isPlayer)
            slider.value = health;

    }
    void CheckDie()
    {
        if(health <= 0)
        {
            if (name == "Player") 
            {
                SceneManager.LoadScene("Jack");
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
