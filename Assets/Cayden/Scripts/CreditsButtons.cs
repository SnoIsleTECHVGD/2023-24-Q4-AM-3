using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButtons : MonoBehaviour
{
    public GameObject wholeThing;
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image img5;
    private bool isShown1 = false;
    private bool isShown2 = false;
    private bool isShown3 = false;
    private bool isShown4 = false;
    private bool isShown5 = false;
    public void LoadCredit1()
    {
        if (!isShown1)
        {
            StartCoroutine(FadeImage(false, img1));
            isShown1 = true;
        }
        else
        {
            StartCoroutine(FadeImage(true, img1));
            isShown1 = false;
        }

    }
    public void LoadCredit2()
    {
        if (!isShown2)
        {
            StartCoroutine(FadeImage(false, img2));
            isShown2 = true;
        }
        else
        {
            StartCoroutine(FadeImage(true, img2));
            isShown2 = false;
        }
    }
    public void LoadCredit3()
    {
        if (!isShown3)
        {
            StartCoroutine(FadeImage(false, img3));
            isShown3 = true;
        }
        else
        {
            StartCoroutine(FadeImage(true, img3));
            isShown3 = false;
        }
    }
    public void LoadCredit4()
    {
        if (!isShown4)
        {
            StartCoroutine(FadeImage(false, img4));
            isShown4 = true;
        }
        else
        {
            StartCoroutine(FadeImage(true, img4));
            isShown4 = false;
        }
    }
    public void LoadCredit5()
    {
        if (!isShown5)
        {
            StartCoroutine(FadeImage(false, img5));
            isShown5 = true;
        }
        else
        {
            StartCoroutine(FadeImage(true, img5));
            isShown5 = false;
        }
    }

    IEnumerator FadeImage(bool fadeAway, Image img)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
