using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

    public bool frozen = false; // frozen if dragging game piece

    public float pinchSensitivity = 0.001f;
    public float mouseZoomSensitivity = 5.0f;
    
    public float minZoom = 5.0f;
    public float maxZoom = 20.0f;

    float currentZoom;

    Camera camera;

    void Start () {
        camera = gameObject.GetComponent<Camera>();
        currentZoom = camera.orthographicSize;
	}
	
	void Update () {
        if(frozen)
            return;

        // Scroll wheel for zooming in/out
        float zoom = Input.GetAxis("Mouse ScrollWheel") * mouseZoomSensitivity;
        if(zoom != 0 && camera.orthographicSize - zoom > minZoom && camera.orthographicSize - zoom < maxZoom) {
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - zoom, minZoom, maxZoom);
            currentZoom = camera.orthographicSize;
        }

        // Pinch to zoom, from http://answers.unity3d.com/questions/63909/pinch-zoom-camera.html
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

    public static bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 1; // will always be at least 1 because of the grid ui
    }
}
