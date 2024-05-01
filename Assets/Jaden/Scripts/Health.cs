using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Health : MonoBehaviour
{
    public float health;
    public GameObject sliderGameObject;
    public bool hasSlider;
    private Slider slider;
    public Animator animator;
    public AnimationClip clip;
    public GameObject weapon;
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
        StartCoroutine(CheckDie());
        if (hasSlider)
            slider.value = health;

    }
    IEnumerator CheckDie()
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
                animator.SetBool("IsDead", true);
                Destroy(weapon);
                yield return new WaitForSeconds(clip.length);
                Destroy(gameObject);
            }
        }
    }
}
