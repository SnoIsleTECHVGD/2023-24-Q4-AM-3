using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject weapon;
    public GameObject mainCamera;
    public Camera cam;
    public bool swinging;
    public Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        cam = mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && !swinging)
        {
            Vector2 myPos = new(transform.position.x, transform.position.y);
            Vector2 direction = GetMouseDirection() - myPos;
            direction.Normalize();
            rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            weapon.transform.rotation = rotation;
            StartCoroutine(Swing());
        }
        if (swinging)
        {
            weapon.transform.RotateAround(transform.position, Vector3.back, Mathf.Abs(rotation.z - weapon.transform.rotation.z));
        }
    }
    Vector2 GetMouseDirection()
    {
        Vector3 dir = new(Input.mousePosition.x, Input.mousePosition.y, 0);
        dir = cam.ScreenToWorldPoint(dir);

        return new Vector2(dir.x, dir.y);
    }
    IEnumerator Swing()
    {
        swinging = true;
        yield return new WaitForSeconds(2);
        swinging = false;
    }

}
