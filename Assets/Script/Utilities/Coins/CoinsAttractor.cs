
using UnityEngine;
using System.Collections;

public class CoinsAttractor : MonoBehaviour
{

    public static float coinsValue = 1f;
    public static SphereCollider attractCoinArea;

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
        Debug.Log(coinsValue);
        if (other.CompareTag("Player")) CoinsCounts.setCoins(coinsValue);
    }

    public static IEnumerator AttractAllCoins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject obst in coins)
            obst.GetComponent<SphereCollider>().radius = 8f;
        yield return new WaitForSeconds(3f);
        foreach (GameObject obst in coins)
            obst.GetComponent<SphereCollider>().radius = 1f;
    }

    public static IEnumerator DoubleCoins()
    {
        coinsValue = 2f;
        yield return new WaitForSeconds(5f);
        coinsValue = 1f;
        yield return false;
    }

    void isObjectActive() => gameObject.SetActive(false);


    void RemoveObject() => Destroy(gameObject);

}
