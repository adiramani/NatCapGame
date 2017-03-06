using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
    int[] coordinate = new int[2];
    public Color tileColor;
    SpriteRenderer spriteRenderer;
    LevelManager levelManager;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        float intensity = levelManager.levelData[coordinate[0], coordinate[1]];
        setValue(intensity);
    }

    public void setup(int x, int y) {
        coordinate[0] = x;
        coordinate[1] = y;
    }

    public void setValue(float intensity) {
        Color colorScheme = levelManager.gridColorScheme;
        tileColor = new Color(
            colorScheme.r * intensity / levelManager.maxTileScore,
            colorScheme.g * intensity / levelManager.maxTileScore,
            colorScheme.b * intensity / levelManager.maxTileScore,
            levelManager.tileOpacity
        );
        spriteRenderer.color = tileColor;
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseDown() {
        Debug.Log("Click! " + gameObject.name);
        spriteRenderer.color = Random.ColorHSV();
    }
}
