using System;
using System.Collections;
using System.Collections.Generic;
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
        if (MathF.Abs(distance) <= sightDistance)
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
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

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