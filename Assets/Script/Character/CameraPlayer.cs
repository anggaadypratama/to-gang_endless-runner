
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    Transform lookAt;
    Vector3 startOffset;
    Vector3 moveVector;

    float animationDuration = 2f;
    float transition = 0f;
    Vector3 animationOffset = new Vector3(0, 5, 5);


    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
        Debug.Log(startOffset);
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
