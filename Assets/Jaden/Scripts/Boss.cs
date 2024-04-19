using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<Vector3> randomPos;
    private Vector3 startingPos;
    private Vector3 Random1;
    private Vector3 Random2;
    private Vector3 Random3;
    private Vector3 Random4;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        Random1 = startingPos + new Vector3(4,7);
        Random2 = startingPos + new Vector3(-5,8);
        Random3 = startingPos + new Vector3(-3,-6);
        Random4 = startingPos + new Vector3(4,-6);
        randomPos.Add(Random1);
        randomPos.Add(Random2);
        randomPos.Add(Random3);
        randomPos.Add(Random4);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Health>().health == 2)
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
