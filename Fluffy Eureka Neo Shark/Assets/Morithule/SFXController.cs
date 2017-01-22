using UnityEngine;
using System.Collections.Generic;

public enum SoundEffect { Can, CatDemon, CatScream, Ding, JetPack, Seagull, GigaSeagull, LongDing, PawsButton, Pew, Pop, Pop2, Splash01, Splash02, Sploosh };

public class SFXController : MonoBehaviour
{

    [SerializeField]
    private List<AudioClip> audioClips;
    [SerializeField]
    private AudioClip bgMusic;
    [SerializeField]
    private bool defaultSFXOn = true;
    [SerializeField]
    private bool playBGOnAwake = true;
    [Range(0.0f, 1.0f)]
    public float BackgroundVolume = .25f;

    private bool _SFXOn;

    private List<AudioSource> audioSources = new List<AudioSource>();
    private AudioSource bgMusicSrc;

    private const string SFXON = "SFXOn";
    public static SFXController Instance;
    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        foreach (AudioClip clip in audioClips)
        {
            AudioSource newAD = gameObject.AddComponent<AudioSource>();
            newAD.clip = clip;
            newAD.playOnAwake = false;
            newAD.loop = false;
            audioSources.Add(newAD);
        }

        var SFXUserPref = PlayerPrefs.GetString(SFXON);
        if (string.IsNullOrEmpty(SFXUserPref))
        {
            PlayerPrefs.SetString(SFXON, defaultSFXOn.ToString());
            SFXUserPref = defaultSFXOn.ToString();
        }

        _SFXOn = SFXUserPref.Equals("true", System.StringComparison.CurrentCultureIgnoreCase);

        bgMusicSrc = gameObject.AddComponent<AudioSource>();
        bgMusicSrc.clip = bgMusic;
        bgMusicSrc.loop = true;
        bgMusicSrc.volume = BackgroundVolume;

        if (_SFXOn && playBGOnAwake)
        {
            bgMusicSrc.Play();
        }
        
    }

    public void PlaySound(SoundEffect sound)
    {
        PlaySound((int)sound);
    }

    public void PlaySound(int sound)
    {
        if (_SFXOn)
        {
            if (!audioSources[sound].isPlaying)
            { audioSources[sound].Play(); }
        }
    }

    public void UpdateSFXOn()
    {
        _SFXOn = PlayerPrefs.GetString("SFXOn").Equals("true");
    }

    public void TurnSoundOn()
    {
        PlayerPrefs.SetString("SFSOn", "true");
    }

    public void TurnSoundOff()
    {
        PlayerPrefs.SetString("SFSOn", "false");
    }

    public void StopBGMusic()
    {
        bgMusicSrc.Stop();
    }

    public void StartBGMusic()
    {
        bgMusicSrc.Play();
    }

    public void PauseBGMusic()
    {
        bgMusicSrc.Pause();
    }

    public void UnPauseBGMusic()
    {
        bgMusicSrc.UnPause();
    }

}
