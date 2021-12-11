using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public float movementSpeed = 0.5f;

    private void Update() {
        moveCameraPosition();
    }

    void moveCameraPosition(){
        Vector3 currentCameraPosition =  gameObject.transform.position;
        currentCameraPosition.y += movementSpeed * Time.deltaTime;
        transform.position = currentCameraPosition;
    }
}
