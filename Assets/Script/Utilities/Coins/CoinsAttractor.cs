
using UnityEngine;

public class CoinsAttractor : MonoBehaviour
{
    public static float AttractorSpeed = 10;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                other.transform.position,
                20 * Time.deltaTime
            );

            GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
            Invoke("isObjectActive", .1f);

            Invoke("RemoveObject", 1f);
        }
    }

    public static void setSpeed(float speed)
    {
        AttractorSpeed = speed;
    }


    void isObjectActive() => gameObject.SetActive(false);


    void RemoveObject() => Destroy(gameObject);

    private void Update()
    {

    }
}
