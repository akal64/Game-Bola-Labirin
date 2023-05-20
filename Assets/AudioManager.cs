using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource sfxAudio;
    private bool isPlaying = false;
    private bool isMuted = false;
    private float volume = 1f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(bgmAudioSource);
            DontDestroyOnLoad(sfxAudio);
            PlayBGM();

        }
    }


    void Start()
    {
        bgmAudioSource.loop = true;

        if (PlayerPrefs.HasKey("is_muted"))
        {
            isMuted = PlayerPrefs.GetInt("is_muted") == 1;
        }

        if (PlayerPrefs.HasKey("volume"))
        {
            volume = PlayerPrefs.GetFloat("volume");
        }
        SetMute(isMuted);
        SetVolume(volume);
    }

    public void PlayBGM()
    {
        bgmAudioSource.Play();
        isPlaying = true;
    }

    public void StopBGM()
    {
        bgmAudioSource.Stop();
        isPlaying = false;
    }
    public void ReplayBGM()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.Play();
    }

    public void SetMute(bool isMuted)
    {
        bgmAudioSource.volume = isMuted ? 0 : volume;
        this.isMuted = isMuted;

        PlayerPrefs.SetInt("is_muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetVolume(float volume)
    {
        bgmAudioSource.volume = volume;
        this.volume = volume;

        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    public float GetVolume()
    {
        return volume;
    }

}
