using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    public int mapSize = 30;

    CameraController cameraController;

    void Start () {
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();

        Bounds bounds = gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
        float spriteSize = bounds.size.x;
        gameObject.transform.localScale = new Vector3(mapSize / spriteSize, mapSize / spriteSize, 1);
    }
	
	void Update () {

    }
}
