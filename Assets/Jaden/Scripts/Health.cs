using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float health;
    public GameObject sliderGameObject;
    public bool hasSlider, isImmune;
    private Slider slider;
    public Animator animator;
    public AnimationClip clip;
    public AnimationClip clip2;
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
    public void RevokeInvincibilityFrames()
    {
        GetComponent<Animator>().SetBool("IsInvincible", false);
        GetComponent<Health>().isImmune = false;
    }
    public void RevokeAfterDelay()
    {
        Invoke(nameof(RevokeInvincibilityFrames), clip2.length);
    }
}
