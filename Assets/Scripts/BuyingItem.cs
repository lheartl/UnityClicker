using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItem : MonoBehaviour
{
    public Slider price_slider;
    public CanvasGroup cGroup;
    [Header("ItemInfo Private")]
    public string itemName = "카타나";
    [SerializeField]
    private int itemLevel = 1;
    [SerializeField]
    private int startItemPrice = 100;
    [SerializeField]
    private int autoIncreaseValue = 5;

    [SerializeField]
    private int nowItemPrice;
    [SerializeField]
    private int nowIncreaseValue;
    [SerializeField]
    private float increaseItemPrice = 1.35f;
    [SerializeField]
    private float increaseItemValue = 2.15f;

    private void Start()
    {
        price_slider.maxValue = startItemPrice;
        nowItemPrice = startItemPrice;
        nowIncreaseValue = autoIncreaseValue;
        StartCoroutine("AutoIncreaseWork");
    }
    // Update is called once per frame
    void Update()
    {
        if (nowItemPrice <= DataController.Instance.haveGold)
        {
            cGroup.alpha = 0.9f;
            //cGroup.interactable = false;
        }
        else {
            cGroup.alpha = 0.6f;
           // cGroup.interactable = true;
        }

        price_slider.value = DataController.Instance.haveGold;
       
    }

    public void buyItem() {
        Debug.Log("클릭");
        if (nowItemPrice <= DataController.Instance.haveGold) {
            GameManager.Instance.useGold(nowItemPrice);
            itemLevel++;
            nowItemPrice = startItemPrice *(int)Mathf.Pow(increaseItemPrice,itemLevel);
            nowIncreaseValue = autoIncreaseValue * (int)Mathf.Pow(increaseItemValue, itemLevel);
            price_slider.maxValue = nowItemPrice;
        }
        
    }

    IEnumerator AutoIncreaseWork()
    { 

        while (true)
        {
            if (itemLevel>1) {
                GameManager.Instance.addGold(nowIncreaseValue);
            }
            yield return new WaitForSeconds(1f);
        }

    }

}
