using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float pinchSensitivity = 5.0f;
    public float mouseZoomSensitivity = 5.0f;
    public float fingerMoveSensitivity = 0.8f;
    public float mouseMoveSensitivity = 0.8f;

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
        float zoom = Input.GetAxis("Mouse ScrollWheel") * mouseZoomSensitivity;
        if(zoom != 0 && camera.orthographicSize - zoom > minZoom && camera.orthographicSize - zoom < maxZoom) {
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - zoom, minZoom, maxZoom);
            currentZoom = camera.orthographicSize;
        }

        // Hold right-mouse to move view
        if(Input.GetMouseButton(1)) {
            float horizontalMovement = Input.GetAxis("Mouse X") * mouseMoveSensitivity * zoomRatio * currentZoom;
            float verticalMovement = Input.GetAxis("Mouse Y") * mouseMoveSensitivity * zoomRatio * currentZoom;
            if(horizontalMovement != 0 && verticalMovement != 0) {
                camera.transform.Translate(-1 * horizontalMovement, -1 * verticalMovement, 0);
            }
        }

        // Touchscreen camera movement
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            float horizontalMovement = Input.GetTouch(0).deltaPosition.x * fingerMoveSensitivity * zoomRatio * currentZoom;
            float verticalMovement = Input.GetTouch(0).deltaPosition.y * fingerMoveSensitivity * zoomRatio * currentZoom;
            Debug.Log("Touch: " + horizontalMovement + ", " + verticalMovement);
            if (horizontalMovement != 0 && verticalMovement != 0) {
                camera.transform.Translate(-1 * horizontalMovement, -1 * verticalMovement, 0);
            }
        }

        // Pinch to zoom, from http://answers.unity3d.com/questions/63909/pinch-zoom-camera.html
        // Debug.Log("TouchCount: " + Input.touchCount + "\nTouchPhase: " + (Input.touchCount > 0 ? Input.GetTouch(0).phase.ToString() : "none"));
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) {
            Vector2 curDist = Input.GetTouch(0).position - Input.GetTouch(1).position; // current distance between finger touches
            Vector2 prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition)); // difference in previous locations using delta positions
            float touchDelta = curDist.magnitude - prevDist.magnitude;
            float zoomAmount = touchDelta / Input.GetTouch(0).deltaTime;

            // Debug.Log("zA: " + zoomAmount);
            
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - zoomAmount * pinchSensitivity, minZoom, maxZoom);
            currentZoom = camera.orthographicSize;
        }
    }
}
