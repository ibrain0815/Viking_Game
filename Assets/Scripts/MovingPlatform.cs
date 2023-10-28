using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;
    int WaypointIndex = 0;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[WaypointIndex].transform.position) < 0.1f) 
        {
            WaypointIndex++;
            if(WaypointIndex >= waypoints.Length)
            {
                WaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[WaypointIndex].transform.position,speed * Time.deltaTime);
    }
}
