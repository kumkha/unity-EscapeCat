using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{

    public Rigidbody rigidbody;

    //[SerializeField]
    GameController gameController;

    [SerializeField]
    ScoreSpawner scoreSpawner;

    TextMeshPro textMeshPro;

    private float Count;
    private float CatCount;
    private float Money;

    public float TotalCount;
    public SceneManagerScript shootUp;

    float rotateSpeed = 10f;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        shootUp.shootUP = PlayerPrefs.GetFloat("Shootlv");
        //gameController.Money = PlayerPrefs.GetFloat("TossMoney");

        GetComponent<Rigidbody>().isKinematic = true;

    }

    public void Shooter()
    {
        CatCount = gameController.CatCount;
        Money = gameController.Money;

        GetComponent<Rigidbody>().isKinematic = false;
        //rigidbody.useGravity = false;
        GetComponent<CapsuleCollider>().isTrigger = false;

        float forcez = Money;
        float forcecat = CatCount;
        //rigidbody.AddForce(Vector3.forward * 2000f);


        Vector3 speed = new Vector3(0, 32, (forcez + forcecat) * shootUp.shootUP);
        GetComponent<Rigidbody>().AddForce(speed);

        //rigidbody.useGravity = true;

    }

    public void OnTriggerEnter(Collider other) // ºÎµúÈù ¿ÀºêÁ§Æ® È®ÀÎ
    {
        int count = 0;
        if (other.tag.Equals("Ground"))
        {
            if (count == 0)
            {
                //float timer = 0.0f;
                //float waitTime = 3.0f;
                //timer += Time.deltaTime;

                GetComponent<Rigidbody>().isKinematic = true;
                // GetComponent<BoxCollider>().isTrigger = true;



                TotalCount = scoreSpawner.scoreCount;
                //TotalCount = GetComponent<ScoreSpawner>().GetComponentInChildren<TextMeshPro>().text;
                //TotalCount = scoreSpawner.scorePerfabs.GetComponentInChildren<TextMeshPro>().text;
                //TotalCount = scoreSpawner.textMeshPro.text;

                PlayerPrefs.DeleteKey("TossMoney");
                gameController.GameOver();
                count++;
            }

        }

    }
}



//https://blog.naver.com/PostView.nhn?isHttpsRedirect=true&blogId=bluefallsky&logNo=140150974081
// https://luv-n-interest.tistory.com/687
// https://green4you.tistory.com/21
// https://himbopsa.tistory.com/29
// https://forum.unity.com/threads/find-is-not-allowed-to-be-called-from-a-monobehavior.755675/

// https://docs.unity3d.com/kr/current/Manual/class-Rigidbody.html