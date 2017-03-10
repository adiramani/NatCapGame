using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    int[] coordinate = new int[2];
    public Dictionary<MapModeCanvas.MapMode, int> scores = new Dictionary<MapModeCanvas.MapMode, int>();
    public Dictionary<MapModeCanvas.MapMode, Color> colorCache = new Dictionary<MapModeCanvas.MapMode, Color>();
    public Color tileColor;
    SpriteRenderer spriteRenderer;

    LevelManager levelManager;
    LevelEditor levelEditor;
    MapModeCanvas mapModeCanvas;

    // Use this for initialization
    void Start() {
        scores[MapModeCanvas.MapMode.PortExpansion] = 0;
        scores[MapModeCanvas.MapMode.MineralExtraction] = 0;
        scores[MapModeCanvas.MapMode.FoodSecurity] = 0;
        scores[MapModeCanvas.MapMode.TourismPotential] = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelEditor = GameObject.Find("EditorCanvas").GetComponent<LevelEditor>();
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();

        calculateAllColors();
        changeColor(colorCache[mapModeCanvas.currentMode]);
    }

    public void setup(int x, int y) {
        coordinate[0] = x;
        coordinate[1] = y;
    }

    void calculateAllColors() {
        Color colorScheme = levelManager.gridColorScheme;
        colorCache[MapModeCanvas.MapMode.PortExpansion] = calculateColor(0, colorScheme);
        colorCache[MapModeCanvas.MapMode.MineralExtraction] = calculateColor(0, colorScheme);
        colorCache[MapModeCanvas.MapMode.FoodSecurity] = calculateColor(0, colorScheme);
        colorCache[MapModeCanvas.MapMode.TourismPotential] = calculateColor(0, colorScheme);
    }

    public Color calculateColor(int score, Color colorScheme) {
        return new Color(
            colorScheme.r * score / levelManager.maxTileScore,
            colorScheme.g * score / levelManager.maxTileScore,
            colorScheme.b * score / levelManager.maxTileScore,
            levelManager.tileOpacity
        );
    }

    public void changeColor(Color newColor) {
        tileColor = newColor;
        spriteRenderer.color = tileColor;
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseDown() {
        Debug.Log("Click! " + gameObject.name);
        if(levelEditor.editing) {
            scores[mapModeCanvas.currentMode] = levelEditor.currentValue;
            Color newColor = calculateColor(scores[mapModeCanvas.currentMode], levelManager.gridColorScheme);
            colorCache[mapModeCanvas.currentMode] = newColor;
            changeColor(newColor);
        }
    }
}
