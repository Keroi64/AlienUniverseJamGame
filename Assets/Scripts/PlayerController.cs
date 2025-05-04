using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float gravity = -14f;
    public int PlayerHealth = 100;

    private Vector3 gravityVector;

    //GroundCheck
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.35f;
    public LayerMask groundLayer;

    public bool isGrounded = false;
    public float jumpSpeed = 7f;

    //UI
    public Slider healthSlider;
    public Text healthText;
    public CanvasGroup damageScreenUI;

    //GM
    private GameManager gameManager;
    public AudioSource playerHurtSound;
    public AudioSource playerFootstepSound;
    




    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gameManager = FindAnyObjectByType<GameManager>();
        damageScreenUI.alpha = 0f;

    }


    void Update()
    {

        MovePlayer();
        GroundCheck();
        JumpAndGravity();
        DamageScreenCleaner();
        

    }

    void MovePlayer()
    {
        Vector3 moveVector = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        // Hareket varsa ve yerdeyse ses çalsın
        if (moveVector.magnitude > 0.1f && isGrounded)
        {
            if (!playerFootstepSound.isPlaying)
            {
                playerFootstepSound.Play();
            }
        }
        else
        {
            playerFootstepSound.Stop();
        }
        characterController.Move(moveVector * speed * Time.deltaTime);

    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    void JumpAndGravity()
    {
        gravityVector.y += gravity * Time.deltaTime;

        characterController.Move(gravityVector * Time.deltaTime);

        if (isGrounded && gravityVector.y < 0)
        {
            gravityVector.y = -3f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVector.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }
    }


    public void PlayerTakeDamage(int DamageAmount)
    {
        PlayerHealth -= DamageAmount;
        healthSlider.value -= DamageAmount;
        HealthTextUpdate();
        damageScreenUI.alpha = 1f;
        playerHurtSound.Play();

        if (PlayerHealth <= 0)
        {
            PlayerDeath();
            HealthTextUpdate();
            healthSlider.value = 0;

        }
    }
    void PlayerDeath()
    {
        gameManager.RestartGame();
    }

    void HealthTextUpdate()
    {
        healthText.text = PlayerHealth.ToString();
    }
    void DamageScreenCleaner()
    {
        if(damageScreenUI.alpha > 0)
        {
            damageScreenUI.alpha -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            
        }
        

    }
}
