using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("GameInfo Text")]
    public Text nowGoldText;
    public Text clickperGoldText;


    void Update()
    {
        // 프레임마다 현재 보유 골드 표시
        nowGoldText.text = "현재 보유 골드 : "+DataController.Instance.haveGold;
        clickperGoldText.text = "클릭당 골드 : " + DataController.Instance.clickPerGold;

    }

    public void addGold(int gold) {
        DataController.Instance.haveGold += gold;
    }

    public void useGold(int gold) {
        DataController.Instance.haveGold -= gold;
    }
    
}
