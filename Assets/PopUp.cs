using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PopUp : MonoBehaviour
{
    [SerializeField] TMP_Text popuptext;
    [SerializeField] Movement player;
    [SerializeField] GameObject popup;
    public void Popup()
    {
        Time.timeScale = 0;
        if (player.HP == 0)
        {
            popuptext.text = "GAME OVER <br>Anda gagal kabur";
        }
        else
        {
            popuptext.text = "Selamat Anda berhasil kabur! <br>Hp yang tersisa: " + player.HP;

        }
        popup.SetActive(true);

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("InGame");
    }
    public void Back(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
