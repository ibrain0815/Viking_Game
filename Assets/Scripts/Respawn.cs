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
        Player.transform.position = SpawnPoint.transform.position; //�÷����̾��� ������ġ�� �̵�
        Player.transform.rotation = SpawnPoint.transform.rotation;
        Player.GetComponent<Rigidbody>().Sleep(); // ȸ�������� ���� �߷����� ����
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
