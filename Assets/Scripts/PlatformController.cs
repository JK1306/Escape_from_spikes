using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Sprite destroyableObj;
    public int ScoreValue;
    public bool isDestroyable = false,
                isMovable = false,
                isScorable = false,
                moveRight = true;
    public float waitForTimeOut = 4,
                maxX = 0,
                minX = 0, 
                movementSpeed = 0.025f;
    Vector2 maxScreen,
            minScreen;
    int hitNum = 0;
        // contactCount = 0;

    private void Start() {
        ScoreValue = 10;
    }

    private void FixedUpdate() {
        if(isMovable){
            MovePlatform();
        }
    }

    private void Update() {
        getMinCord();
        checkInRange();
    }

    private void checkInRange()
    {
        if(transform.position.y < minScreen.y){
            Destroy(gameObject);
        }
    }

    public void SetMovable(){
        isMovable = true;
        getMaxCord();
        getMinCord();
        minX = minScreen.x;
        maxX = maxScreen.x;
        ScoreValue = 0;
    }

    public void getMaxCord(){
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public void getMinCord(){
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
    }

    public void DestroySpawnCoin(){
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }

    private void MovePlatform()
    {  
        Vector3 currentPosition = transform.position;

        if(currentPosition.x >= maxX && currentPosition.x >= minX && moveRight){
            moveRight = false;
        }else if(currentPosition.x <= minX && currentPosition.x <= maxX && !moveRight){
            moveRight = true;
        }

        if(moveRight){
            currentPosition.x += movementSpeed;
        }else{
            currentPosition.x -= movementSpeed;
        }
  
        transform.position = currentPosition;
    }

    IEnumerator destroyTimeOut(){
        yield return new WaitForSeconds(waitForTimeOut);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Destroyable Platform destroy
        if(isDestroyable && other.gameObject.GetComponent<PlayerController>() != null){
            GetComponent<SpriteRenderer>().sprite = destroyableObj;
            StartCoroutine(destroyTimeOut());
            hitNum++;
            if(hitNum > 2){
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        // character movement when it stay in movable platform
        if(isMovable){
            if(other.gameObject.GetComponent<PlayerController>() != null){
                Vector2 playerPosition = other.gameObject.transform.position;
                if(moveRight){
                    playerPosition.x += movementSpeed;
                }else{
                    playerPosition.x -= movementSpeed;
                }
                other.gameObject.transform.position = playerPosition;
            }
        }
    }
}
