using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCat : MonoBehaviour
{
    [SerializeField]
    public GameObject[] prefabs;

    private BoxCollider area;   // �ڽ��ݶ��̴��� ������
    public int count = 10;      // �� ������Ʈ ����

    private List<GameObject> gameObject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; i++) // count ��ŭ ����
        {
            Spawn();    // ���� + ������ġ ����
        }

        area.enabled = false;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2.3f, size.x / 2.3f);
        float posz = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);
        float posy = 0.0f;

        Vector3 spawnPos = new Vector3(posX, posy, posz);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition(); // ������ġ �Լ�

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
        gameObject.Remove(instance);
    }

}


//https://angliss.cc/random-gameobject-created/