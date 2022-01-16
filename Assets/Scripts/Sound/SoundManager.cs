using System;
using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource gameSfx;
    public SoundType[] soundTypes;
    private static SoundManager soundManagerInstance;
    public static SoundManager SoundManagerInstance{
        get{
            return soundManagerInstance;
        }
    }
    private void Awake() {
        if(soundManagerInstance == null){
            DontDestroyOnLoad(this);
            soundManagerInstance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void Play(Sounds sound){
        SoundType audio = Array.Find(soundTypes, item => item.sounds == sound);
        if(audio != null){
            gameSfx.PlayOneShot(audio.audio);
        }else{
            Debug.Log("Could not Find the Sound : "+sound);
        }
    }
}

[Serializable]
public class SoundType{
    public Sounds sounds;
    public AudioClip audio;
}

public enum Sounds{
    OptionButtonClick,
    ButtonClick,
    Jump,
    AddCoin,
    Death
}