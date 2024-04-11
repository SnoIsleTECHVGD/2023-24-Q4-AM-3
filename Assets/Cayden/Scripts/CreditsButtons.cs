using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButtons : MonoBehaviour
{
    public GameObject wholeThing;
    public GameObject credit1;
    public GameObject credit2;
    public GameObject credit3;
    public GameObject credit4;
    public GameObject credit5;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public void Start()
    {
        credit1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0);
    }
    public void LoadCredit()
    {

    }
}
