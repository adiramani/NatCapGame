using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
    public Color tileColor;
    SpriteRenderer spriteRenderer;
    LevelManager levelManager;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void setValue(float intensity) {
        Color colorScheme = levelManager.getColorScheme();
        tileColor = new Color(colorScheme.r * intensity, colorScheme.g * intensity, colorScheme.b * intensity, levelManager.tileOpacity);
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
