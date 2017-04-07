using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    public int mapSize = 30;

    CameraController cameraController;

    private bool dragging = false;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Start () {
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();

        Bounds bounds = gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
        float spriteSize = bounds.size.x;
        gameObject.transform.localScale = new Vector3(mapSize / spriteSize, mapSize / spriteSize, 1);
    }
	
	void Update () {
        if(cameraController.frozen) {
            dragging = false;
            return;
        }

        // mouse down: start drag
        if(Input.GetMouseButtonDown(1)) {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

            dragging = true;
        }

        // tap begin: start drag
        if (Input.touchCount == 1 && !dragging) {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z));

            dragging = true;
        }
        
        // mouse up, tap end, or more than 1 tap: stop drag
        // need to end when more than 1 finger, otherwise camera jumps a lot between fingers!
        if(Input.GetMouseButtonUp(1) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.touchCount > 1) {
            dragging = false;
        }

        // dragging with mouse:
        if(dragging && Input.touchCount == 0) {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }

        // dragging with finger:
        if(dragging && Input.touchCount > 0) {
            Vector3 curScreenPoint = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
}
