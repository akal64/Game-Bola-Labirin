using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject setting, howtoplay;
    [SerializeField] Slider slidervolume;
    public Toggle muteToggle;

    private AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        muteToggle.isOn = audioManager.IsMuted();
        slidervolume.value = audioManager.GetVolume();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OpenSetting()
    {
        setting.SetActive(true);
    }
    public void SetVolume(float volume)
    {
        audioManager.SetVolume(slidervolume.value);
    }
    public void CloseSetting()
    {
        setting.gameObject.SetActive(false);
    }
    public void OpenHowTo()
    {
        howtoplay.SetActive(true);
    }
    public void CloseHowTo()
    {
        howtoplay.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnMuteToggle(bool isMuted)
    {
        audioManager.SetMute(muteToggle.isOn); audioManager.SetMute(muteToggle.isOn);
    }

}
