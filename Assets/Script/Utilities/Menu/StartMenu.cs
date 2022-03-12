using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StartMenu : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;
    public Image startButton;

    void Start()
    {
        highScoreText.text = $"Highscore : {(int)PlayerPrefs.GetFloat("Score")}";
    }

    public void OnEnterImage() => startButton.color = new Color(166, 0, 0, 239);
    public void OnExitImage() => startButton.color = new Color(166, 0, 0, 0);

    public void PlayGame() => SceneManager.LoadScene("GamePlay");

}
