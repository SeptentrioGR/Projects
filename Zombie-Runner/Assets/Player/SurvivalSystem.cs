using System;
using UnityEngine;
[Serializable]
public class SurvivalSystem
{
    public float mHunger;
    public float CurrentHungerLevel;
    public float mThirst;
    public float CurrentThirstLevel;
    public float mHungerThreshold;
    public float mThirstThreshold;

    public SurvivalSystem(float Hunger, float Thirst, float mHungerThreshold, float mThirstThreshold)
    {
        mHunger = Hunger;
        mThirst = Thirst;
        this.mHungerThreshold = mHungerThreshold;
        this.mThirstThreshold = mThirstThreshold;
        ResetStatusLevels();
    }

    public void setmThirstThreshold(float value)
    {
        mThirstThreshold = value;
    }
    public void setmHungerThreshold(float value)
    {
        mHungerThreshold = value;
    }

    public float checkHunger()
    {
        return CurrentHungerLevel;
    }

    public float checkThirst()
    {
        return CurrentThirstLevel;
    }

    public void Update()
    {
        CurrentHungerLevel -= mHungerThreshold * Time.deltaTime;
        CurrentThirstLevel -= mThirstThreshold * Time.deltaTime;
        //ClampLevels();
    }

    void ClampLevels()
    {
        CurrentHungerLevel = Mathf.Clamp(CurrentHungerLevel, 0, mHunger);
        CurrentThirstLevel = Mathf.Clamp(CurrentThirstLevel, 0, mThirst);
    }
    void ResetStatusLevels()
    {
        CurrentHungerLevel = mHunger;
        CurrentThirstLevel = mThirst;
    }
}
