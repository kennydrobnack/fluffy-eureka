using UnityEngine;
using System.Collections.Generic;

public enum SoundEffect { Boom };

public class SFXController : MonoBehaviour
{

    [SerializeField]
    private List<AudioClip> audioClips;
    [SerializeField]
    private AudioClip bgMusic;
    [SerializeField]
    private bool defaultSFXOn = true;

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
        if (_SFXOn)
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
            audioSources[sound].Play();
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

}
