using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScrpit : MonoBehaviour
{
    
    public void onClikcBtn() {
        GameManager.Instance.HaveGold += GameManager.Instance.ClickPerGold;
    }
}
