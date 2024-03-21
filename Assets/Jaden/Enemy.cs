using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Transform pPosition = player.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
