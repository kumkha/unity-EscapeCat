using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    private Movement movement;
    private Button GoldButton;
    private Button JumpButton;
    private Button ShootUpButton;

    public Text Goldtext;
    public Text Jumptext;
    public Text ShootText;
    public Text goldShopLV;
    public Text jumpShopLV;
    public Text shootShopLV;
    public Text coinPriceText;
    public Text jumpPriceText;
    public Text shootPriceText;

    public float coinUp;
    public float jumpUp;
    public float shootUP;

    public int coinUpLV;
    public int jumpUpLV;
    public int shootUPLV;

    public int coinPrice;
    public int jumpPrice;
    public int shootPrice;

    private bool saveUpgrade;

    public GameObject Menu;


    private void Awake()
    {
        saveUpgrade = PlayerPrefs.HasKey("Coinlv");

        if (!saveUpgrade)
        {
            Debug.Log("저장된 데이터가 없습니다.");
            PlayerPrefs.SetFloat("Coinlv", 1f);        // 코인 렙업당 능력상승량
            PlayerPrefs.SetFloat("Jumplv", 1f);         // 점프 렙업당 능력 상승량
            PlayerPrefs.SetFloat("Shootlv", 1.00f);     // 슛 렙업당 능력 상승량
            PlayerPrefs.SetInt("GoldSp", 1);            // 코인 레벨
            PlayerPrefs.SetInt("JumpSp", 1);            // 점프 레벨
            PlayerPrefs.SetInt("shootSp", 1);           // 슛 세벨
            PlayerPrefs.SetInt("coinPrice", 150);       // 코인 업글시 소모 골드
            PlayerPrefs.SetInt("jumpPrice", 600);       // 점프 업글시 소모 골드
            PlayerPrefs.SetInt("shootPrice", 4000);     // 슛 업글시 소모 골드
        }

        else
        {
            coinUp = PlayerPrefs.GetFloat("Coinlv");
            jumpUp = PlayerPrefs.GetFloat("Jumplv");
            shootUP = PlayerPrefs.GetFloat("Shootlv");
            coinUpLV = PlayerPrefs.GetInt("GoldSp");
            jumpUpLV = PlayerPrefs.GetInt("JumpSp");
            shootUPLV = PlayerPrefs.GetInt("shootSp");
            coinPrice = PlayerPrefs.GetInt("coinPrice");
            jumpPrice = PlayerPrefs.GetInt("jumpPrice");
            shootPrice = PlayerPrefs.GetInt("shootPrice");
        }

        gameController.totalGold = PlayerPrefs.GetFloat("ToTalGold");

        Goldtext.text = "CoinUpgrade" + "\n" + "Cost : " + "+" + coinUp.ToString("0.0");
        Jumptext.text = "JumpUpgrade" + "\n" + "Cost : " + "+" + jumpUp.ToString("0.00");
        ShootText.text = "ShootUpgrade" + "\n" + "Cost : " + "+" + shootUP.ToString("0.00");
        goldShopLV.text = "LV : " + coinUpLV.ToString();
        jumpShopLV.text = "LV : " + jumpUpLV.ToString();
        shootShopLV.text = "LV : " + shootUPLV.ToString();
        coinPriceText.text = "Cost : " + coinPrice.ToString();
        jumpPriceText.text = "Cost : " + jumpPrice.ToString();
        shootPriceText.text = "Cost : " + shootPrice.ToString();


        //Menu = GameObject.Find("Menu");
    }

    private void Start()
    {
        GoldButton = GameObject.Find("GoldButton").GetComponent<Button>();
        JumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        ShootUpButton = GameObject.Find("ShootUpButton").GetComponent<Button>();

        if (PlayerPrefs.GetInt("GoldSp") >= 50)
        {
            GoldButton.interactable = false;
            goldShopLV.text = "LV : MAX";
        }

        if (PlayerPrefs.GetInt("JumpSp") >= 40)
        {
            JumpButton.interactable = false;
            jumpShopLV.text = "LV : MAX";
        }

        if (PlayerPrefs.GetInt("shootSp") >= 20)
        {
            ShootUpButton.interactable = false;
            shootShopLV.text = "LV : MAX";
        }

    }

    public void OnTapButton()
    {
        SceneManager.LoadScene("Escape cat");
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }


    public void GoldUP()
    {
       // GetComponent<Button>().interactable = true;

        coinUp += 0.5f;
        Goldtext.text = "CoinUpgrade" + "\n" + "+" + coinUp.ToString("0.0");
        PlayerPrefs.SetFloat("Coinlv", coinUp);

        coinUpLV++;
        goldShopLV.text = "LV : " + coinUpLV.ToString();
        PlayerPrefs.SetInt("GoldSp", coinUpLV);

        coinPrice += 150;
        coinPriceText.text = "Cost : " + coinPrice.ToString();
        PlayerPrefs.SetInt("coinPrice", coinPrice);
        PlayerPrefs.Save();

        if (PlayerPrefs.GetInt("GoldSp") >= 50)
        {
            GoldButton.interactable = false;
            goldShopLV.text = "LV : MAX";
        }


    }

    public void JumpUP()
    {
        jumpUp += 0.05f;
        Jumptext.text = "JumpUpgrade" + "\n" + "+" + jumpUp.ToString("0.00");
        PlayerPrefs.SetFloat("Jumplv", jumpUp);

        jumpUpLV ++;
        jumpShopLV.text = "LV : " + jumpUpLV.ToString();
        PlayerPrefs.SetInt("JumpSp", jumpUpLV);

        jumpPrice += 600;
        jumpPriceText.text = "Cost : " + jumpPrice.ToString();
        PlayerPrefs.SetInt("jumpPrice", jumpPrice);
        PlayerPrefs.Save();


        if (PlayerPrefs.GetInt("JumpSp") >= 40)
        {
            JumpButton.interactable = false;
            jumpShopLV.text = "LV : MAX";
        }
    }

    public void ShootUP()
    {
        shootUP += 0.05f;
        ShootText.text = "ShootUpgrade" + "\n" + "+" + shootUP.ToString("0.00");
        PlayerPrefs.SetFloat("Shootlv", shootUP);

        shootUPLV ++;
        shootShopLV.text = "LV : " + shootUPLV.ToString();
        PlayerPrefs.SetInt("shootSp", shootUPLV);

        shootPrice += 4000;
        shootPriceText.text = "Cost : " + shootPrice.ToString();
        PlayerPrefs.SetInt("shootPrice", shootPrice);
        PlayerPrefs.Save();


        if (PlayerPrefs.GetInt("shootSp") >= 20)
        {
            ShootUpButton.interactable = false;
            shootShopLV.text = "LV : MAX";
        }
    }

    public void gameStop()
    {
        Time.timeScale = 0f;
    }

    public void MenuButton()
    {
        Menu.SetActive(true);
        movement = GameObject.Find("Player").GetComponent<Movement>();
        movement.moveSpeed = 0f;
        Time.timeScale = 0f;
        
    }

    public void BackMenuButton()
    {
        Menu.SetActive(false);
        movement = GameObject.Find("Player").GetComponent<Movement>();
        movement.moveSpeed = 10.0f;
        Time.timeScale = 1.0f;

    }

    public void TapToMain()
    {
        SceneManager.LoadScene("Escape cat");
    }

    public void TapToReset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Escape cat");
    }
}






//https://ncube-studio.tistory.com/20
//https://scvtwo.tistory.com/34 :토글 버튼
// https://solution94.tistory.com/30 : PlayerPrefs