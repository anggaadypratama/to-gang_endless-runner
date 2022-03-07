using System.Collections;
using UnityEngine;

public class PointLightFlicker : MonoBehaviour
{

    bool isFlickering = false;
    float timeDelay;

    void Update()
    {
        if (!isFlickering) StartCoroutine(FlickeringLight());
    }

    IEnumerator FlickeringLight()
    {
        bool isLightFlickering = GetComponent<Light>().enabled;
        isFlickering = true;
        isLightFlickering = false;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        isLightFlickering = true;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
