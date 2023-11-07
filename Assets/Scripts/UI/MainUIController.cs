using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] private MainMenuViewShown viewSelected;
    [SerializeField] GameObject[] views;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle soundFxToggle;
    [SerializeField] private Toggle musicToggle;

    private void Start()
    {
        PersistenceManager.Instance.DeleteAll();
        LoadPersistedValues();
    }

    public void LoadPersistedValues()
    {
        volumeSlider.value = PersistenceManager.Instance.GetFloat(GameManager.Instance.PersistenceKeys.VolumeKey, 0.5f);
        soundFxToggle.isOn = PersistenceManager.Instance.GetBool(GameManager.Instance.PersistenceKeys.SoundFXKey, true);
        musicToggle.isOn = PersistenceManager.Instance.GetBool(GameManager.Instance.PersistenceKeys.MusicKey, true);
    }
    public void OpenCredits()
    {
        GoToOption(MainMenuViewShown.CREDITS);
    }
    public void OpenOptions()
    {
        GoToOption(MainMenuViewShown.OPTIONS);
    }

    public void OpenMainMenu()
    {
        GoToOption(MainMenuViewShown.MAIN);
    }
    private void OnEnable()
    {
        highScoreText.text = "High Score: " + GameManager.Instance.GetHighScore();
        LoadPersistedValues();
        UpdateView();
    }

    private void GoToOption(MainMenuViewShown option)
    {
        viewSelected = option;
        UpdateView();
    }

    private void UpdateView()
    {
        switch (viewSelected) {
            case MainMenuViewShown.CREDITS:
                views[0].SetActive(false);
                views[1].SetActive(false);
                views[2].SetActive(true);
                break;
            case MainMenuViewShown.OPTIONS:
                views[0].SetActive(false);
                views[1].SetActive(true);
                views[2].SetActive(false);
                break;
            case MainMenuViewShown.MAIN:
            default:
                views[0].SetActive(true);
                views[1].SetActive(false);
                views[2].SetActive(false);
                break;
        }
    }

    public void SaveMusicConfig(bool status)
    {
        PersistenceManager.Instance.SaveMusicConfig(status);
    }

    public void SaveSoundFxConfig(bool status)
    {
        PersistenceManager.Instance.SaveSoundFxConfig(status);
    }

    public void SaveVolumeConfig(float volume)
    {
        PersistenceManager.Instance.SaveVolumeConfig(volume);
    }

    public void LoadNextScene()
    {
        ApplicationManager.Instance.GoToNextScene();
    }

}

public enum MainMenuViewShown
{
    MAIN,
    OPTIONS,
    CREDITS
}