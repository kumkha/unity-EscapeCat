using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChanceGauge : MonoBehaviour
{
    Image chanceGauge;

    public SceneManagerScript jumpUp;

    public Text text;

    float minGauge = 0;
    float maxGauge = 30f;
    float cat = 1f;
    float cheeze = 3f;

    public bool jump = false;

    public static float gauge;
    // Start is called before the first frame update
    void Awake ()
    {
        chanceGauge = GetComponent<Image>();
        gauge = minGauge;

        jumpUp.jumpUp = PlayerPrefs.GetFloat("Jumplv");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Start());


    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (gauge <= 30)
            {
                jump = false;
                chanceGauge.fillAmount = (gauge) / maxGauge;
                text.text = (gauge/* * jumpUp.jumpUp*/).ToString("0.00") + "/" + maxGauge;
                break;
            }
            else
            {
                jump = true;
                chanceGauge.fillAmount -= Time.deltaTime * 0.2f;
                text.text = "JUMP!!";
                if (chanceGauge.fillAmount == 0)
                {
                    gauge = 1;
                }

                break;
            }
            yield return null;

        }

    }


    public void Getcheeze()
    {

            gauge  = gauge + 1 * jumpUp.jumpUp;

    }

    public void GetCat()
    {

            gauge += 3 * jumpUp.jumpUp;

    }
}

//https://podo1017.tistory.com/214 게이지 감소
//https://weeklyhow.com/how-to-make-a-health-bar-in-unity/
