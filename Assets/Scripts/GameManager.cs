using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("GameInfo Text")]
    public Text nowGoldText;
    public Text clickperGoldText;
    public Text autoIncressGoldText;

    private void Start()
    {
        StartCoroutine("AutoIncreaseWork");
    }
    void Update()
    {
        // 프레임마다 현재 보유 골드 표시
        nowGoldText.text = "현재 보유 골드 : "+DataController.Instance.haveGold;
        clickperGoldText.text = "클릭당 골드 : " + DataController.Instance.clickPerGold;
        autoIncressGoldText.text = "자동증가 골드 : " + DataController.Instance.autoIncreaseGold;

    }

    public void addGold(int gold) {
        DataController.Instance.haveGold += gold;
    }

    IEnumerator AutoIncreaseWork() {

        while (true) {

            addGold(DataController.Instance.autoIncreaseGold);
            yield return new WaitForSeconds(1);
        }
        
    }
}
