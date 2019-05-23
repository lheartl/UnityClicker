using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScrpit : MonoBehaviour
{
    
    public void onClikcBtn() {

        GameManager.Instance.addGold(DataController.Instance.clickPerGold);
        Debug.Log("현재 골드 : "+ DataController.Instance.haveGold);

    }
}
