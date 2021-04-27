using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject closedRoom;

    public List<GameObject> rooms;

    public List<GameObject> resources;

    void Start()
    {
        // for (int i = 0; i < resources.Count; i++) {
        //     GameObject temp = resources[i];
        //     int randomIndex = Random.Range(i, resources.Count);
        //     resources[i] = resources[randomIndex];
        //     resources[randomIndex] = temp;
        // }
    }
    // Start is called before the first frame update
    // void Start()
    // {
    //     for (int i = 0; i < resources.Count; i++) {
    //         GameObject temp = resources[i];
    //         int randomIndex = Random.Range(i, resources.Count);
    //         resources[i] = resources[randomIndex];
    //         resources[randomIndex] = temp;
    //     }
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
