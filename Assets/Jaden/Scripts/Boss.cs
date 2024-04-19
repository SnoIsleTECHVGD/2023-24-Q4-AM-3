using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
            transform.position = startingPos + new Vector3(4,7);
        if (Input.GetKey(KeyCode.LeftBracket))
            transform.position = startingPos + new Vector3(-5, 8);
        if (Input.GetKey(KeyCode.RightBracket))
            transform.position = startingPos + new Vector3(-3, -6);
        if (Input.GetKey(KeyCode.O))
            transform.position = startingPos + new Vector3(4, -6);
        if (Input.GetKey(KeyCode.L))
            transform.position = startingPos;
    }
}
