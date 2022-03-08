using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start() => gameObject.SetActive(false);

    public void ToogleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = $"{(int)score}m";
    }

    public void Restart()
    {
        Debug.Log("restart clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMenu()
    {
        Debug.Log("menu clicked");

        SceneManager.LoadScene("Menu");
    }

}