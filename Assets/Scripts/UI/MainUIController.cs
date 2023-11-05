using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = "High Score: " + GameManager.Instance.GetHighScore();
    }
    public void LoadNextScene()
    {
        ApplicationManager.Instance.GoToNextScene();
    }
}
