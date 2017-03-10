using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    int[] coordinate = new int[2];
    // tile scores and the color cache are stored as dictionaries where the indexes are MapMaps
    public Dictionary<MapModeCanvas.MapMode, int> scores = new Dictionary<MapModeCanvas.MapMode, int>();
    // color cache exists because it is really slow to recalculate color values when switching mapmode
    public Dictionary<MapModeCanvas.MapMode, Color> colorCache = new Dictionary<MapModeCanvas.MapMode, Color>();
    SpriteRenderer spriteRenderer;

    LevelManager levelManager;
    LevelEditor levelEditor;
    MapModeCanvas mapModeCanvas;
    
    void Start() {
        // set all scores to zero initially
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
        spriteRenderer.color = newColor;
    }
    
    void OnMouseDown() {
        Debug.Log("Click! " + gameObject.name);
        /* When a tile is clicked during editing:
         * 1) current score updated for current map mode
         * 2) new color is calculated, cached, and set
         */
        if(levelEditor.editing) {
            scores[mapModeCanvas.currentMode] = levelEditor.currentValue;
            Color newColor = calculateColor(scores[mapModeCanvas.currentMode], levelManager.gridColorScheme);
            colorCache[mapModeCanvas.currentMode] = newColor;
            changeColor(newColor);
        }
    }
}
