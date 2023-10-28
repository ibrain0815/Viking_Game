using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cam2 : MonoBehaviour
{
    
    public GameObject Player;
    public Vector3 offset;
    public GameObject Target;
    float rotateSpeed = 4;

    public float Yaxis;
    public float Xaxis;
    private float rotSecsitive = 3f;
   // private float dis = 4f;
    private float smoothTime = 0.12f;

    private Vector3 targetRotation;
    private Vector3 currentVel;


    void Start()
    {
        offset = transform.position - Player.transform.position;  //카메라와 플레이어의 위치차이

    }

    private void LateUpdate()
    {
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSecsitive;

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis,Yaxis),ref currentVel,smoothTime);
        //타겟 로테이션에서 뉴벡터의 로테이션 값까지/ 속도는 커렌트벨 만큼  거기까지/ 걸리는 시간이 스무스타임.
        //부드럽게 카메라가 도는 듯한 느낌을 부여
        Target.transform.eulerAngles = targetRotation;
    }

    private void Update()
    {
        Target.transform.position = Player.transform.position;
     
    }

    private void FixedUpdate()
    {
       // CamRote();
    }


    void CamRote()
    {
        if(Input.GetKey(KeyCode.Z)) 
        {
            Target.transform.Rotate(Vector3.up, -45f * rotateSpeed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.X))
        {
            Target.transform.Rotate(Vector3.up,45f *rotateSpeed*Time.deltaTime);
        }
    }


}