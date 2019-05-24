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

    private void Start()
    {
        itemBtnList = FindObjectsOfType<BuyingItem>();
    }


    void Update()
    {
        
        int tempIncrease = 0;
        for (int i = 0; i <itemBtnList.Length; i ++) {
            if (itemBtnList[i].itemLevel>1)
            {
                tempIncrease += itemBtnList[i].nowIncreaseValue;

            }

        }

        DataController.Instance.autoIncreaseGold = tempIncrease;

        // 프레임마다 현재 보유 골드 표시
        nowGoldText.text = "현재 보유 골드 : " + DataController.Instance.haveGold;
        clickperGoldText.text = "클릭당 골드 : " + DataController.Instance.clickPerGold;
        secondsperGoldText.text = "초당 골드 : " + DataController.Instance.autoIncreaseGold;

    }

    public void addGold(int gold) {
        DataController.Instance.haveGold += gold;
    }

    public void useGold(int gold) {
        Debug.Log("현재 골드 : "+ DataController.Instance.haveGold+"/사용골드 : "+ gold);
        DataController.Instance.haveGold -= gold;
    }
    
}
