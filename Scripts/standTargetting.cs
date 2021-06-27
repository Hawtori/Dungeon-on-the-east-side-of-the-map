using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;

using UnityEngine;

public class standTargetting : MonoBehaviour
{
    public Transform target;
    public Animator animator;
    public GameObject fireball;
    public Data score;

    public float moveTimer = 2f;
    public float shootTimer = 1f;
    public float health = 3f;

    private void Start()
    {
        health += PlayerPrefs.GetFloat("Level", 0) + 3;
        target = GameObject.Find("Player").GetComponent<Transform>();
        score = GameObject.Find("Player").GetComponent<Data>();
    }

    private void Awake()
    {
    }

    private void Update()
    {
        if (target != null)
        {

            if (moveTimer <= 0) //can start moving
            {
                if (health <= 0)
                {
                    //animation
                    animator.SetBool("Dead", true);
                    moveTimer = 5f;
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    score.score += 1000;
                    //die
                    Die();

                }

                Vector2 dir = target.transform.position - transform.position; //direction of player

                //dir = dir.normalized;

                //play animation
                {
                    animator.SetFloat("Horizontal", dir.x);
                }

                Vector3 location = new Vector3(transform.position.x + dir.normalized.x * 2, transform.position.y + dir.normalized.y * 2, -5);

                if (shootTimer <= 0)
                //shoot player
                {
                    animator.SetBool("Attack", true);
                    GameObject fire = Instantiate(fireball, location, Quaternion.identity);
                    Rigidbody2D rb_fire = fire.GetComponent<Rigidbody2D>();
                    rb_fire.AddForce(dir, ForceMode2D.Impulse);
                    shootTimer = 1f;
                }
                else
                {
                    animator.SetBool("Attack", false);
                    shootTimer -= Time.deltaTime;
                }
            }
            else
            {
                moveTimer -= Time.deltaTime;
            }
        }
    }

    void Die()
    {
        Destroy(gameObject, 0.5f);
    }
}
