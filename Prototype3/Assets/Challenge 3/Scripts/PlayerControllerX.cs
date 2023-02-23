using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 1;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    public GameObject mainCamera;
    

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    private AudioSource bgAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        bgAudio = mainCamera.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
        ApplyForceOutOfBounds();
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            gameOver = true;
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            bgAudio.Stop();
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }
    void ApplyForceOutOfBounds()
    {
        if (transform.position.y < 0)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }else if(transform.position.y > 14)
        {
            playerRb.AddForce(Vector3.down * floatForce, ForceMode.Impulse);
        }
        
    }

}
