using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISoundManager : MonoBehaviour
{

    [Header("MusicBtn")]
    public GameObject musicBtnOn;

    [Header("SFXBtn")]
    public GameObject SFXBtnOn;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == ("MainMenu"))
        {
            if (!AudioManager.Instance.musicSource.mute)
            {
                musicBtnOn.SetActive(true);
            }
            else
            {
                musicBtnOn.SetActive(false);
            }

            if (!AudioManager.Instance.sfxSource.mute)
            {
                SFXBtnOn.SetActive(true);
            }
            else
            {
                SFXBtnOn.SetActive(false);
            }
        }
    }

    public void BtnMusic()
    {
        AudioManager.Instance.ToogleMusic();
    }
    public void BtnSFX()
    {
        AudioManager.Instance.ToogleSFX();
    }


    public void BtnPauseSound()
    {
        AudioManager.Instance.PauseSound();
    }

    public void BtnResumeSound()
    {
        AudioManager.Instance.ResumeSound();
    }
}
