using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItem : MonoBehaviour
{
    public long item_price = 100;

    public Image item_img;
    public Slider price_slider;

    private void Start()
    {
        price_slider.maxValue = item_price;
    }
    // Update is called once per frame
    void Update()
    {
        Color temp = item_img.color;
        if (item_price <= DataController.Instance.haveGold)
        {
            temp.a = 0.9f;
        }
        else {
            temp.a = 0.7f;
        }

        price_slider.value = DataController.Instance.haveGold;

        item_img.color = temp;
    }


}
