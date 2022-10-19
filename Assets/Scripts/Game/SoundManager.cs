using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance => instance;
    private static SoundManager instance;

    public enum SoundNames
    {
        //ENVIRONMENT
        bumperPing,
        flipperPing,
        fiveSecCountdown,
        timeUp,
        //PLAYER + CROWN
        deathSound,
        playerHit,
        crownPing,
        powerupFreezer,
        powerupShield,
        powerupSpeed,
        powerupTeleport,
        //POST-GAME
        countUpDrumRoll,
        //MENU
        bgMusic,
        itemSelected,

    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    public struct KeySF
    {
        public SoundNames sn;
        public AudioSource ass;
    }

    [SerializeField]
    private List<KeySF> soundEffects;

    public bool IsPlaying(SoundNames sn)
    {
        foreach (KeySF sf in soundEffects)
        {
            if (sf.sn == sn)
            {
                return sf.ass.isPlaying;
            }

        }

        return false;
    }

    public void PlaySound(SoundNames sn)
    {
        foreach (KeySF sf in soundEffects)
        {
            if (sf.sn == sn)
            {
                sf.ass.Play();
            }
        }
    }

    public void StopSound(SoundNames sn)
    {
        foreach (KeySF sf in soundEffects)
        {
            if (sf.sn == sn)
            {
                sf.ass.Stop();
            }
        }
    }

    public void PauseSound(SoundNames sn)
    {
        foreach (KeySF sf in soundEffects)
        {
            if (sf.sn == sn)
            {
                sf.ass.Pause();
            }
        }
    }

    public void PauseAll()
    {
        foreach (KeySF sf in soundEffects)
        {
            sf.ass.Pause();
        }
    }

    public void UnPauseAll()
    {
        foreach (KeySF sf in soundEffects)
        {
            sf.ass.UnPause();
        }
    }

    public void UnPauseSound(SoundNames sn)
    {
        foreach (KeySF sf in soundEffects)
        {
            if (sf.sn == sn)
            {
                sf.ass.UnPause();
            }
        }
    }

    public void StopAll()
    {
        foreach (KeySF sf in soundEffects)
        {
            sf.ass.Stop();
        }
    }

    public AudioSource GetAss(SoundNames sn)
    {
        foreach (KeySF sf in soundEffects)
        {
            if (sf.sn == sn)
            {
                return (sf.ass);
            }
        }

        return (soundEffects[0].ass);
    }
}
