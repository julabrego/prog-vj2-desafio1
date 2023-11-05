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
        if(GameManager.Instance != null)
        {
            highScoreText.text = "High Score: " + GameManager.Instance.GetHighScore();
        }
        else
        {
            Destroy(highScoreText);
        }
    }
    public void LoadNextScene()
    {
        ApplicationManager.Instance.GoToNextScene();
    }
}
