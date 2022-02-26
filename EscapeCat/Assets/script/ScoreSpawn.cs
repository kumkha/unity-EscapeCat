using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreSpawn : MonoBehaviour
{
    [SerializeField]
    private float destroyDistance = 10;
    private ScoreSpawner scoreSpawner;

    private Transform shootTransform;


    public void Setup(ScoreSpawner scoreSpawner,  Transform shootTransform)
    {
        this.scoreSpawner = scoreSpawner;
        this.shootTransform = shootTransform;

    }

    private void Update()
    {

        if (shootTransform.position.z - transform.position.z >= destroyDistance)
        {

            scoreSpawner.SpawnScoreArea();


            Destroy(gameObject);
        }

    }

}


// ¼­ºê¿þÀÌ ·»Ä¡ ÇÖÄ¥¸®