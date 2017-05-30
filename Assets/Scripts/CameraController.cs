using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

    public bool frozen = false; // frozen if dragging game piece
    public float zoom = 15.2f;

    Camera camera;

    void Start () {
        camera = gameObject.GetComponent<Camera>();
        camera.orthographicSize = zoom;
	}

    private void Update() {
        camera.orthographicSize = zoom;
    }

    public static bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 1; // will always be at least 1 because of the grid ui
    }
}
