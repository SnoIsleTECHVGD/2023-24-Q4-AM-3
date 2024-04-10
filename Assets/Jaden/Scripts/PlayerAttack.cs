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
    OtherMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<OtherMovement>();
        cam = mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && !swinging)
        {
            /*Vector2 myPos = new(transform.position.x, transform.position.y);
            Vector2 direction = GetMouseDirection() - myPos;
            direction.Normalize();
            rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            weapon.transform.rotation = rotation;*/
            StartCoroutine(Swing());
        }
        if (swinging)
        {
            weapon.transform.RotateAround(transform.position, Vector3.forward, Mathf.Abs(rotation.z - weapon.transform.rotation.z));
            weapon.transform.RotateAround(transform.position, Vector3.forward, Mathf.Abs(rotation.z - weapon.transform.rotation.z));
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
        if(movement.LastMovement == 0)
        {
            weapon.transform.localPosition = new Vector2(.7f, 0);
            weapon.transform.localEulerAngles = new Vector3(0,0,90);
        } else if (movement.LastMovement == 1)
        {
            weapon.transform.localPosition = new Vector2(0, .7f);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 0);
        } else if (movement.LastMovement == 2)
        {
            weapon.transform.localPosition = new Vector2(-.7f, 0);
            weapon.transform.localEulerAngles = new Vector3(0, 0, -90);
        } else
        {
            weapon.transform.localPosition = new Vector2(0, -.7f);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        swinging = true;
        yield return new WaitForSeconds(2);
        swinging = false;
    }

}
