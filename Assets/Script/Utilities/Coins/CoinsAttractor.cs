
using UnityEngine;
using System.Collections;

public class CoinsAttractor : MonoBehaviour
{

    public static float coinsValue = 1f;
    public static SphereCollider attractCoinArea;

    public AudioSource audioFX;

    private void Start()
    {
        attractCoinArea = GetComponent<SphereCollider>();

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                other.transform.position,
                20 * Time.deltaTime
            );


            Invoke("isObjectActive", .1f);
            Invoke("RemoveObject", 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinsCounts.setCoins(coinsValue);
            audioFX.Play();
        }
    }

    public void AttractCoins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        Debug.Log("Attract Started");
        foreach (GameObject obst in coins)
            obst.GetComponent<SphereCollider>().radius = 20f;
    }

    public IEnumerator DisableAttractCoins()
    {
        yield return new WaitForSeconds(3);

        Debug.Log("Attract Disabled");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject obst in coins)
            obst.GetComponent<SphereCollider>().radius = 1f;
    }


    void isObjectActive() => gameObject.SetActive(false);


    void RemoveObject() => Destroy(gameObject);

}
