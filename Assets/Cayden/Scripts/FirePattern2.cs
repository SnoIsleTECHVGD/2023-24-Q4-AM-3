using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FirePattern2 : MonoBehaviour
{
    
    private float angle = 0f;

    public float sightDistance;
    public GameObject player;
    Transform target;
    public int stinky = 0;

    void Start()
    {
        target = player.GetComponent<Transform>();
        InvokeRepeating("Fire", 0f, 0.15f);
    }

    private void Fire()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (MathF.Abs(distance) <= sightDistance)
        {
            GetComponent<Animator>().SetBool("SeesPlayer", true);
            if (stinky < 8)
            {
                stinky++;
            }
            else
            {
                GetComponent<Animator>().SetBool("IsShooting", true);
                GetComponent<Light2D>().color = new Color(1, 0, 0, 1);
                for (int i = 0; i <= 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
                }

                angle += 20f;

                if (angle >= 360f)
                {
                    angle = 0f;
                }
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("SeesPlayer", false);
            GetComponent<Animator>().SetBool("IsShooting", false);
            stinky = 0;
        }
    }

}
