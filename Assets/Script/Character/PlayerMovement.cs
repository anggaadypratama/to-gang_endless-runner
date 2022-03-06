
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVector = Vector3.zero;
    float gravity = 1f;
    float speed = 4.0f;
    float verticalVelocity = 0f;
    float animationDuration = 3f;
    float jumpHeight = .4f;
    float gravityValue = -9.81f;
    bool isDeath = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;

        if (isDeath) return;

        if (isMove())
        {
            moveVector.y = -0.5f;
            moveVector.z = speed;
            controller.Move(moveVector * speed * Time.deltaTime);
            return;
        }
        else
        {
            grounded(isGrounded);
            jump(isGrounded);

            moveVector.x = Input.GetAxisRaw("Horizontal") * 2;
            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            controller.Move(moveVector * Time.deltaTime * speed);
        }
    }


    void jump(bool isGrounded)
    {

        if (Input.GetButton("Jump") && isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        else
        {
            verticalVelocity += gravityValue * Time.deltaTime;
        }
    }

    void grounded(bool isGrounded)
    {
        if (isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
    }

    public void setSpeed(float modifier)
    {
        Debug.Log(speed);
        speed = 4f + modifier;
    }

    public bool isMove() => Time.time < animationDuration;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy") Death();
    }

    void Death()
    {
        isDeath = true;
        GetComponent<Score>().OnDeath();
    }
}
