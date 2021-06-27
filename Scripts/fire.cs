
using UnityEngine;

public class fire : MonoBehaviour
{
    public ParticleSystem fireExplomsion;
    public PlayerMovement player;
    public float damage;
    //private enemyChase chase;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log()
        string temp = collision.gameObject.tag;
        if(temp == "Enemy")
        {
            damage = player._damage;
            if(collision.gameObject.GetComponent<enemyTarget>() != null) collision.gameObject.GetComponent<enemyTarget>().health -= damage;
            if(collision.gameObject.GetComponent<enemyChase>() != null) collision.gameObject.GetComponent<enemyChase>().health -= damage;
            if (collision.gameObject.GetComponent<standTargetting>() != null) collision.gameObject.GetComponent<standTargetting>().health -= damage;
            Destroy(gameObject);
            //Debug.Log(chase.health);
            //chase.health -= damage;
        }

        else if (temp != "Powerups")
        {
            Instantiate(fireExplomsion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
