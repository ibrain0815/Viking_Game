using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnPoint;
    public AudioSource deadSFX;


    public void RespawnPlayer()
    {
        Player.transform.position = SpawnPoint.transform.position; //플레이이어의 시작위치로 이동
        Player.transform.rotation = SpawnPoint.transform.rotation;
        Player.GetComponent<Rigidbody>().Sleep(); // 회전방지를 위해 중력적용 해제
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            deadSFX.Play();
            RespawnPlayer();
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
