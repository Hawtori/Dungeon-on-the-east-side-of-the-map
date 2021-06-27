using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pumpkin : MonoBehaviour
{
    public Data score;
    PlayerMovement player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        score = GameObject.Find("Player").GetComponent<Data>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            player.level += 1;
            Debug.Log(collision.gameObject.name);
            Debug.Log(player.level);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            setNums();
            //collision.gameObject.GetComponent<PlayerMovement>().max_health = 69f;
            PlayerMovement scrip = collision.GetComponent<PlayerMovement>();
            scrip.level += 1;
            Debug.Log("player level incrrease" + scrip.level);
            score.score += 50;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void setNums()
    {
        PlayerPrefs.SetFloat("Level", player.level + 1);
        //PlayerPrefs.SetFloat("MaxHealth", player.max_health);
        //PlayerPrefs.SetFloat("Health", player.health);
        //PlayerPrefs.SetFloat("Dash", );
        //PlayerPrefs.SetFloat("DashDist", );
        //PlayerPrefs.SetFloat("Damage", );
        PlayerPrefs.SetFloat("HighScore", score.score);
        PlayerPrefs.SetFloat("Score", score.Highscore);
    }
}
