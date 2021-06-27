using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashPWR : MonoBehaviour
{
    public ParticleSystem pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup(collision);
        }
    }

    void Pickup(Collider2D other)
    {
        //pickup effect
        Instantiate(pickup, transform.position, Quaternion.identity);

        //apply effect to player
        PlayerMovement scrip = other.GetComponent<PlayerMovement>();
        
        if (gameObject.name == "dash(Clone)")
        {
            if(!scrip.dashUnlocked) scrip.dashUnlocked = true;
            else scrip.dashSpeed += 4f;
            Debug.Log("dash pickup");
        }
        if (gameObject.name == "fireball-increase-dmg(Clone)")
        {
            //increase fireball damage
            //fire _fire = GameObject.Find("fireball").GetComponent<fire>();
            scrip._damage += 2f;
            Debug.Log("fireball pickup");
        }
        if (gameObject.name == "health-Increase(Clone)")
        {
            //either increase health or give 100% hp
            float max = scrip.max_health;
            float hp =  scrip.health;
            if(hp == max)
            {
                scrip.max_health += 5.0f;
                scrip.health += 5.0f;
            }
            else
            {
                scrip.health = scrip.max_health;
            }
            Debug.Log("health pickup");
        }
        if(gameObject.name == "lazer-powerup(Clone)")
        {
            if(scrip.hasLazer != true)
                scrip.hasLazer = true;
            else
            {
                //fire _fire = GameObject.Find("lazer").GetComponent<fire>();
                scrip._damage += 2f;
            }
            Debug.Log("lazer pickup");
        }
        if (gameObject.name == "speed up(Clone)")
        {
            scrip.runSpeed += 2.0f;
            Debug.Log("speed pickup");
        }

        //remove powerup
        Destroy(gameObject);
    }
}
