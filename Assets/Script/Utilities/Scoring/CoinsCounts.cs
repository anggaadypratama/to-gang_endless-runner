using System.Collections;
using System.Collections.Generic;
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

    public static void setCoins(float coins)
    {
        coinsScore += coins;
    }
}
