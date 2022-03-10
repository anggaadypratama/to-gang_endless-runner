
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    float score = 0f;
    int difficultLevel = 1;
    float speedLevel = 0f;
    int maxDifficultLevel = 10;
    float scoreToNextLevel = 10f;
    public TextMeshProUGUI scoreText;

    bool isDeath = false;
    public DeathMenu deathMenu;

    void Update()
    {

        bool isMove = GetComponent<PlayerMovement>().isMove();
        if (isDeath) return;
        if (score >= scoreToNextLevel) LevelUp();

        score += isMove ? 0 : Time.deltaTime * difficultLevel;
        if (isMove)
        {
            scoreText.gameObject.SetActive(false);
        }
        else
        {
            scoreText.gameObject.SetActive(true);

        }

        scoreText.text = $"{(int)score}m";
    }

    void LevelUp()
    {
        if (difficultLevel == maxDifficultLevel) return;

        scoreToNextLevel *= 2f;
        difficultLevel++;
        speedLevel += 0.2f;

        GetComponent<PlayerMovement>().setSpeed(speedLevel);
        TilesManager.setDifficult(difficultLevel);
    }

    public void OnDeath()
    {
        isDeath = true;
        float prevHighscore = PlayerPrefs.GetFloat("Score");
        PlayerPrefs.SetFloat("Score", prevHighscore > score ? prevHighscore : score);
        Invoke("DeathMenu", 2f);
    }


    void DeathMenu() => deathMenu.ToogleEndMenu(score);
}
