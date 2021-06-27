using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMechanics : MonoBehaviour
{
    public Transform spawnPt;
    public GameObject[] powerups;

    private int rand;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("chest-open");

            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

            rand = Random.Range(0, powerups.Length);
            Vector2 dir = (transform.position - collision.transform.position).normalized;

            Vector3 idk = new Vector3((spawnPt.position.x + dir.x * 2), (spawnPt.position.y + dir.y * 2), -20);

            GameObject item = Instantiate(powerups[rand], idk, Quaternion.identity);
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();

            rb.AddForce((dir * 300) + new Vector2(Random.Range(-400, 400), Random.Range(-400, 400)));
            
            
        }
    }
}
