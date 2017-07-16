﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockWidget : BasicWidget
{
    public static ClockWidget m_instace;
    public static ClockWidget Instance
    {
        get
        {
            return m_instace;
        }
    }
    private void Awake()
    {
        m_instace = this;
    }

    public Text m_Clock;
    private bool StartCounting = false;

    public void StartTimer()
    {
        if (!StartCounting)
        {
            StartCounting = true;
            new CountDown(1, 0, 5);
        }
    }

    void Update()
    {
        m_Clock.enabled = false;
        if (StartCounting)
        {
            m_Clock.enabled = true;
            CountDown.Instance.Update();
            m_Clock.text = CountDown.Instance.GetString();
        }
    }
}
