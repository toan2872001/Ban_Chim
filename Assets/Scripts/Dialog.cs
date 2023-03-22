using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;

    public void showDialog(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
    public void UpdateDialog(string title, string content)
    {
        if (titleText)
        {
            titleText.text = title;
        }
        if (contentText)
        {
            contentText.text = content;
        }
    }
}
