using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    public int mapSize = 30;

	// Use this for initialization
	void Start () {
        Bounds bounds = gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
        float spriteSize = bounds.size.x;
        gameObject.transform.localScale = new Vector3(mapSize / spriteSize, mapSize / spriteSize, 1);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
