using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    int countCat;

    [SerializeField]
    private enemyComtroller enemyComtroller;

    [SerializeField]
    private Shoot shoot;

    [SerializeField]
    public Camera mainCamera;
    [SerializeField]
    public Camera shootCamera;

    [SerializeField]
    public ChanceGauge chanceGauge;

    [SerializeField]
    private GameObject hitEffectPrefab;

    public Movement movement;
    AudioSource audioSource;
    private void Start()
    {
        countCat = 0;
        mainCamera.enabled = true;
        shootCamera.enabled = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other) // 부딪힌 오브젝트 확인
    {
        if (other.tag.Equals("Obstacle"))   // Obstacle 이면 GameOver호출
        {
            gameController.ObstacleGameOver();
        }

        else if (other.tag.Equals("Coin"))  // Coin이면 InCreaseCoinCount 호출
        {
            gameController.InCreaseCoinCount();

            chanceGauge.Getcheeze();
        }

        else if (other.tag.Equals("BlueCoin"))  // Coin이면 InCreaseCoinCount 호출
        {
            gameController.InCreaseCoinCount();
            gameController.InCreaseCoinCount();
            gameController.InCreaseCoinCount();
            gameController.InCreaseCoinCount();
            gameController.InCreaseCoinCount();

        }

        else if (other.tag.Equals("Shoot"))
        {
            shoot.Shooter();
            // Timr.timeScale; (게임 정지)
            movement = GameObject.Find("Player").GetComponent<Movement>();
            movement.moveSpeed = 0f;


            mainCamera.enabled = false;
            shootCamera.enabled = true;
        }


        //else if (other.tag.Equals("Cat"))
        //{
        //    GameObject clone = Instantiate(hitEffectPrefab, transform.position + new Vector3(0, 1.5f, 0.5f), Quaternion.identity);
        //    //clone.transform.position = transform.position;
        //}
    }
    Quaternion q = Quaternion.Euler(0, 45, 0);

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Cat"))
        {

            audioSource.Play();
            GameObject hitEffect = Instantiate(hitEffectPrefab, transform.position + new Vector3(0,2.0f,-1.5f), q);
            enemyComtroller = other.gameObject.GetComponent<enemyComtroller>();
            countCat++;

            if (countCat > 1)
            {
                enemyComtroller._targetName = "Player"/* + (countCat - 1).ToString()*/;
            }

            other.gameObject.tag = "Cat"/* + countCat.ToString()*/;

            enemyComtroller.TargetFind();
            enemyComtroller._touch = true;
            //enemyComtroller.isTrigger = false;

            gameController.InCreaseCatCount();

            chanceGauge.GetCat();

        }


    }
}


//http://minpaprograming.blogspot.com/2018/04/unity-followtarget-lootat-target.html