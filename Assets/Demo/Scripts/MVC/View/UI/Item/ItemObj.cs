﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;

public class ItemObj : MonoBehaviour {

	public ItemModel Item { get; set; }
    public int Amount { get; set; }

    private Canvas canvas;

    public void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void Update()
    {
        if (InventoryManager.Instance.IsPicked == true)
        {
            //捡起物品就让物品跟随鼠标
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                Input.mousePosition, null, out position);//用out输出
            InventoryManager.Instance.PickedItem.SetLocalPosition(position);
        }
        if (transform.localScale.x!=targetScale)
        {
            //动画
            float scale = Mathf.Lerp(transform.localScale.x, targetScale, smoothing*Time.deltaTime);
            transform.localScale = new Vector3(scale, scale, scale);
            if (Mathf.Abs(transform.localScale.x - targetScale) < 0.02f) //小于一定值就认为插值成功了，可以节约性能
            {
                transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            }
        }
    }

    #region UI Component
    private Image itemImage;
    private Text amountText;
    private float targetScale = 1f;//原来比例
    private Vector3 animationScle = new Vector3(1.4f,1.4f,1.4f);//动画放大比例
    private float smoothing = 5;//动画速度

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

    //自身发生变化
    public void SetItem(ItemModel item, int amount)
    {
        this.Item = item;
        this.Amount = amount;
        //Update UI
        ItemImage.sprite =  Resources.Load<Sprite>(item.SpritePath);
        AmountText.text = Amount.ToString();
        transform.localScale = animationScle;
    }

    public void SetAmount(int amount)
    {
        this.Amount = amount;
        //Update UI
        if (Item.MaxLimit > 1)
        {
            AmountText.text = Amount.ToString();
        }
        else
        {
            AmountText.text = "";
        }
        transform.localScale = animationScle;
    }

    public void AddAmount(int amount)
    {
        this.Amount += amount;
        //Update UI
        if (Item.MaxLimit > 1)
        {
            AmountText.text = Amount.ToString();
        }
        else
        {
            AmountText.text = "";
        }
        transform.localScale = animationScle;
    }

    //控制显示
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector3 position)
    {
        transform.localPosition = position;
    }

}

