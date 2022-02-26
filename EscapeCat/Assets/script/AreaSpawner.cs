using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPerfabs;   // ���� ������ �迭
    //[SerializeField]
    //private GameObject areaPerfabsEnd;  // ������ ����

    [SerializeField]
    private int spawnAreaCountAtStart = 1;  // ���� ���۽� ���� �����Ǵ� ���� ����

    [SerializeField]
    private float zDistance = 20;   // ���� ������ �Ÿ� (z)

    private int areaIndex = 260;     // ���� �ε��� (��ġ�Ǵ� ������ z��ġ ���꿡 ���)


    [SerializeField]
    private Transform playerTransform;  // �÷��̾� Transform

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

        // spawnAreaCountAtStart�� ����� ������ŭ ���� ���� ����
        for (int i = 0; i < spawnAreaCountAtStart; i++)
        {
            // ù��° ������ �׻� 0������ ���������� ����
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

    public void SpawnArea(int Areacount) // �Ű������� ���� ������ true
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
        //    clone = Instantiate(areaPerfabs[Ground]);    // 0�� ���� ����
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
        //    int index = Random.Range(0, areaPerfabs.Length - 3);    // ������ ���� ����
        //    clone = Instantiate(areaPerfabs[index]);

        //}

        // ������ ��ġ�Ǵ� ��ġ ���� (z���� ���� ���� �ε��� * zDistance)
        clone.transform.position = new Vector3(-30.30f, 0, areaIndex * zDistance);

        // ������ ������ �� ���ο� ������ ���� �� �� �ֵ��� this�� �÷��̾��� Transform���� ����
        //clone.GetComponent<Area>().Setup(this, playerTransform);

        // ���� ������ zDistance��ŭ �������� �����ǰԲ� areaIndex++;
        //areaIndex++;
    }
}
