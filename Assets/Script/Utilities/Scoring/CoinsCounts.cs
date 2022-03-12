using UnityEngine;
using TMPro;

public class CoinsCounts : MonoBehaviour
{
    static float coinsScore = 0f;
    public TextMeshProUGUI coinsCount;

    void Update()
    {
        coinsCount.text = $"Coins : {(int)coinsScore}";
    }

    public static void setCoins(float coin)
    {
        Debug.Log(coin);
        coinsScore += coin;
    }

    public static void removeCoins()
    {
        coinsScore = 0;
    }

    public static float getCoins() => coinsScore;
}
