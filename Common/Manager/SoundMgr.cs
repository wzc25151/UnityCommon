using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : SingeBase<SoundMgr>
{
    public GameObject bgmMgr;
    public AudioSource bgmAs;
    public float bgmVolume;


    public GameObject audioMgr;//声效
    public List<AudioSource> audioSourceList;
    public float audioVolume;


    protected override void init()
    {
        initBgmMgr();
        initAudioMgr();
    }

    public void initBgmMgr()
    {
        if (bgmMgr == null)
        {
            bgmMgr = new GameObject("BgmMgr");
            bgmAs = bgmMgr.AddComponent<AudioSource>();
            bgmAs.loop = true;
            bgmVolume = 1f;
        }
    }

    public void initAudioMgr()
    {
        if (audioMgr == null)
        {
            audioMgr = new GameObject("AudioMgr");
            audioSourceList = new List<AudioSource>();
        }
    }

    public void PlayBgm(string name)
    {

        ResMgr.GetInstance().LoadAsyn<AudioClip>(name, (clip) =>
        {
            bgmAs.clip = clip;
            bgmAs.volume = bgmVolume;
            bgmAs.Play();
        });
    }
    public void StopBgm()
    {
        bgmAs.Stop();
    }
    public void PauseBgm()
    {
        bgmAs.Pause();
    }
    public void SetBgmClip(AudioClip clip)
    {
        bgmAs.clip = clip;
    }
    public void SetBgmVolume(float volume)
    {
        bgmVolume = volume;
        bgmAs.volume = bgmVolume;

    }


    public void PlayAudio(string name)
    {
        AudioSource audio = null;
        for (int i = 0; i < audioSourceList.Count; i++)
        {
            if (!audioSourceList[i].isPlaying)
            {
                audio = audioSourceList[i];
                break;
            }
        }
        if (audio == null)
        {
            audio = audioMgr.AddComponent<AudioSource>();
            audioSourceList.Add(audio);

        }
        ResMgr.GetInstance().LoadAsyn<AudioClip>(name, (clip) =>
                                            {
                                                audio.clip = clip;
                                                audio.volume = audioVolume;
                                                audio.Play();

                                            });

    }
    // public void StopAudio()
    // {

    // }
    // public void PauseAudio()
    // {

    // }

    public void SetAudioVolume(float volume)
    {
        audioVolume = volume;

        foreach (AudioSource audio in audioSourceList)
        {

            audio.volume = audioVolume;
        }

    }
}
