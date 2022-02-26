using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject scorePerfabs;   // ���� ������ �迭

    [SerializeField]
    private int spawnScoreAreaCountAtStart = 20;  // ���� ���۽� ���� �����Ǵ� ���� ����

    [SerializeField]
    private float zsDistance = 3;   // ���� ������ �Ÿ� (z)
    private float areaScoreIndex = 120.75f;     // ���� �ε��� (��ġ�Ǵ� ������ z��ġ ���꿡 ���)// 75.5
    [SerializeField]
    private Transform shootTransform;  // �÷��̾� Transform

    public TextMeshPro textMeshPro;

    public float scoreCount;

    private void Awake()
    {

        // spawnAreaCountAtStart�� ����� ������ŭ ���� ���� ����
        for (int i = 0; i < spawnScoreAreaCountAtStart; i++)
        {

            SpawnScoreArea();

        }


    }

    public void SpawnScoreArea() // �Ű������� ���� ������ true
    {
        GameObject clone2 = null;

        clone2 = Instantiate(scorePerfabs, transform.position, Quaternion.identity);    // 0�� ���� ����


        // ������ ��ġ�Ǵ� ��ġ ���� (z���� ���� ���� �ε��� * zDistance)
        clone2.transform.position = new Vector3(0, 0, areaScoreIndex * zsDistance - 1);

        // ������ ������ �� ���ο� ������ ���� �� �� �ֵ��� this�� �÷��̾��� Transform���� ����
        clone2.GetComponent<ScoreSpawn>().Setup(this, shootTransform);


        // ���� ������ zDistance��ŭ �������� �����ǰԲ� areaIndex++;
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
