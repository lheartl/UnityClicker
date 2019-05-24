using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("GameInfo Text")]
    public Text nowGoldText;
    public Text clickperGoldText;
    public Text secondsperGoldText;
    BuyingItem[] itemBtnList;

    public int clickPerGold = 1;
    public long haveGold = 0;
    public int autoIncreaseGold = 0;

    public int ClickPerGold
    {
        get
        {
            return clickPerGold;
        }
        set
        {
            Debug.Log("들어온 값"+value.ToString());
            clickPerGold = value;
            //PlayerPrefs.SetInt("clickPerGold", clickPerGold);
        }
    }
    public long HaveGold
    {
        get
        {
            return haveGold;
        }
        set
        {
            haveGold = value;
            //PlayerPrefs.SetString("haveGold", haveGold.ToString());
        }
    }
    public int AutoIncreaseGold
    {
        get
        {
            return autoIncreaseGold;
        }
        set
        {
            autoIncreaseGold = value;
            //PlayerPrefs.SetInt("autoIncreaseGold", autoIncreaseGold);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("clickPerGold"))
        {
            clickPerGold = PlayerPrefs.GetInt("clickPerGold", 0);
            haveGold = long.Parse(PlayerPrefs.GetString("haveGold", "0"));
            autoIncreaseGold = PlayerPrefs.GetInt("secondsperGoldText", 0);

        }
        else {
            clickPerGold = 1;
            haveGold = 0;
            autoIncreaseGold = 0;
        }
       

        itemBtnList = FindObjectsOfType<BuyingItem>();
    }


    void Update()
    {

        int tempIncrease = 0;
        for (int i = 0; i < itemBtnList.Length; i++)
        {
            if (itemBtnList[i].itemLevel > 1)
            {
                tempIncrease += itemBtnList[i].nowIncreaseValue;

            }
        }

        autoIncreaseGold = tempIncrease;

        // 프레임마다 현재 보유 골드 표시
        nowGoldText.text = "현재 보유 골드 : " + haveGold;
        clickperGoldText.text = "클릭당 골드 : " + clickPerGold;
        secondsperGoldText.text = "초당 골드 : " + autoIncreaseGold;

    }
}

