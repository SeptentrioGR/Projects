using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown
{
    public static CountDown Instance;
    public float startingSeconds = 60f;
    public float m = 1f;
    public float s;

    public float speed;

    public CountDown(float minutes,float seconds,float speed)
    {
        Instance = this;
        this.startingSeconds = seconds;
        m = minutes;
        s = startingSeconds;
        this.speed = speed;
    }


    public string GetString()
    {
        return string.Format("{0}:{1}", m.ToString("00"), Mathf.Round(s).ToString("00"));
    }

    public void Update()
    {
        if (m > 0)
        {
            s -= Time.deltaTime * speed;
            if (s <= 0)
            {
                m--;
                s = startingSeconds;
            }
        }
    }

    public bool TimeIsUp()
    {
        if (m <= 0 && s == 0)
        {
            return true;
        }
        return false;
    }
}
