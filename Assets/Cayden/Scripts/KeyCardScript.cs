using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class KeyCardScript : MonoBehaviour
{
    public GameObject player;
    Transform target;
    public float sightDistance;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (MathF.Abs(distance) <= sightDistance)
        {
            text.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                text.SetActive(false);
                gameObject.SetActive(false);
                player.GetComponent<Events>().hasKeyCard = true;
            }
        }
        else
        {
            text.SetActive(false);
        }
    }
}
