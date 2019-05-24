using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItem : MonoBehaviour
{
    public Slider price_slider;
    public CanvasGroup cGroup;

    public Text priceText;
    public Text autoIncreaseText;
    public Text nextIncreaseText;

    [Header("ItemInfo Private")]
    public string itemName = "katana1";
    [SerializeField]
    public int itemLevel = 1;
    [SerializeField]
    private int startItemPrice = 100;
    [SerializeField]
    private int autoIncreaseValue = 5;

    
    public int nowItemPrice;
    public int nowIncreaseValue;
    public int beforeIncreaseValue;

    public float increaseItemPrice = 2.75f;
    
    public float increaseItemValue = 1.35f;

    private void Start()
    {

        if (PlayerPrefs.HasKey(itemName + "_nowItemPrice"))
        {
            price_slider.maxValue = PlayerPrefs.GetInt(itemName + "_nowItemPrice", startItemPrice);
            nowItemPrice = PlayerPrefs.GetInt(itemName + "_nowItemPrice", startItemPrice);
            nowIncreaseValue = PlayerPrefs.GetInt(itemName + "_nowIncreaseValue", 0);
            beforeIncreaseValue = PlayerPrefs.GetInt(itemName + "_beforeIncreaseValue", 0);
            itemLevel = PlayerPrefs.GetInt(itemName + "_itemLevel", 1);
        }
        else {
            price_slider.maxValue = startItemPrice;
            nowItemPrice = startItemPrice;
            nowIncreaseValue = 0;
            beforeIncreaseValue = 0;
            itemLevel = 1;
        }
        

        StartCoroutine("AutoIncreaseWork");

        priceText.text = "가격 : " + nowItemPrice;
        autoIncreaseText.text = "현재 증가값 : 0";
        nextIncreaseText.text = "다음 증가값 : " + nowIncreaseValue;
    }
    // Update is called once per frame
    void Update()
    {

        if (nowItemPrice <= GameManager.Instance.HaveGold)
        {
            
            cGroup.interactable = true;
        }
        else {
           
           cGroup.interactable = false;
        }
        if (price_slider.normalizedValue < 0.2)
        {
            cGroup.alpha = 0.2f;
        }
        else {
            cGroup.alpha = price_slider.normalizedValue;
        }
        
        price_slider.value = GameManager.Instance.HaveGold;
       
    }

    public void buyItem() {
        Debug.Log("클릭");
        if (nowItemPrice <= GameManager.Instance.haveGold) {
            GameManager.Instance.HaveGold -= nowItemPrice;

            itemLevel++;

            nowItemPrice = startItemPrice * (int)Mathf.Pow(increaseItemPrice, itemLevel);
            beforeIncreaseValue = nowIncreaseValue;
            nowIncreaseValue = autoIncreaseValue * (int)Mathf.Pow(increaseItemValue, itemLevel);
            price_slider.maxValue = nowItemPrice;

            PlayerPrefs.SetInt(itemName+ "_nowItemPrice", nowItemPrice);
            PlayerPrefs.SetInt(itemName + "_beforeIncreaseValue", beforeIncreaseValue);
            PlayerPrefs.SetInt(itemName + "_nowIncreaseValue", nowIncreaseValue);
            PlayerPrefs.SetInt(itemName + "_itemLevel", itemLevel);


            priceText.text = "가격 : " + nowItemPrice;
            autoIncreaseText.text = "초당 증가값 : " + beforeIncreaseValue;
            nextIncreaseText.text = "다음 증가값 : " + nowIncreaseValue;
        }
        
    }

    IEnumerator AutoIncreaseWork()
    { 

        while (true)
        {
            if (itemLevel>1) {
                GameManager.Instance.HaveGold += nowIncreaseValue;
            }
            yield return new WaitForSeconds(1f);
        }

    }

}
