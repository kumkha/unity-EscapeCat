using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //[SerializeField]
    //private TextMeshProUGUI textCoinCount;

    //[SerializeField]
    //private TextMeshProUGUI textCatCount;

    [SerializeField]
    private TextMeshProUGUI textEndGame;

    [SerializeField]
    private TextMeshProUGUI textEndScore;

    //[SerializeField]
    //private TextMeshProUGUI textTapToRestart;

    [SerializeField]
    private TextMeshProUGUI textToTalGold;

    public GameObject goldUpgradeButton;
    public GameObject jumpUpgradeButton;
    public GameObject ShootUpgradeButton;
    public GameObject StartGame;
    public GameObject EndGame;
    public GameObject chanceBar;

    public Button startGame;
    public Button goldBut;
    public Button jumpBut;
    public Button shootBut;

    public Shoot shoot;
    public SceneManagerScript goldUp;
    public SceneManagerScript jumpUp;
    public SceneManagerScript shootUp;
    public SceneManagerScript coinPrice;
    public SceneManagerScript jumpPrice;
    public SceneManagerScript shootPrice;

    public Image coinImage;



    public float coinCount = 0f;
    public float CatCount = 0f;
    public float TotalX = 0.0f;
    public float totalB = 0f;
    public float totalGold;

    public float Money;
    float timer;

    private bool saveUpgrade;
    public bool IsGameStart { private set; get; }

    public bool IsGameEnd { private set; get; }


    private void Awake()    // 텍스트 활성화 여부
    {
        //PlayerPrefs.DeleteAll();
        saveUpgrade = PlayerPrefs.HasKey("ToTalGold");

        if (!saveUpgrade)
        {
            Debug.Log("저장된 데이터가 없습니다.");
            PlayerPrefs.SetFloat("ToTalGold", 0);


        }

        else
        {
            totalGold = PlayerPrefs.GetFloat("ToTalGold");
        }

        IsGameStart = false;
        IsGameEnd = false;

        //textCoinCount.enabled = false;
        //textCatCount.enabled = false;
        textToTalGold.enabled = true;
        coinImage.gameObject.SetActive(true);


        goldUpgradeButton = GameObject.Find("GoldButton");
        jumpUpgradeButton = GameObject.Find("JumpButton");
        ShootUpgradeButton = GameObject.Find("ShootUpButton");
        StartGame = GameObject.Find("StartGame");
        chanceBar = GameObject.Find("ChanceBar");

        goldUp.coinUp = PlayerPrefs.GetFloat("Coinlv");
        jumpUp.jumpUp = PlayerPrefs.GetFloat("Jumplv");
        shootUp.shootUP = PlayerPrefs.GetFloat("Shootlv");

        coinPrice.coinPrice = PlayerPrefs.GetInt("coinPrice");
        jumpPrice.jumpPrice = PlayerPrefs.GetInt("jumpPrice");
        shootPrice.shootPrice = PlayerPrefs.GetInt("shootPrice");

        Money = PlayerPrefs.GetFloat("Money");
        
        //goldBut = GameObject.Find("GoldButton").GetComponent<Button>();
        //jumpBut = GameObject.Find("JumpButton").GetComponent<Button>();
        //shootBut = GameObject.Find("ShootUpButton").GetComponent<Button>();



        textToTalGold.text = totalGold.ToString("0");
        //Debug.Log("Godkfnas2 : " + totalGold);

        EndGame.SetActive(false);
        chanceBar.SetActive(false);
        Time.timeScale = 0.0f;
    }



    private IEnumerator Start()
    {
        // 마우스 왼쪽버특을 누리기 전까지 시작하지 않고 대기
        while (true)
        {
            if (Time.timeScale >= 1.0f)
            {
                Time.timeScale = 1.0f;
                IsGameStart = true;

                //textCoinCount.enabled = true;
                //textCatCount.enabled = true;
                textToTalGold.enabled = false;
                coinImage.gameObject.SetActive(false);

                goldUpgradeButton.SetActive(false);
                jumpUpgradeButton.SetActive(false);
                ShootUpgradeButton.SetActive(false);
                StartGame.SetActive(false);
                chanceBar.SetActive(true);

                break;
            }
            else
            {
                Time.timeScale = 0.0f;
            }
            yield return null;
        }

        if (jumpPrice.jumpPrice > totalGold)
        {
            jumpBut.interactable = false;
        }
        if (jumpPrice.jumpPrice > totalGold)
        {
            jumpBut.interactable = false;
        }
        if (shootPrice.shootPrice > totalGold)
        {
            shootBut.interactable = false;
        }
        //goldBut = transform.GetComponent<Button>();
        //jumpBut = transform.GetComponent<Button>();
        //shootBut = transform.GetComponent<Button>();

        //goldBut.onClick.AddListener(GoldBuyShop);
        //jumpBut.onClick.AddListener(JumpBuyShop);
        //shootBut.onClick.AddListener(ShootBuyShop);

    }

    void Update()
    {

        if (coinPrice.coinPrice > totalGold)
        {
            goldBut.interactable = false;
        }

        if (jumpPrice.jumpPrice > totalGold)
        {
            jumpBut.interactable = false;
        }

        if (shootPrice.shootPrice > totalGold)
        {
            shootBut.interactable = false;
        }
    }

    //private void Update()
    //{
    //    PlayerPrefs.SetFloat("ToTalGold", totalGold);
    //    textToTalGold.text = "totalGold : " + "\n" + totalGold.ToString("0");
    //    //Debug.Log("Godkfnas2 : " + totalGold);
    //}

    //public void Resetbut()
    //{
    //    PlayerPrefs.DeleteAll();
    //    //PlayerPrefs.DeleteKey("ToTalGold");
    //    //textToTalGold.text = "totalGold : " + "\n" + totalGold.ToString("0");
    //}

    public void InCreaseCoinCount() // 코인획득시
    {
        Money = Money + goldUp.coinUp + 0.2f;
        //textCoinCount.text = Money.ToString("0.00");  // textCoinCount 에 1씩오름
        //float TossMoney = Money;
        //PlayerPrefs.SetFloat("TossMoney", TossMoney);
        //Debug.Log(Money);
    }


    public void GameOver()
    {
        //PlayerPrefs.DeleteKey("Money");
        IsGameEnd = true;

        EndGame.SetActive(true);
        //textCoinCount.enabled = false;
        //textCatCount.enabled = false;

        Time.timeScale = 0f;
        //TotalX = Mathf.Floor(shoot.TotalCount/* * 10*/)/* * 0.10f*/;
        TotalX = shoot.TotalCount;
        TotalX -= 3.2f;

        float totalA = Money + CatCount;
        totalB = totalA * TotalX;
        textEndScore.text = "Score : " + totalA.ToString("0") + "\n" + "X : " + TotalX.ToString("0.0")
                + "\n" + "Get Money : " + totalB.ToString("0");


        ToTalGoldCout();


        //if (Input.GetMouseButtonDown(0))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}

        //if(Input.GetKeyDown("R"))
        //{
        //    PlayerPrefs.DeleteAll();
        //}
        // 현재씬을 다시 로드
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ObstacleGameOver()
    {
        //PlayerPrefs.DeleteKey("Money");
        IsGameEnd = true;

        EndGame.SetActive(true);
        //textCoinCount.enabled = false;
        //textCatCount.enabled = false;

        Time.timeScale = 0f;
        //TotalX = Mathf.Floor(shoot.TotalCount/* * 10*/)/* * 0.10f*/;
        TotalX = shoot.TotalCount;
        TotalX -= 3.38f;

        float totalA = Money + CatCount;

        if (TotalX <= 0)
        {
            totalB = totalA;
            textEndScore.text = "Score : " + totalA.ToString("0") + "\n" + "X : 0"
                    + "\n" + "Get Money : " + totalB.ToString("0");

        }
        else
        {
            totalB = totalA * TotalX;
            textEndScore.text = "Score : " + totalA.ToString("0") + "\n" + "X : " + TotalX.ToString("0.0")
                    + "\n" + "Get Money : " + totalB.ToString("0");

        }


        ToTalGoldCout();
    }
    public void ToTalGoldCout()
    {

        totalGold = totalGold + totalB;
        textToTalGold.text = totalGold.ToString("0");
        PlayerPrefs.SetFloat("ToTalGold", totalGold);
        PlayerPrefs.Save();
    }

    public void GoldBuyShop()
    {

        totalGold = totalGold - coinPrice.coinPrice + 150;
        textToTalGold.text = totalGold.ToString("0");
        PlayerPrefs.SetFloat("ToTalGold", totalGold);
        PlayerPrefs.Save();

        if (coinPrice.coinPrice > totalGold)
        {
            goldBut.interactable = false;
        }
    }

    public void JumpBuyShop()
    {

        totalGold = totalGold - jumpPrice.jumpPrice + 600;
        textToTalGold.text = totalGold.ToString("0");
        PlayerPrefs.SetFloat("ToTalGold", totalGold);
        PlayerPrefs.Save();

        if (jumpPrice.jumpPrice > totalGold)
        {
            jumpBut.interactable = false;
        }
    }

    public void ShootBuyShop()
    {

        totalGold = totalGold - shootPrice.shootPrice + 4000;
        textToTalGold.text = totalGold.ToString("0");
        PlayerPrefs.SetFloat("ToTalGold", totalGold);
        PlayerPrefs.Save();

        if (shootPrice.shootPrice > totalGold)
        {
            shootBut.interactable = false;
        }
    }
    public void InCreaseCatCount()
    {

        CatCount = CatCount + goldUp.coinUp;
        //textCatCount.text = "Chase Cat : " + CatCount.ToString();
    }
    




}
