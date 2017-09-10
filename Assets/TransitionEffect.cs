using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionEffect : MonoBehaviour {

    public Image m_Image;
    [Range(0,1)]
    public float amount;
    public float speed;

    public bool StartTransition;
    public bool FadeInScreen;
    public bool FadeOutScreen;



    //===========================================================================
    void Awake()
    {
  
    }

    //===========================================================================
    void Start () {
        Time.timeScale = 1;
        FadeIn();
    }

    public void Enabled(bool value)
    {
        m_Image.enabled = value;
    }

    

    public void FadeIn()
    {
        FadeInScreen = true;
        FadeOutScreen = false;

    }

    public void FadeOut()
    {
        FadeInScreen = false;
        FadeOutScreen = true;
    }

    void Update () {
        if (FadeInScreen || FadeOutScreen)
        {
            Color c = m_Image.color;
            c.a = amount;
            m_Image.color = c;

            if (FadeInScreen)
            {
                amount -= speed * Time.deltaTime;
                if (amount < 0)
                {
                    Enabled(false);
                    amount = 0;
                    FadeInScreen = false;
                }

            }
            else if (FadeOutScreen)
            {
                amount += speed * Time.deltaTime;
                if (amount > 1)
                {
                    Enabled(false);
                    amount = 1;
                    FadeOutScreen = false;
                }
            }
        }
    }
}
