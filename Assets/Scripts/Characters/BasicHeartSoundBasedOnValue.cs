using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicHeartSoundBasedOnValue
{
    public AudioClip mHeartBeatFast;
    public AudioClip mHeartBeatMid;
    public AudioClip mHeartBeatSlow;

    public AudioClip mHeartBeatStrongFast;
    public AudioClip mHeartBeatStringMid;

    public AudioSource mAudioSoure;

    public AudioClip mCurrentAudioClip;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    // Use this for initialization
    public void Initialize(AudioSource Sourse)
    {
        mAudioSoure = Sourse;
    }

    public void SetAudioClip(AudioClip mAudioClip)
    {

    }

    public void Update(ref float Health)
    {
        if (Health < 90)
        {
            mCurrentAudioClip = mHeartBeatSlow;
        }
        else if (Health < 50)
        {
            mCurrentAudioClip = mHeartBeatMid;
        }else if (Health < 10)
        {
            mCurrentAudioClip = mHeartBeatFast;
        }

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (!mAudioSoure.isPlaying && mAudioSoure.clip != mCurrentAudioClip)
            {
                mAudioSoure.PlayOneShot(mCurrentAudioClip);
            }
        }
    }



}
