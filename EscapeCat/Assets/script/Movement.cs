using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;  // IsGameStart가 true일때 움직이기 위해

    Animator animator;

    //public ChanceGauge chanceGauge;

    // x축
    private float moveXWidth = 2.0f;    // 1회 이동시 x축 이동거리
    private float moveTimeX = 0.1f;     // 1회 이동시 소요되는시간 x축
    private bool isXMove = false;      // true : 이동중 , false : 멈춤

    // y축
    private float originY = 0.55f;      // 점프 및 착지하는 y축 값
    private float gravity = -9.81f;     // 중력
    private float moveTimeY = 0.6f;     // 1회 이동에 소요되는 시간 (y축)
    private bool isJump = false;

    // z축
    [SerializeField]
    public float moveSpeed = 10.0f;    // z축 이동속도

    // 회전
    private float rotateSpeed = 300.0f; // 회전속도

    private float limitY = -1.0f;       // 플레이어가 사망하는 y위치

    private Rigidbody rigidbody;

    float h, v;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // 현재상태가 게임 시작이 아니면 Update()를 실행하지 않는다
        if (gameController.IsGameStart == false) return;

        // z축 이동
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;






        // 오브젝트 회전 (x축)
        //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

    }

    public void MoveToX(int x) // x : 1 or -1
    {
        // 현재 x축 이동 중으로 이동 불가능
        //if (isXMove == true) return;

        //this.h = Input.GetAxis("Horizontal");
        //this.v = Input.GetAxis("Vertical");
        //float hSpeed = h * moveSpeed;
        //float vSpeed = v * moveSpeed;
        //Vector3 lookDirection = new Vector3(hSpeed, 0, vSpeed);
        //gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * rotateSpeed);
        //rigidbody.velocity = lookDirection;



        if (x > 0 && transform.position.x < moveXWidth) // x가 0보다 클때 플레이어의 위치가 왼쪽 혹은 중간이면 오른쪽 이동가능
        {
            //StartCoroutine(OnMoveToX(x));
            transform.Translate(x * Time.deltaTime * moveSpeed, 0, 0);


        }
        else if (x < 0 && transform.position.x > -moveXWidth)   // x가 0보다 작을떄 위치가 오른쪽 혹은 중간이면 왼쪽으로 이동 가능
        {
            //StartCoroutine(OnMoveToX(x));
            transform.Translate(x * Time.deltaTime * moveSpeed, 0, 0);
            //this.transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    public void MoveToY() //Y축 이동은 점프
    {
        // 현재 점프중이면 점프 불가능
        if (isJump == true) return;

        animator.SetBool("isjump", true);
        //animator.SetTrigger("doJump");
        StartCoroutine(OnMoveToY());    // 아니면 점프가능

    }

    //private IEnumerator OnMoveToX(int direction)
    //{
    //    float current = 50;
    //    float percent = 0;
    //    float start = transform.position.x;
    //    float end = transform.position.x + direction * 0.75f;

    //    isXMove = true; // 이동시작

    //    while (percent < 1)
    //    {
    //        //current += Time.deltaTime;
    //        //percent = current / moveTimeX;  // moveTimeX 시간동안

    //        //float x = Mathf.Lerp(start, end, percent);  // 현재위치 start 부터 direction * moveXWidth 만큰 x축으로 이동
    //        //transform.position = new Vector3(x, transform.position.y, transform.position.z);

    //        transform.position = new Vector3(0.5f, transform.position.y, transform.position.z);
    //        yield return null;
    //    }

    //    isXMove = false;    // 이동 끝
    //}

    private IEnumerator OnMoveToY()
    {

        float current = 0;
        float percent = 0;
        float v0 = -gravity;    // y방향의 초기 속도


        isJump = true;  // 점프시작

        //rigidbody.useGravity = false;   // 중력 안받게함


        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeY;  // moveTimey 시간동안

            // 시간 경과에 따라 오브젝트의 y위치를 바꿔준다
            // 포물선운동 : 시작위치 + 초기속도 * 시간 + 중력 * 시간제곱
            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }

        animator.SetBool("isjump", false);
        isJump = false;     // 점프종료
        //rigidbody.useGravity = true;    // 중력 다시 받음

    }
}


