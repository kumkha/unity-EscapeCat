using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;  // IsGameStart�� true�϶� �����̱� ����

    Animator animator;

    //public ChanceGauge chanceGauge;

    // x��
    private float moveXWidth = 2.0f;    // 1ȸ �̵��� x�� �̵��Ÿ�
    private float moveTimeX = 0.1f;     // 1ȸ �̵��� �ҿ�Ǵ½ð� x��
    private bool isXMove = false;      // true : �̵��� , false : ����

    // y��
    private float originY = 0.55f;      // ���� �� �����ϴ� y�� ��
    private float gravity = -9.81f;     // �߷�
    private float moveTimeY = 0.6f;     // 1ȸ �̵��� �ҿ�Ǵ� �ð� (y��)
    private bool isJump = false;

    // z��
    [SerializeField]
    public float moveSpeed = 10.0f;    // z�� �̵��ӵ�

    // ȸ��
    private float rotateSpeed = 300.0f; // ȸ���ӵ�

    private float limitY = -1.0f;       // �÷��̾ ����ϴ� y��ġ

    private Rigidbody rigidbody;

    float h, v;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // ������°� ���� ������ �ƴϸ� Update()�� �������� �ʴ´�
        if (gameController.IsGameStart == false) return;

        // z�� �̵�
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;






        // ������Ʈ ȸ�� (x��)
        //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

    }

    public void MoveToX(int x) // x : 1 or -1
    {
        // ���� x�� �̵� ������ �̵� �Ұ���
        //if (isXMove == true) return;

        //this.h = Input.GetAxis("Horizontal");
        //this.v = Input.GetAxis("Vertical");
        //float hSpeed = h * moveSpeed;
        //float vSpeed = v * moveSpeed;
        //Vector3 lookDirection = new Vector3(hSpeed, 0, vSpeed);
        //gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * rotateSpeed);
        //rigidbody.velocity = lookDirection;



        if (x > 0 && transform.position.x < moveXWidth) // x�� 0���� Ŭ�� �÷��̾��� ��ġ�� ���� Ȥ�� �߰��̸� ������ �̵�����
        {
            //StartCoroutine(OnMoveToX(x));
            transform.Translate(x * Time.deltaTime * moveSpeed, 0, 0);


        }
        else if (x < 0 && transform.position.x > -moveXWidth)   // x�� 0���� ������ ��ġ�� ������ Ȥ�� �߰��̸� �������� �̵� ����
        {
            //StartCoroutine(OnMoveToX(x));
            transform.Translate(x * Time.deltaTime * moveSpeed, 0, 0);
            //this.transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    public void MoveToY() //Y�� �̵��� ����
    {
        // ���� �������̸� ���� �Ұ���
        if (isJump == true) return;

        animator.SetBool("isjump", true);
        //animator.SetTrigger("doJump");
        StartCoroutine(OnMoveToY());    // �ƴϸ� ��������

    }

    //private IEnumerator OnMoveToX(int direction)
    //{
    //    float current = 50;
    //    float percent = 0;
    //    float start = transform.position.x;
    //    float end = transform.position.x + direction * 0.75f;

    //    isXMove = true; // �̵�����

    //    while (percent < 1)
    //    {
    //        //current += Time.deltaTime;
    //        //percent = current / moveTimeX;  // moveTimeX �ð�����

    //        //float x = Mathf.Lerp(start, end, percent);  // ������ġ start ���� direction * moveXWidth ��ū x������ �̵�
    //        //transform.position = new Vector3(x, transform.position.y, transform.position.z);

    //        transform.position = new Vector3(0.5f, transform.position.y, transform.position.z);
    //        yield return null;
    //    }

    //    isXMove = false;    // �̵� ��
    //}

    private IEnumerator OnMoveToY()
    {

        float current = 0;
        float percent = 0;
        float v0 = -gravity;    // y������ �ʱ� �ӵ�


        isJump = true;  // ��������

        //rigidbody.useGravity = false;   // �߷� �ȹް���


        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeY;  // moveTimey �ð�����

            // �ð� ����� ���� ������Ʈ�� y��ġ�� �ٲ��ش�
            // ������� : ������ġ + �ʱ�ӵ� * �ð� + �߷� * �ð�����
            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }

        animator.SetBool("isjump", false);
        isJump = false;     // ��������
        //rigidbody.useGravity = true;    // �߷� �ٽ� ����

    }
}


