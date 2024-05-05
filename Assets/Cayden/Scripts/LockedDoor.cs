using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LockedDoor : MonoBehaviour
{
    public GameObject player;
    Transform target;
    public float sightDistance;
    public GameObject canOpen;
    public GameObject cantOpen;
    public GameObject rightDoor;
    public GameObject leftDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = player.GetComponent<Transform>();
        float distance = Vector3.Distance(target.position, transform.position);
        if (MathF.Abs(distance) <= sightDistance)
        {
            if (player.GetComponent<Events>().hasKeyCard == true)
            {
                canOpen.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canOpen.SetActive(false);
                    leftDoor.SetActive(false);
                    rightDoor.SetActive(false);
                }
            }
            else
            {
                cantOpen.SetActive(true);
            }
        }
        else
        {
            canOpen.SetActive(false);
            cantOpen.SetActive(false);
        }
    }
}
