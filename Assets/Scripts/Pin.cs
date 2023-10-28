using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pin : MonoBehaviour
{

    bool isGrounded;

    public Player2 pinScript;
    public float addscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.Raycast(this.gameObject.transform.position, new Vector3(0,transform.localEulerAngles.y*-1,0), out RaycastHit hit, 2f);
        bool hitbox = (isGrounded) ? hit.transform.CompareTag("FIX") : false;
        if (hitbox == true)
        {
            
        }
        if (hitbox == false)
        {
            if (addscore == 0)
            {

                pinScript.PlusScore();
                addscore++;
                //Debug.Log(1);
            }
           
           
        }
        Debug.DrawRay(transform.position, new Vector3(0, transform.localEulerAngles.y * -1, 0),Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log(1);
        //    player2Script.PlusScore();
        //    //this.gameObject.SetActive(false);
           
        //}
    }

 

}
