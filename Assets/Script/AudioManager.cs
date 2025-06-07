using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst;

    //[Header("開頭BGM")]
    //public AudioClip tittleclip;
    //public AudioClip gameclip;


    [Header("遊戲BGM")]
    public AudioClip KnockClip;
    //public AudioClip ClickClip;
    //public AudioClip SuccesClip;
    //public AudioClip[] FailClip;

    //AudioSource tittleSourse;
    AudioSource gameSourse;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;

            DontDestroyOnLoad(this);

            //tittleSourse = gameObject.AddComponent<AudioSource>();
            gameSourse = gameObject.AddComponent<AudioSource>();

            //Playtittle();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Knock()
    {
        gameSourse.clip = KnockClip;
        gameSourse.loop = false;
        gameSourse.Play();
    }

    public void SoundCtrl(int scrol)
    {
        gameSourse.volume = scrol;
    }
    //public void MusicCtrl(int scrol)
    //{
    //    tittleSourse.volume = scrol;
    //}

}
