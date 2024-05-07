using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FirePattern1 : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 160f, endAngle = 200f;
    public float sightDistance;
    public GameObject player;
    Transform target;
    public int stinky = 0;
    public GameObject pooledBullet;
    // Start is called before the first frame update
    void Start()
    {
        target = player.GetComponent<Transform>();
        InvokeRepeating("Fire", 0f, 1f);
    }

    void Update()
    {
        float xPlayer = GameObject.Find("Player").transform.position.x;
        float yPlayer = GameObject.Find("Player").transform.position.y;
        float angleToPlayer = 270 - (Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - yPlayer, transform.position.x - xPlayer));
        startAngle = angleToPlayer - 20f;
        endAngle = angleToPlayer + 20f;
    }

    private void Fire()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Debug.DrawLine(transform.position, target.position);
        bool hit = Physics2D.Linecast(transform.position, target.position, LayerMask.GetMask("Walls"));
        if (MathF.Abs(distance) <= sightDistance && !hit)
        {
            GetComponent<Animator>().SetBool("SeesPlayer", true);
            if (stinky < 1)
            {
                stinky++;
            }
            else
            {
                GetComponent<Animator>().SetBool("IsShooting", true);
                GetComponent<Light2D>().color = new Color(1,0,0,1);
                float angleStep = (endAngle - startAngle) / bulletsAmount;
                float angle = startAngle;

                for (int i = 0; i < bulletsAmount + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                    bul.transform.SetPositionAndRotation(transform.position, transform.rotation);
                    bul.SetActive(true);
                    if(pooledBullet == gameObject.GetComponent<BulletPool>().pooledBullet)
                    {
                        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
                    }
                    else
                    {
                        bul.GetComponent<Bullet1>().SetMoveDirection(bulDir);
                    }


                    angle += angleStep;
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