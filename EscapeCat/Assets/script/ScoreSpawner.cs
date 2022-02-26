using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject scorePerfabs;   // 구역 프리팹 배열

    [SerializeField]
    private int spawnScoreAreaCountAtStart = 20;  // 게임 시작시 최초 생성되는 구역 갯수

    [SerializeField]
    private float zsDistance = 3;   // 구역 사이의 거리 (z)
    private float areaScoreIndex = 120.75f;     // 구역 인덱스 (배치되는 구역의 z위치 연산에 사용)// 75.5
    [SerializeField]
    private Transform shootTransform;  // 플레이어 Transform

    public TextMeshPro textMeshPro;

    public float scoreCount;

    private void Awake()
    {

        // spawnAreaCountAtStart에 저장된 갯수만큼 최초 구역 생성
        for (int i = 0; i < spawnScoreAreaCountAtStart; i++)
        {

            SpawnScoreArea();

        }


    }

    public void SpawnScoreArea() // 매개변수에 값이 없으면 true
    {
        GameObject clone2 = null;

        clone2 = Instantiate(scorePerfabs, transform.position, Quaternion.identity);    // 0번 구역 생성


        // 구역이 배치되는 위치 설정 (z축은 현재 구역 인덱스 * zDistance)
        clone2.transform.position = new Vector3(0, 0, areaScoreIndex * zsDistance - 1);

        // 수역이 삭제될 떄 새로운 구역을 생성 할 수 있도록 this와 플레이어의 Transform정보 전달
        clone2.GetComponent<ScoreSpawn>().Setup(this, shootTransform);


        // 다음 구역은 zDistance만큼 떨어져서 생성되게끔 areaIndex++;
        areaScoreIndex++;

        textMeshPro = scorePerfabs.GetComponentInChildren<TextMeshPro>();


        scoreCount += 0.2f;
        textMeshPro.text = "X" + scoreCount.ToString("0.0");
        //if (scoreCount == 1)
        //{
        //    scoreCount += 0.2f;
        //    textMeshPro.text = "X" + scoreCount.ToString("0.0");

        //}
        //else
        //{
        //    scoreCount += 0.2f;
        //    textMeshPro.text = "X" + scoreCount.ToString("0.0");
        //}
    }
}
