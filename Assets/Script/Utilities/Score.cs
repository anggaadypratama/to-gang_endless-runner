
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    float score = 0f;
    int difficultLevel = 1;
    int maxDifficultLevel = 10;
    int scoreToNextLevel = 10;
    public TextMeshProUGUI scoreText;

    bool isDeath = false;


    // Update is called once per frame
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

        scoreToNextLevel *= 2;
        difficultLevel++;

        GetComponent<PlayerMovement>().setSpeed((float)difficultLevel);
    }

    public void OnDeath()
    {
        isDeath = true;
    }
}
