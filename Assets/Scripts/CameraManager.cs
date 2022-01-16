using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public float movementSpeed = 0.5f;
    float sceneLoadTime,
            currentTime,
            timeDiff;

    private void Start() {
        sceneLoadTime = Time.time;
    }

    private void Update() {
        moveCameraPosition();
    }

    void moveCameraPosition(){
        currentTime = Time.time;
        timeDiff = ((currentTime - sceneLoadTime)/10)/10;
        // Debug.Log("Level Loaded Time : "+Time.timeSinceLevelLoad);
        // Debug.Log("Frame Started time : "+Time.time);
        Debug.Log("Movement Speed : "+(movementSpeed + timeDiff).ToString("0.0"));
        Vector3 currentCameraPosition =  gameObject.transform.position;
        currentCameraPosition.y += (movementSpeed + timeDiff) * Time.deltaTime;
        transform.position = currentCameraPosition;
    }
}
