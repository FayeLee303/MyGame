using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;
    private float targetAlpha = 1;
    public float smoothingTime = 5;

    private void Start()
    {
        toolTipText = this.GetComponent<Text>();
        contentText = GameObject.Find("ContentText").GetComponent<Text>();
        canvasGroup = this.GetComponent<CanvasGroup>();

    }

    private void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothingTime*Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f) canvasGroup.alpha = targetAlpha;
        }
    }

    public void ShowToolTip(string text)
    {
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
    }

    public void HideToolTip()
    {
        targetAlpha = 0;
    }
}
