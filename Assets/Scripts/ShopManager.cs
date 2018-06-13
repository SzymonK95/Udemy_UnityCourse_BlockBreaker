using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public Scrollbar scrollbar;
    private float currentStep;
    private float lastStep;

    public void Start()
    {
        //scrollbar = GameObject.Find("ScrollbarShop").GetComponent<Scrollbar>();
        scrollbar.value = calulateScrollBarValue(PlayerPrefs.GetInt("sprite"));
    }

    public void Update()
    {

    }

    public void OnValueChanged(float value)
    {
        print("value " + value);

        currentStep = (float)Math.Round(value, 1);
        if (currentStep == lastStep) return;

        int spriteNumber = calculateSpriteNumber(currentStep);
        PlayerPrefs.SetInt("sprite", spriteNumber);

        print("spriteNumber " + spriteNumber);

        lastStep = currentStep;
    }

    private int calculateSpriteNumber(float value)
    {
        if (value > 0.9)
            return 9;
        if (value > 0.8)
            return 8;
        if (value > 0.7)
            return 7;
        if (value > 0.6)
            return 6;
        if (value > 0.5)
            return 5;
        if (value > 0.4)
            return 4;
        if (value > 0.3)
            return 3;
        if (value > 0.2)
            return 2;
        if (value > 0.1)
            return 1;
        return 0;
    }

    private float calulateScrollBarValue(int value)
    {
        if (value >= 9)
            return 1.0f;
        if (value >= 8)
            return 0.88888f;
        if (value >= 7)
            return 0.77777f;
        if (value >= 6)
            return 0.66666f;
        if (value >= 5)
            return 0.55555f;
        if (value >= 4)
            return 0.44444f;
        if (value >= 3)
            return 0.33333f;
        if (value >= 2)
            return 0.22222f;
        if (value >= 1)
            return 0.11111f;
        return 0.0f;
    }
}
