using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<Vector3> randomPos;
    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        randomPos.Add(startingPos + new Vector3(4, 7));
        randomPos.Add(startingPos + new Vector3(-5, 8));
        randomPos.Add(startingPos + new Vector3(-3, -6));
        randomPos.Add(startingPos + new Vector3(4, -6));
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Health>().health == 2)
        {

        }
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
    public void randomizePoz()
    {
        //transform.position = Random.Range(0, randomPos.ToArray().Length);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<DamageOnHit>() != null)
        {
            randomizePoz();
        }
    }
}
