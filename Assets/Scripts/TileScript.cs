using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
    int[] coordinate = new int[2];
    public List<int> scores = new List<int>();
    public Color tileColor;
    SpriteRenderer spriteRenderer;
    LevelManager levelManager;
    LevelEditor levelEditor;

    // Use this for initialization
    void Start() {
        scores.Add(0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelEditor = GameObject.Find("EditorCanvas").GetComponent<LevelEditor>();
        setValue(scores[0]);
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
        if(levelEditor.editing) {
            setValue(levelEditor.currentValue);
        }
    }
}
