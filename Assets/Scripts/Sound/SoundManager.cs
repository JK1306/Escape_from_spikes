using System;
using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource gameBgm, gameSfx;
    public SoundType[] soundTypes;
    private static SoundManager soundManagerInstance;
    public static SoundManager SoundManagerInstance{
        get{
            return soundManagerInstance;
        }
    }
    private void Awake() {
        if(soundManagerInstance != null){
            DontDestroyOnLoad(this);
            soundManagerInstance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void PlayerMusic(Sounds sound){
        SoundType audio = Array.Find(soundTypes, item => item.sounds == sound);
        if(audio != null){
            gameSfx.clip = audio.audio;
            gameSfx.Play();
        }else{
            Debug.Log("Could not Find the Sound : "+sound);
        }
    }
}

public class SoundType{
    public Sounds sounds;
    public AudioClip audio;
}

public enum Sounds{
    ButtonClick,
    Jump,
    AddCoin,
    Death
}