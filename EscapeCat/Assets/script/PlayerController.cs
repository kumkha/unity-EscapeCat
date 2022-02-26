using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float dragDistance = 10f; // �巡�� �Ÿ�
    private Vector3 touchStart;         // ��ġ ���� ��ġ
    private Vector3 touchEnd;           // ��ġ ���� ��ġ

    private Movement movement;

    private ChanceGauge chanceGauge;
    Animator animator;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        chanceGauge = GameObject.Find("ChancePanel").GetComponent<ChanceGauge>();
    }

    private void Update()
    {
        if (Application.isMobilePlatform)
        {
            OnMobilePlatform();     // ������ΰ�
        }
        else
        {
            OnPCPlatform();     //PC�ΰ� Ȯ��
        }

    }

    private void OnMobilePlatform()
    {
        // ���� ȭ���� ��ġ�ϰ� ���� ������ �޼ҵ� ����
        if (Input.touchCount == 0) return;

        // ù ��° ��ġ ���� �ҷ�����
        Touch touch = Input.GetTouch(0);

        // ��ġ ����
        if(touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }

        // ��ġ & �巡��
        else if (touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;

            OnDragXY();
        }
    }

    private void OnPCPlatform()
    {
        // ��ġ ����
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }

        // ��ġ & �巡��
        else if (Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            OnDragXY();
        }
    }

    private void OnDragXY()
    {
        // ��ġ ���·� x�� �巡�� ������ dragDistance ���� Ŭ��
        // dragDistance�� 50 �̻��϶� movement.MoveToX ȣ��
        if (Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance)
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));   // 0 �Ǵ� 1 or 0 �Ǵ� -1 ��ȯ
            return;
        }

        // ��ġ ���·� y�� ���� �������� �巡�� ������ dragDistance���� Ŭ��
        if (touchEnd.y - touchStart.y >= dragDistance)
        {
            if (chanceGauge.jump)
            {
                movement.MoveToY();
                return;
            }
        }
    }
}
