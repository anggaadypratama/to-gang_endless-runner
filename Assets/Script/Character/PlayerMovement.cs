

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVector = Vector3.zero;
    Quaternion originalRotation;

    float gravity = 1f;
    float speed = 3.0f;
    float verticalVelocity = 0f;
    Animator animator;
    float animationDuration = 3f;
    float jumpHeight = .2f;
    float gravityValue = -9.81f;
    float startTime;
    bool isDeath = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        originalRotation = transform.rotation;
        startTime = Time.time;
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;

        if (isDeath)
        {

            return;
        }

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

            float horizontalMovement = Input.GetAxisRaw("Horizontal");


            if (horizontalMovement != 0)
            {
                if (horizontalMovement < 0 && transform.rotation.y >= -45f)
                {
                    transform.Rotate(0.0f, -2f, 0.0f, Space.Self);
                }

                if (horizontalMovement > 0 && transform.rotation.y <= 45f)
                {
                    transform.Rotate(0.0f, 2f, 0.0f, Space.Self);

                }
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * 10);
            }

            moveVector.x = horizontalMovement * 2;
            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            controller.Move(moveVector * Time.deltaTime * speed);
        }
    }

    void jump(bool isGrounded)
    {

        if (Input.GetButton("Jump") && isGrounded)
        {
            animator.SetBool("isJump", true);
            verticalVelocity = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        else
        {
            animator.SetBool("isJump", false);
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
        animator.speed = .8f + (modifier * 1.2f);
        speed = 3f + modifier;
    }

    public bool isMove() => Time.time - startTime < animationDuration;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hitted");
            Death();
        }
    }

    void Death()
    {
        animator.enabled = false;
        isDeath = true;
        GetComponent<Score>().OnDeath();
    }
}
