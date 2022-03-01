using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVector;
    float gravity = 12.0f;

    float speed = 5.0f;
    float verticalVelocity = 0f;
    float animationDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        else
        {
            moveVector = Vector3.zero;

            if (controller.isGrounded)
            {
                // Debug.Log("is grounded");
                verticalVelocity = -gravity * 0.1f;
            }
            else
            {
                // Debug.Log("is Not grounded");
                verticalVelocity -= gravity * Time.deltaTime;
            }

            // not readable
            moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            // Debug.Log(moveVector.x);

            controller.Move(Vector3.forward * Time.deltaTime * speed);
        }


    }
}
