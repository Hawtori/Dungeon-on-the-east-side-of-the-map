using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    public Transform wallPlace1;
    public Transform wallPlace;
    public GameObject wall;
    public GameObject enemies;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Instantiate(wall, wallPlace.position, wallPlace.rotation);
            //if (wallPlace1 != null)
            //    Instantiate(wall, wallPlace1.position, wallPlace1.rotation);
            enemies.SetActive(true);
        }
    }
}
