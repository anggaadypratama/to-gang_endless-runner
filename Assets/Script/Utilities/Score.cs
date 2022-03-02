
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
        if (isDeath) return;
        if (score >= scoreToNextLevel) LevelUp();

        score += GetComponent<PlayerMovement>().isMove() ? 0 : Time.deltaTime * difficultLevel;
        scoreText.text = $"{(int)score}";
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
