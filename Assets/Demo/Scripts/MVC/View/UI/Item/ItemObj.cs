using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObj : MonoBehaviour {

	public ItemModel Item { get; set; }
    public int Amount { get; set; }

#region UI Component
    private Image itemImage;
    private Text amountText;

    //放在这里获得比在Start里好
    private Image ItemImage
    {
        get
        {
            if (itemImage == null)
            {
                itemImage = this.GetComponent<Image>();
            }
            return itemImage;
        }
    }

    private Text AmountText
    {
        get
        {
            if (amountText == null)
            {
                amountText = this.GetComponentInChildren<Text>();
            }
            return amountText;
        }
    }
#endregion

    public void SetItem(ItemModel item, int amount)
    {
        this.Item = item;
        this.Amount = amount;
        //Update UI
        ItemImage.sprite =  Resources.Load<Sprite>(item.SpritePath);
        AmountText.text = Amount.ToString();
    }

    public void AddAmount(int amount)
    {
        this.Amount += amount;
        AmountText.text = Amount.ToString();   //Update UI
    }
}
