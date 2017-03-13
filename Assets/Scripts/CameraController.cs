using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float zoomSensitivity = 5.0f;
    public float moveSensitivity = 0.8f;
    public float zoomRatio = 1.7f / 30f;

    public float minZoom = 1.0f;
    public float maxZoom = 20.0f;

    float currentZoom;

    Camera camera;
    
	void Start () {
        camera = gameObject.GetComponent<Camera>();
        currentZoom = camera.orthographicSize;
	}
	
	void Update () {
        // Scroll wheel for zooming in/out
        float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        if (zoom != 0 && camera.orthographicSize - zoom > minZoom && camera.orthographicSize - zoom < maxZoom) {
            camera.orthographicSize -= zoom;
            currentZoom = camera.orthographicSize;
        }

        // Hold right-mouse to move view
        if (Input.GetMouseButton(1)) {
            float horizontalMovement = Input.GetAxis("Mouse X") * moveSensitivity * zoomRatio * currentZoom;
            float verticalMovement = Input.GetAxis("Mouse Y") * moveSensitivity * zoomRatio * currentZoom;
            if(horizontalMovement != 0 && verticalMovement != 0) {
                camera.transform.Translate(-1 * horizontalMovement, -1 * verticalMovement, 0);
            }
        }
    }
}
