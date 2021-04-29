using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class ChatScript : MonoBehaviour
{
    [SerializeField] private GameObject DialougeBox;
    private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private List<String> chat;
    

    private void Start()
    {
        _textMeshProUGUI = DialougeBox.GetComponent<TextMeshProUGUI>();
        
    }

    public void callChat(bool on)
    {
        if (on)
        {
            System.Random rnd = new System.Random();
            _textMeshProUGUI.text = chat[rnd.Next(chat.Count)];
        }
        else _textMeshProUGUI.text = "";
    }
}
