using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables
    Rigidbody playerRb;
    Animator playerAnim;
    AudioSource playerAudio;
    AudioSource cameraAudio;
    public GameObject mainCamera;
    public ParticleSystem playerExplosion;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip gameOverSound;
    public float jumpForce = 20;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public bool doubleJumpUsed = false;
    float doubleJumpForce = 300;
 
    // Start is called before the first frame update
    void Start()
    {
        
        cameraAudio = mainCamera.GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            dirtSplatter.Stop();
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerExplosion.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            cameraAudio.Stop();
            playerAudio.PlayOneShot(gameOverSound, 0.5f);
        }
        
    }

    public void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //give the player a movement in y axis as the user presses space
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            doubleJumpUsed = false;
        } 
        else if(Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump", 3, 0f);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }


    }
    

}
