using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostUpMessage : MonoBehaviour
{
    public static TextMeshProUGUI boostMessage;

    public TextMeshProUGUI message;

    void Start()
    {
        boostMessage = message;
        boostMessage.text = "";
    }

    // Update is called once per frame

    public static void setMessage(string message)
    {
        boostMessage.text = message;
    }
}
