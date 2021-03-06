using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DeathMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public Image buttonMenu;
    public Image buttonPlayAgain;


    void Start() => gameObject.SetActive(false);

    public void ToogleEndMenu(float score)
    {

        float prevHighscore = PlayerPrefs.GetFloat("Score");
        PlayerPrefs.SetFloat("Score", prevHighscore > score ? prevHighscore : score);
        gameObject.SetActive(true);
        scoreText.text = $"{(int)score}pt";
    }

    public void OnEnterImageMenu() => buttonMenu.color = new Color(166, 0, 0, 239);
    public void OnExitImageMenu() => buttonMenu.color = new Color(166, 0, 0, 0);

    public void OnEnterImagePlay() => buttonPlayAgain.color = new Color(166, 0, 0, 239);
    public void OnExitImagePlay() => buttonPlayAgain.color = new Color(166, 0, 0, 0);


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CoinsCounts.removeCoins();
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}