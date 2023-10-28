using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMoving : MonoBehaviour
{
    public GameObject[] waypoints;
    
    public float speed = 100f;
    bool isLift;


    public void SpeedLift()
    {

        transform.position = Vector3.MoveTowards(transform.position, waypoints[1].transform.position, speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isLift = Physics.Raycast(this.gameObject.transform.position, Vector3.up, out RaycastHit hit, 1f);
        bool hitbox = (isLift) ? hit.transform.CompareTag("Player") : false;
        if (hitbox == true)
        {
            SpeedLift();
            //Debug.Log(1);
        }

        Debug.DrawRay(transform.position, new Vector3(0, 1, 0), Color.red);


       


    }
}
