using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class enemyTarget : MonoBehaviour
{
    //public ParticleSystem explomsion;
    public Transform firePoint1, firePoint2;
    public Transform target;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject enemyFirePref;
    public Data score;

    public float health;
    public float damage;

    public float moveTimer = 2f;
    public float shootTimer = 1f;
    public float fireForce = 20f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        score = GameObject.Find("Player").GetComponent<Data>();
        health += PlayerPrefs.GetFloat("Level", 0) + 2;
        damage += PlayerPrefs.GetFloat("Level", 0) + 2;
    }

    private void Update()
    {
        if (target != null)
        {
            if (moveTimer <= 0)
            {
                Vector2 dir = target.transform.position - transform.position;
                Vector2 me = target.transform.position;
                Vector2 pos = Vector2.MoveTowards(transform.position, me * 2, Time.fixedDeltaTime);

                //move
                {
                    rb.MovePosition(pos);
                }

                //play animation
                {
                    animator.SetFloat("Horizontal", dir.x);
                    animator.SetFloat("Speed", pos.sqrMagnitude);

                    if (health <= 0)
                    {
                        animator.SetBool("Death", true);
                        moveTimer = 5f;
                        score.score += 500;
                        Destroy(gameObject, 0.6f);
                    }

                }

                //attack
                {
                    if (transform.position.x - me.x < 10f && shootTimer <= 0)
                    {
                        Shoot(dir);
                        shootTimer = 1f;
                    }
                    else
                    {
                        shootTimer -= Time.deltaTime;
                    }
                }
            }
            else
            {
                moveTimer -= Time.fixedDeltaTime;
            }
        }
    }

    void Shoot(Vector2 dir)
    {
        if(dir.x < 0)
        {
           
            GameObject fire = Instantiate(enemyFirePref, firePoint1.position, transform.rotation);
            Rigidbody2D rbFire = fire.GetComponent<Rigidbody2D>();
            rbFire.AddForce(transform.right * -fireForce, ForceMode2D.Impulse);
        }
        else
        {

            GameObject fire = Instantiate(enemyFirePref, firePoint2.position, transform.rotation);
            Rigidbody2D rbFire = fire.GetComponent<Rigidbody2D>();
            rbFire.AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        }
    }
}
