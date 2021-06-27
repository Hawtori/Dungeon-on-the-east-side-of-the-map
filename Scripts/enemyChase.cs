using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyChase : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float health = 5f;
    Rigidbody2D rb;
    public Data score;

    public Animator animator;
    private float moveTimer = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    private void Awake()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        score = GameObject.Find("Player").GetComponent<Data>();
    }

    void Update()
    {
        if (target != null)
        {
            if (health <= 0)
            {
                animator.SetBool("Death", true);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                health = 1;
                moveTimer = 5f;
                score.score += 100;
                Destroy(gameObject, 1.6f);
            }
            if (moveTimer <= 0)
            {
                Vector2 me = new Vector2(target.position.x, target.position.y);
                Vector2 pos = Vector2.MoveTowards(transform.position, me, Time.fixedDeltaTime);
                rb.MovePosition(pos);
                //Vector2 lookdir = new Vector2(target.position.x - rb.position.x, target.position.y - rb.position.y);
                float lookDir = target.position.x - rb.position.x;

                animator.SetFloat("Horizontal", lookDir);
                animator.SetFloat("Speed", pos.sqrMagnitude);

                //if (health <= 0)
                //{
                //    animator.SetBool("Death", true);
                //    moveTimer = 5f;
                //    Destroy(gameObject, 1.6f);
                //}
            }
            else
            {
                moveTimer -= Time.fixedDeltaTime;
            }
            //transform.LookAt(me);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector2 dir = (transform.position - collision.transform.position);
            transform.position = new Vector3(transform.position.x + dir.x, transform.position.y + dir.y, -1);

            //collision.transform.position = new Vector3(-transform.position.x + dir.x * 0.1f, -transform.position.y + dir.y * 0.1f, collision.transform.position.z);

            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.health -= 0.5f;
            //rb.AddForce(diff * 100f, ForceMode2D.Impulse);

            health -= 0.5f;

        }
    }
}
