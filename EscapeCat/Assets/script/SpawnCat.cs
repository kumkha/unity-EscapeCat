using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCat : MonoBehaviour
{
    [SerializeField]
    public GameObject[] prefabs;

    private BoxCollider area;   // 박스콜라이더의 사이즈
    public int count = 10;      // 찍어낼 오브젝트 갯수

    private List<GameObject> gameObject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; i++) // count 만큼 생성
        {
            Spawn();    // 생성 + 스폰위치 포함
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

        Vector3 spawnPos = GetRandomPosition(); // 랜덤위치 함수

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
        gameObject.Remove(instance);
    }

}


//https://angliss.cc/random-gameobject-created/