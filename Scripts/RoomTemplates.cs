using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRooms;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    private void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            Vector3 location = new Vector3(rooms[rooms.Count - 1].transform.position.x, rooms[rooms.Count - 1].transform.position.y, -9);
            Instantiate(boss, location, Quaternion.identity);
            spawnedBoss = true;        
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
