using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
