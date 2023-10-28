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


        rb = this.gameObject.GetComponent<Rigidbody>(); // 공 오브젝트의 리지드바디에 접근
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

        //rb.velocity = new Vector3(h*moveSpeed, rb.velocity.y, v*moveSpeed); //방향으로 가속
        //rb.AddForce(new Vector3(h * moveSpeed, 0, v * moveSpeed), ForceMode.Impulse); // 일정한힘으로 밀기

    }

    // Update is called once per frame
    void Update()
    {

        //지식 오브젝트에 오프셋을 적용하여 스케일이 부모를 벗어나지  않도록 함
        isGrounded = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hit, 1f);
        //RaycastHit : 레이저를 쐈을때 만난 콜라이더의 정보(bool type = false,true)
        //hit.transform.dkjfoihi = hit 정보를 게임오브젝트 처럼 코당 가능 + 컴포넌트에 접근 가능
        bool hitbox = (isGrounded) ? hit.transform.CompareTag("Ground") : false; // isGrounded가 true면 앞에꺼, isGrounded false면 뒤에꺼
        //isGround(레이케스트가 쐈을때 있느냐 없느냐)
        //만약에 없을 때 = false:?{transform.CompareTag("Ground"):false}>>false를 봔환
        //만약에 있을 때 = false:?{transform.CompareTag("Ground"):false}>>hit.transform.CompareTag("Ground")//태그가 "그라운드"인지 확인

        if (hitbox == true) // hit.transform.CompareTag 가 "Ground"일 때 //땅이 공 아래 있을 때
        {
            GameObject Ground = hit.transform.parent.gameObject; //레이저 만난놈이 부모에 접근해서 이름을 GroundParent로 적용
            this.transform.parent = Ground.transform; //공의 부모가 그라운드가 되어짐
            //Debug.Log(hit.transform.tag);
        }

        if (hitbox == false) // hit.transform.CompareTag 가 "Ground" 아닌때 //땅이 공아래 없을때
        {
            this.transform.parent = null;   //공의 부모에서 빠져나옴
        }
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0)); //레이저를 씬에 생성

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
