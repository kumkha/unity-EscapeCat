using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;   // ī�޶� �����ϴ� ���
    private float zDistance;
    private float xDistance;
    private float yDistance;

    private void Awake()
    {
        if(target != null)
        {
            zDistance = target.position.z - transform.position.z;   // Ÿ����ġ - ī�޶���ġ
            xDistance = target.position.x - transform.position.x;
            yDistance = target.position.y - transform.position.y;
        }
    }

    private void LateUpdate()
    {
        // target�� �������� ������ ���� ���� ����
        if (target == null) return;

        // ī�޶��� ��ġ(Position) ���� ����
        Vector3 position = transform.position;
        position.z = target.position.z - zDistance; // ī�޶��� z��ġ ����
        position.x = target.position.x - xDistance;
        position.y = target.position.y - yDistance;
        transform.position = position;
    }
}
