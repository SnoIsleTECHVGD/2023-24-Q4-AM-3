using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsButtons : MonoBehaviour
{
    public GameObject wholeThing;
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;
    public GameObject img5;
    public GameObject backButt;
    public GameObject quitButt;
    public GameObject[] images;
    public void LoadCredit1()
    {
        StartCoroutine(FadeImage(false, img1));
        StartCoroutine(FadeImage(false, backButt));
        StartCoroutine(FadeImage(true, quitButt));
    }
    public void LoadCredit2()
    {
        StartCoroutine(FadeImage(false, img2));
        StartCoroutine(FadeImage(false, backButt));
        StartCoroutine(FadeImage(true, quitButt));
    }
    public void LoadCredit3()
    {
        StartCoroutine(FadeImage(false, img3));
        StartCoroutine(FadeImage(false, backButt));
        StartCoroutine(FadeImage(true, quitButt));
    }
    public void LoadCredit4()
    {
        StartCoroutine(FadeImage(false, img4));
        StartCoroutine(FadeImage(false, backButt));
        StartCoroutine(FadeImage(true, quitButt));
    }
    public void LoadCredit5()
    {
        StartCoroutine(FadeImage(false, img5));
        StartCoroutine(FadeImage(false, backButt));
        StartCoroutine(FadeImage(true, quitButt));
    }
    public void Back()
    {
        GameObject[] images = new GameObject[] { img1, img2, img3, img4, img5 };
        int stupid = 0;
        foreach (GameObject image in images)
        {
            stupid++;
            if(image.GetComponent<Image>().enabled)
            {
                StartCoroutine(FadeImage(true, image));
                StartCoroutine(FadeImage(true, backButt));
                StartCoroutine(FadeImage(false, quitButt));
            }
        }
    }

    IEnumerator FadeImage(bool fadeAway, GameObject img)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            img.SetActive(false);
        }
        // fade from transparent to opaque
        else
        {

            img.SetActive(true);
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Title Screen");
    }
}