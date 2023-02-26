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
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    
    

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
        if (isOnGround == false)
        {
            dirtSplatter.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //give the player a movement in y axis as the user presses space
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
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
   
}
