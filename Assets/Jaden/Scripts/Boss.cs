using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<Vector3> randomPos;
    private Vector3 startingPos;
    public AnimationClip tpClip;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position + new Vector3(0,10,0);
        randomPos.AddRange(new List<Vector3>() { startingPos + new Vector3(4, 7), startingPos + new Vector3(-5, 8),
        startingPos + new Vector3(-3, -6), startingPos + new Vector3(4, -6), startingPos});
    }
    public void RandomizePos()
    {
        int g = Random.Range(0, 5);
        transform.position = randomPos[g];
        gameObject.GetComponent<Animator>().SetBool("IsTeleporting", false);
    }
}
