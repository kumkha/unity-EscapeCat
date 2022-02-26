using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPerfabs;   // 구역 프리팹 배열
    //[SerializeField]
    //private GameObject areaPerfabsEnd;  // 마지막 구역

    [SerializeField]
    private int spawnAreaCountAtStart = 1;  // 게임 시작시 최초 생성되는 구역 갯수

    [SerializeField]
    private float zDistance = 20;   // 구역 사이의 거리 (z)

    private int areaIndex = 260;     // 구역 인덱스 (배치되는 구역의 z위치 연산에 사용)


    [SerializeField]
    private Transform playerTransform;  // 플레이어 Transform

    private bool map;
    private int Areacount;
    private void Awake()
    {
        map = PlayerPrefs.HasKey("Areacount");
        if (!map)
        {
            PlayerPrefs.SetInt("Areacount", 0);
        }
        else
        {
            Areacount = PlayerPrefs.GetInt("Areacount");
        }

        // spawnAreaCountAtStart에 저장된 갯수만큼 최초 구역 생성
        for (int i = 0; i < spawnAreaCountAtStart; i++)
        {
            // 첫번째 구역은 항상 0번구역 프리팹으로 설정
            //if (i == 0)
            //{
            SpawnArea(Areacount);

            //}

            //else
            //{
            //    SpawnArea(Ground);
            //}
        }
    }

    public void SpawnArea(int Areacount) // 매개변수에 값이 없으면 true
    {
        GameObject clone = null;
        Areacount = PlayerPrefs.GetInt("Areacount");
        switch (Areacount)
        {
            case 0:
                clone = Instantiate(areaPerfabs[0]);
                break;
            case 1:
                clone = Instantiate(areaPerfabs[1]);
                break;
            case 2:
                clone = Instantiate(areaPerfabs[2]);
                break;
            case 3:
                clone = Instantiate(areaPerfabs[3]);
                break;
            case 4:
                clone = Instantiate(areaPerfabs[4]);
                break;
            case 5:
                clone = Instantiate(areaPerfabs[5]);
                break;
            case 6:
                clone = Instantiate(areaPerfabs[6]);
                break;
            case 7:
                clone = Instantiate(areaPerfabs[7]);
                break;
            case 8:
                clone = Instantiate(areaPerfabs[8]);
                break;
            case 9:
                clone = Instantiate(areaPerfabs[9]);
                break;

        }

        if (Areacount < 10)
        {
            Areacount++;
            PlayerPrefs.SetInt("Areacount", Areacount);
            PlayerPrefs.Save();
        }
        else
        {
            clone = Instantiate(areaPerfabs[0]);
            PlayerPrefs.SetInt("Areacount", 0);
        }
        //if (isRandom == false)
        //{
        //    clone = Instantiate(areaPerfabs[Ground]);    // 0번 구역 생성
        //}

        //else if (count == 6)
        //{
        //    clone = Instantiate(areaPerfabs[3]);
        //}

        //else if (count == 7)
        //{
        //    clone = Instantiate(areaPerfabs[4]);
        //}

        //else if (count >= 8)
        //{
        //    isRandom = false;
        //    return;
        //}

        //else
        //{
        //    int index = Random.Range(0, areaPerfabs.Length - 3);    // 임의의 구역 생성
        //    clone = Instantiate(areaPerfabs[index]);

        //}

        // 구역이 배치되는 위치 설정 (z축은 현재 구역 인덱스 * zDistance)
        clone.transform.position = new Vector3(-30.30f, 0, areaIndex * zDistance);

        // 수역이 삭제될 떄 새로운 구역을 생성 할 수 있도록 this와 플레이어의 Transform정보 전달
        //clone.GetComponent<Area>().Setup(this, playerTransform);

        // 다음 구역은 zDistance만큼 떨어져서 생성되게끔 areaIndex++;
        //areaIndex++;
    }
}
