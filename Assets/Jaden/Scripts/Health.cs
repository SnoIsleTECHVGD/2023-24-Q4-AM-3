using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public GameObject sliderGameObject;
    public bool hasSlider;
    private Slider slider;
    private void Start()
    {
        
        if (sliderGameObject == null)
            hasSlider = false;
        else
        {
            slider = sliderGameObject.GetComponent<Slider>();
            hasSlider = true;
            slider.maxValue = health;
            slider.value = health;
        }
    }
    void Update()
    {
        CheckDie();
        if (hasSlider)
            slider.value = health;

    }
    void CheckDie()
    {
        if(health <= 0)
        {
            if (name == "Player") 
            {
                SceneManager.LoadScene("Ded");
            } else
            {
                if (hasSlider)
                    Destroy(sliderGameObject);
                Destroy(gameObject);
            }
        }
    }
}
