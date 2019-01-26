﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class PoppingText : MonoBehaviour
{
    public TextMeshPro text;

    public void Awake()
    {
        text = GetComponent<TextMeshPro>();
        text.text = "";
        text.enabled = false;
    }
    public Tweener PopText(string Content, Color color, Vector3 position, float duration)
    {
        DOTween.Kill(transform);
        text.enabled = false;
        transform.position = position;
        text.text = Content;
        text.enabled = true;
        return transform.DOMoveY(.5f, duration).SetEase(Ease.OutQuad).OnComplete(DisableText);
    }
    
    public void DisableText()
    {
        text.enabled = false;
        text.text = "";
        gameObject.SetActive(false);
    }
}