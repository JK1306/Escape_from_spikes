using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerHspeed = 5,
                playerVspeed = 5;
    public Sprite[] playerJumpSprite,
                playerReadySprite,
                playerDeadSprite;
    public GameMenuController gameControler;
    public GameObject gameOverObject;
    Rigidbody2D rb;
    float playerHmovement = 0,
        playerVmovement = 0;
    bool inAir = false;
    void Start()
    {
        Debug.Log("Player Sprite : "+Manager.GameManagerObj.playerSprite);
        rb = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Manager.GameManagerObj.playerSprite;
    }

    void Update()
    {
        playerHmovement = Input.GetAxis("Horizontal");
        playerVmovement = Input.GetAxis("Jump");
    }

    private void FixedUpdate() {
        PlayerMovement();
    }
    void PlayerMovement(){
        // walk movement
        if(playerHmovement != 0){
            Vector3 playerPosition = transform.position;
            playerPosition.x += playerHspeed * playerHmovement * Time.deltaTime;
            transform.position = playerPosition;
        }

        // jump movement
        if(playerVmovement > 0 && !inAir){
            SoundManager.SoundManagerInstance.Play(Sounds.Jump);
            Vector2 playerVelocity =  rb.velocity;
            playerVelocity.y = playerVspeed;
            rb.velocity = playerVelocity;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerJumpSprite[Manager.GameManagerObj.playerTypeIndex];
            inAir = true;
        }
    }

    IEnumerator PlayerDead(){
        gameObject.GetComponent<SpriteRenderer>().sprite = playerDeadSprite[Manager.GameManagerObj.playerTypeIndex];
        Time.timeScale = 0;
        SoundManager.SoundManagerInstance.Play(Sounds.Death);
        gameOverObject.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        gameControler.enableTimeScale();
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Floor" || other.gameObject.tag == "Platform"){
            inAir = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerReadySprite[Manager.GameManagerObj.playerTypeIndex];
        }

        if(other.gameObject.tag == "Spikes"){
            StartCoroutine(PlayerDead());
            Debug.Log("Bunny Dead....!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.transform.GetComponentInParent<PlatformController>() != null){
            SoundManager.SoundManagerInstance.Play(Sounds.AddCoin);
            PlatformController platformObj = other.gameObject.transform.GetComponentInParent<PlatformController>();
            gameControler.AddScore(platformObj.ScoreValue);
            platformObj.DestroySpawnCoin();
        }
    }
}
