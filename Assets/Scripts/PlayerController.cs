using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerHspeed = 5,
                playerVspeed = 5;
    public Sprite[] playerJumpSprite,
                playerReadySprite;
    public GameMenuController gameControler;
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
        if(playerHmovement != 0){
            Vector3 playerPosition = transform.position;
            playerPosition.x += playerHspeed * playerHmovement * Time.deltaTime;
            transform.position = playerPosition;
        }

        if(playerVmovement > 0 && !inAir){
            Vector2 playerVelocity =  rb.velocity;
            playerVelocity.y = playerVspeed;
            rb.velocity = playerVelocity;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerJumpSprite[Manager.GameManagerObj.playerTypeIndex];
            inAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Floor" || other.gameObject.tag == "Platform"){
            inAir = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerReadySprite[Manager.GameManagerObj.playerTypeIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.transform.GetComponentInParent<PlatformController>() != null){
            PlatformController platformObj = other.gameObject.transform.GetComponentInParent<PlatformController>();
            gameControler.AddScore(platformObj.ScoreValue);
            platformObj.DestroySpawnCoin();
        }
    }
}
