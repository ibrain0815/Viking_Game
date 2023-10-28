using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReturn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject ReturnPoint;

    public void EnemyPoint()
    {
        Enemy.transform.position = ReturnPoint.transform.position;
        Enemy.transform.rotation = ReturnPoint.transform.rotation;
        Enemy.GetComponent<Rigidbody>().Sleep();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyPoint();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
