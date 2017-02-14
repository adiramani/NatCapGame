using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
    public static int LEVELS = 6;
    public int[] tileValues;
    public Color[] levelColors;
    // Use this for initialization
    void Start() {
        tileValues = new int[LEVELS];
        levelColors = new Color[LEVELS];
        for (int i = 0; i < LEVELS; i++) {
            levelColors[i] = new Color(1 - .15F * i, 1 - .15F * i, 1 - .15F * i, 1);
        }
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseDown() {
        if (tileValues[0] == LEVELS - 1) {
            tileValues[0] = 0;
        }else {
            tileValues[0]++;
        }
        GetComponent<SpriteRenderer>().color = levelColors[tileValues[0]];
    }

    //void OnMouseDown()
    //{
    //    GetComponent<SpriteRenderer>().color = Color.black;
    //}

    //void OnMouseUp()
    //{
    //    GetComponent<SpriteRenderer>().color = Color.white;

    //}
}
