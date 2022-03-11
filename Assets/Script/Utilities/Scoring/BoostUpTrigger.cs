using UnityEngine;


public class BoostUpTrigger : MonoBehaviour
{
    float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                other.transform.position,
                20 * Time.deltaTime
            );
            // StartCoroutine(Message());



            CoinsAttractor coin = gameObject.AddComponent<CoinsAttractor>();
            coin.AttractCoins();
            StartCoroutine(coin.DisableAttractCoins());

            Invoke("isObjectActive", .05f);
            Invoke("RemoveObject", 1f);

        }
    }

    // IEnumerator Message()
    // {
    //     BoostUpMessage.setMessage($"Magnet Koin");
    //     yield return new WaitForSeconds(3f);
    //     BoostUpMessage.setMessage("");
    //     yield return null;
    // }

    float BoostDuration(float seconds) => seconds != 0 ? seconds - Time.deltaTime : 0;

    void isObjectActive() => gameObject.SetActive(false);


    void RemoveObject() => Destroy(gameObject);


}
