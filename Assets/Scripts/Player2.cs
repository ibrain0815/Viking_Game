using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TEXT ���� ���̺귯��
using UnityEngine.SocialPlatforms.Impl;

public class Player2 : MonoBehaviour
{
    public GameObject target;

    Rigidbody rb;
    public float moveSpeed = 3f;
    public float roteSpeed = 90f;
    public float jumpForce = 5f;
    bool isGrounded;

    public TextMeshProUGUI scoreText;
    public float score;

    public GameObject nextStage;
    public float goalScore;

    public AudioSource jumpSFX;
    public AudioSource winSFX;
    public AudioSource bgmSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //rb.AddForce(target.transform.forward * moveSpeed);
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //rb.AddForce(target.transform.forward * -moveSpeed);
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.AddForce(target.transform.right * -moveSpeed);
            //rb.velocity = new Vector3(-1, rb.velocity.y,0 );
            transform.Translate(Vector3.right * -1 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //rb.AddForce(target.transform.right * moveSpeed);
            //rb.velocity = new Vector3(1, rb.velocity.y, 0);
            transform.Translate(Vector3.right * 1 * Time.deltaTime);
        }
            
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //rb.velocity = new Vector3(h*moveSpeed, rb.velocity.y, v*moveSpeed); //�������� ����
        //rb.AddForce(new Vector3(h * moveSpeed, 0, v * moveSpeed), ForceMode.Impulse); // ������������ �б�
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hit, 1f);
        bool hitbox = (isGrounded) ? hit.transform.CompareTag("Ground") : false;

        if (hitbox == true) // hit.transform.CompareTag �� "Ground"�� �� //���� �� �Ʒ� ���� ��
        {
            //Debug.Log(1);
            GameObject Ground = hit.transform.parent.gameObject; //������ �������� �θ� �����ؼ� �̸��� GroundParent�� ����
            this.transform.parent = Ground.transform; //���� �θ� �׶��尡 �Ǿ���
            //Debug.Log(hit.transform.tag);
        }
        else if (hitbox == false) // hit.transform.CompareTag �� "Ground" �ƴѶ� //���� ���Ʒ� ������
        {
            this.transform.parent = null;   //���� �θ𿡼� ��������
        }
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0)); //�������� ���� ����


        if (Input.GetButtonDown("Jump") )
        {
            jumpSFX.Play();
            //Debug.Log(2);
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);

        }

        if (score == goalScore)
        {
            bgmSFX.gameObject.SetActive(false);
            winSFX.gameObject.SetActive(true);
            nextStage.SetActive(true);

        }


    }
    public void PlusScore()
    {
        score++; //score +1
        scoreText.text = $"Score = {score}";
        //Debug.Log(2);
    }

}
