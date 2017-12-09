﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : Collectables
{
    public Sprite key;

    [HideInInspector] public Transform canvas;
    [HideInInspector] public Transform icon;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").transform;
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255);

        icon = canvas.GetChild(2);
    }

    public override void PickUp()
    {
        icon.GetComponent<Image>().color = alphaMax;
        icon.GetComponent<Image>().sprite = key;
    }

}
