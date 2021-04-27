using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    // private RoomTemplates templates;
    private int rand;
    public List<GameObject> points;
    public List<GameObject> resources;
    // Start is called before the first frame update
    void Start()
    {
        // templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        for (int i = 0; i < resources.Count; i++) {
            GameObject temp = resources[i];
            int randomIndex = Random.Range(i, resources.Count);
            resources[i] = resources[randomIndex];
            resources[randomIndex] = temp;
        }
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        for (int i=0; i<points.Count; i++) {
            GameObject resource = resources[i];
            // templates.resources.RemoveAt(0);
            Instantiate(resource, points[i].transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
