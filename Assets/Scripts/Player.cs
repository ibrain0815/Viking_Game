using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 0.2f;
    public float roteSpeed = 90f;
    public float jumpforce = 12f;
    bool isGrounded;

    public TextMeshProUGUI scoreText;
    public float score;

    public GameObject nextStage;
    public float goalScore;

    public AudioSource JumpSFX;
    public AudioSource WinSFX;
    public AudioSource bgmSFX;

    // Start is called before the first frame update
    void Start()
    {


        rb = this.gameObject.GetComponent<Rigidbody>(); // �� ������Ʈ�� ������ٵ� ����
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Z))
        {
            this.transform.Rotate(0.0f, -roteSpeed * Time.deltaTime, 0.0f);
        }

        if (Input.GetKey(KeyCode.X))
        {
            this.transform.Rotate(0.0f, roteSpeed * Time.deltaTime, 0.0f);
        }



        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //rb.velocity = new Vector3(h*moveSpeed, rb.velocity.y, v*moveSpeed); //�������� ����
        //rb.AddForce(new Vector3(h * moveSpeed, 0, v * moveSpeed), ForceMode.Impulse); // ������������ �б�

    }

    // Update is called once per frame
    void Update()
    {

        //���� ������Ʈ�� �������� �����Ͽ� �������� �θ� �����  �ʵ��� ��
        isGrounded = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hit, 1f);
        //RaycastHit : �������� ������ ���� �ݶ��̴��� ����(bool type = false,true)
        //hit.transform.dkjfoihi = hit ������ ���ӿ�����Ʈ ó�� �ڴ� ���� + ������Ʈ�� ���� ����
        bool hitbox = (isGrounded) ? hit.transform.CompareTag("Ground") : false; // isGrounded�� true�� �տ���, isGrounded false�� �ڿ���
        //isGround(�����ɽ�Ʈ�� ������ �ִ��� ������)
        //���࿡ ���� �� = false:?{transform.CompareTag("Ground"):false}>>false�� ��ȯ
        //���࿡ ���� �� = false:?{transform.CompareTag("Ground"):false}>>hit.transform.CompareTag("Ground")//�±װ� "�׶���"���� Ȯ��

        if (hitbox == true) // hit.transform.CompareTag �� "Ground"�� �� //���� �� �Ʒ� ���� ��
        {
            GameObject Ground = hit.transform.parent.gameObject; //������ �������� �θ� �����ؼ� �̸��� GroundParent�� ����
            this.transform.parent = Ground.transform; //���� �θ� �׶��尡 �Ǿ���
            //Debug.Log(hit.transform.tag);
        }

        if (hitbox == false) // hit.transform.CompareTag �� "Ground" �ƴѶ� //���� ���Ʒ� ������
        {
            this.transform.parent = null;   //���� �θ𿡼� ��������
        }
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0)); //�������� ���� ����

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            JumpSFX.Play();
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            // rb.AddForce(new Vector3(1,0,0)* jumpForce, ForceMode.Impulse);

        }
        if (score == goalScore)
        {
            bgmSFX.gameObject.SetActive(false);
            WinSFX.gameObject.SetActive(true);
            nextStage.SetActive(true);

        }

    }

    public void PlusScore()
    {
        score++; //score +1
        scoreText.text = $"Score = {score}";
    }

}
