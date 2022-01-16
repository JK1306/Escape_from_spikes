// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Vector2 maxScreen,
                minScreen;
    public GameObject spawnPlatform,
                        floor;
    public float platformSpace,
                additionalHeight=5;
    Vector3 spawnStart;

    void Start()
    {
        getMaxCord();
        getMinCord();
        spawnStart = floor.transform.position;
    }

    private void Update() {
        spawnPlatformObject();
        // this will enable platform spawning in upward direction
        getMaxCord();
    }

    bool getProbableOfCoinSpawn(){
        int randVal = Random.Range(1, 5);
        return randVal == 3;
    }

    int getAbility(){
        int randVal = Random.Range(1, 5);
        return randVal;
    }

    void activateAbility(int index, PlatformController pltObj){
        switch(index){
            case 3:
                pltObj.isDestroyable = true;
                break;
            case 4:
                pltObj.SetMovable();
                break;
            default:
                break;
        }
    }

    void spawnPlatformObject(){
        if(((maxScreen.y + additionalHeight) - spawnStart.y) >= platformSpace){
            Vector3 spawnPosition = new Vector3(Random.Range(minScreen.x, maxScreen.x), Random.Range(spawnStart.y, spawnStart.y + platformSpace), 0f);
            GameObject platformInstance = Instantiate(spawnPlatform, spawnPosition, Quaternion.identity);
            spawnStart = spawnPosition;
            spawnStart.y += platformSpace;
            PlatformController pltObj = platformInstance.GetComponent<PlatformController>();
            activateAbility(getAbility(), pltObj);
            if(!getProbableOfCoinSpawn()){
                pltObj.DestroySpawnCoin();
            }
            platformInstance.transform.parent = gameObject.transform;
        }
    }

    public void getMaxCord(){
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        maxScreen.x -= 1;
    }

    public void getMinCord(){
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        minScreen.x += 1;
    }
}
