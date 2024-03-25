using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{
    public GameObject weapon;
    public GameObject mainCamera;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 myPos = new(transform.position.x, transform.position.y);
            Vector2 direction = GetMouseDirection() - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg );
            weapon.transform.RotateAround(transform.position, Vector3.back, Mathf.Abs(rotation.z - weapon.transform.rotation.z) * 9);
        }
        Debug.Log(GetMouseDirection());
    }
    Vector2 GetMouseDirection()
    {
        Vector3 dir = new(Input.mousePosition.x, Input.mousePosition.y, 0);
        dir = cam.ScreenToWorldPoint(dir);

        return new Vector2(dir.x, dir.y);
    }

}
