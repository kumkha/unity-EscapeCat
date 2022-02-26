using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;   // 카메라가 추적하는 대상
    private float zDistance;
    private float xDistance;
    private float yDistance;

    private void Awake()
    {
        if(target != null)
        {
            zDistance = target.position.z - transform.position.z;   // 타겟위치 - 카메라위치
            xDistance = target.position.x - transform.position.x;
            yDistance = target.position.y - transform.position.y;
        }
    }

    private void LateUpdate()
    {
        // target이 존재하지 않으면 실행 하지 않음
        if (target == null) return;

        // 카메라의 위치(Position) 정보 갱신
        Vector3 position = transform.position;
        position.z = target.position.z - zDistance; // 카메라의 z위치 설정
        position.x = target.position.x - xDistance;
        position.y = target.position.y - yDistance;
        transform.position = position;
    }
}
