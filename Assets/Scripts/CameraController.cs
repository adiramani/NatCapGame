using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float zoomSensitivity = 100.0f;
    public float moveSensitivity = 1.0f;
    public float zoomRatio = 1.7f / 30f;

    float currentZoom;

    Camera camera;

	// Use this for initialization
	void Start () {
        camera = gameObject.GetComponent<Camera>();
        currentZoom = camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        // Scroll wheel for zooming in/out
        float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        if(zoom != 0) {
            camera.orthographicSize -= zoom;
            currentZoom = camera.orthographicSize;
        }

        // Hold right-mouse to move view
        if(Input.GetMouseButton(1)) {
            float horizontalMovement = Input.GetAxis("Mouse X") * moveSensitivity * zoomRatio * currentZoom;
            float verticalMovement = Input.GetAxis("Mouse Y") * moveSensitivity * zoomRatio * currentZoom;
            if(horizontalMovement != 0 && verticalMovement != 0) {
                camera.transform.Translate(-1 * horizontalMovement, -1 * verticalMovement, 0);
            }
        }
    }
}
