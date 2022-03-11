using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostUpTrigger : MonoBehaviour
{
    float duration = 5f;


    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                other.transform.position,
                20 * Time.deltaTime
            );

            Invoke("isObjectActive", .05f);
            Invoke("RemoveObject", 1f);

            int randomBoost = Random.Range(0, 2);


            if (randomBoost == 0)
            {
                // BoostUpMessage.setMessage($"Magnet Koin");

                Invoke("MagnetMessage", 5f);

                StartCoroutine(CoinsAttractor.AttractAllCoins());
            }
            else
            {
                // BoostUpMessage.setMessage($"Koin Ganda");
                Invoke("DoubleCoinMessage", 5f);

                StartCoroutine(CoinsAttractor.DoubleCoins());
            }

        }
    }

    void MagnetMessage() => BoostUpMessage.setMessage($"Magnet Koin");
    void DoubleCoinMessage() => BoostUpMessage.setMessage($"Koin Ganda");



    float BoostDuration(float seconds) => seconds != 0 ? seconds - Time.deltaTime : 0;

    void isObjectActive() => gameObject.SetActive(false);


    void RemoveObject() => Destroy(gameObject);

    // Update is called once per frame
}
