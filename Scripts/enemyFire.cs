using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{
    public ParticleSystem fireExplomsion;

    public float enemyDamage;

    private void Awake()
    {
        enemyDamage += PlayerPrefs.GetFloat("Level", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement pMove = collision.gameObject.GetComponent<PlayerMovement>();
            pMove.health -= enemyDamage;
        }

        if (collision.gameObject.tag != "Powerups")
        {
            Instantiate(fireExplomsion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
