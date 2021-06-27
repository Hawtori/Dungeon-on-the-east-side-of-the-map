using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePointUp, firePointDown, firePointLeft, firePointRight;
    
    public GameObject firePrefab;
    public GameObject lazerPrefab;

    public PlayerMovement player;

    public float fireForce = 20f;
    public float lazerForce = 40f;
    public string currentAttack = "lazer";

    public bool nextLevel = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //fireForce = 
            if (gameObject.GetComponent<PlayerMovement>().lastX > 0) Shoot(1);
            if (gameObject.GetComponent<PlayerMovement>().lastX < 0) Shoot(3);
            if (gameObject.GetComponent<PlayerMovement>().lastY > 0) Shoot(0);
            if (gameObject.GetComponent<PlayerMovement>().lastY < 0) Shoot(2);
        }
        if (player.hasLazer == true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (currentAttack == "lazer") currentAttack = "fire";
                else currentAttack = "lazer";
            }
        }
    }

    void Shoot(int dir) {
        //0 - up, 1 - right, 2 - down, 3 - left
        Transform[] firePoints = {firePointUp, firePointRight, firePointDown, firePointLeft};
        if (currentAttack == "fire") {
            GameObject fire = Instantiate(firePrefab, firePoints[dir].position, firePoints[dir].rotation);
            Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoints[dir].right * fireForce, ForceMode2D.Impulse);
        }
        else {
            Debug.Log("lazer shottt");
            GameObject lazer = Instantiate(lazerPrefab, firePoints[dir].position, firePoints[dir].rotation);
            Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoints[dir].right * lazerForce, ForceMode2D.Impulse);
        }
    }
    /*
    void ShootRight()
    {
        if (!nextLevel)
        {
            GameObject fire = Instantiate(firePrefab, firePointRight.position, firePointRight.rotation);
            Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointRight.right * fireForce, ForceMode2D.Impulse);
        }
        else {
            GameObject lazer = Instantiate(lazerPrefab, firePointRight.position, firePointRight.rotation);
            Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointRight.right * fireForce, ForceMode2D.Impulse);
        }
    }   

    void ShootLeft()
    {
        if(!nextLevel){
        GameObject fire = Instantiate(firePrefab, firePointLeft.position, firePointLeft.rotation);
        Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointLeft.right * fireForce, ForceMode2D.Impulse);
        }
        else {
            GameObject lazer = Instantiate(lazerPrefab, firePointLeft.position, firePointLeft.rotation);
            Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointLeft.right * fireForce, ForceMode2D.Impulse);
        }
    }

    void ShootUp()
    {
        if (!nextLevel)
        {
            GameObject fire = Instantiate(firePrefab, firePointUp.position, firePointUp.rotation);
            Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointUp.right * fireForce, ForceMode2D.Impulse);
        }
        else
        {
            GameObject lazer = Instantiate(lazerPrefab, firePointUp.position, firePointUp.rotation);
            Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointUp.right * fireForce, ForceMode2D.Impulse);
        }
    }

    void ShootDown()
    {
        if (!nextLevel)
        {
            GameObject fire = Instantiate(firePrefab, firePointDown.position, firePointDown.rotation);
            Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointDown.right * fireForce, ForceMode2D.Impulse);
        }
        else
        {
            GameObject lazer = Instantiate(lazerPrefab, firePointDown.position, firePointDown.rotation);
            Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointDown.right * fireForce, ForceMode2D.Impulse);
        }
    }
    */

}
