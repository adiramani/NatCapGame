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
    PiecePlace piecePlace;

    bool hoveringOverTile = false;
    
    void Start() {
        // set all scores to zero initially
        setValues(0, 0, 0, 0);

        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelEditor = GameObject.Find("EditorCanvas").GetComponent<LevelEditor>();
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
        piecePlace = GameObject.Find("LevelManager").GetComponent<PiecePlace>();

        calculateAllColors();
        changeColor(colorCache[mapModeCanvas.currentMode]);
    }

    public void setup(int x, int y) {
        coordinate[0] = x;
        coordinate[1] = y;
    }

    public int getScore(MapModeCanvas.MapMode mapMode) {
        return scores[mapMode];
    }

    public void setValues(int portExpansion, int mineralExtraction, int foodSecurity, int tourismPotential) {
        scores[MapModeCanvas.MapMode.PortExpansion] = portExpansion;
        scores[MapModeCanvas.MapMode.MineralExtraction] = mineralExtraction;
        scores[MapModeCanvas.MapMode.FoodSecurity] = foodSecurity;
        scores[MapModeCanvas.MapMode.TourismPotential] = tourismPotential;
    }

    public void calculateAllColors() {
        colorCache[MapModeCanvas.MapMode.PortExpansion] = calculateColor(scores[MapModeCanvas.MapMode.PortExpansion], MapModeCanvas.MapMode.PortExpansion);
        colorCache[MapModeCanvas.MapMode.MineralExtraction] = calculateColor(scores[MapModeCanvas.MapMode.MineralExtraction], MapModeCanvas.MapMode.MineralExtraction);
        colorCache[MapModeCanvas.MapMode.FoodSecurity] = calculateColor(scores[MapModeCanvas.MapMode.FoodSecurity], MapModeCanvas.MapMode.FoodSecurity);
        colorCache[MapModeCanvas.MapMode.TourismPotential] = calculateColor(scores[MapModeCanvas.MapMode.TourismPotential], MapModeCanvas.MapMode.TourismPotential);
    }

    public Color calculateColor(int score, MapModeCanvas.MapMode mapMode) {
        if(score == 0) {
            return new Color(0, 0, 0, 0);
        }
        Color color = mapModeCanvas.gridColorSchemes[mapMode][(score / 10) - 1];
        return new Color(color.r, color.g, color.b, 0.85f);
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
        // 
        if(levelEditor.editing && !CameraController.IsPointerOverUIObject()) {
            scores[mapModeCanvas.currentMode] = levelEditor.currentValue;
            Debug.Log(mapModeCanvas.currentMode);
            Debug.Log(mapModeCanvas.gridColorSchemes[mapModeCanvas.currentMode]);
            Color newColor = calculateColor(scores[mapModeCanvas.currentMode], mapModeCanvas.currentMode);
            colorCache[mapModeCanvas.currentMode] = newColor;
            changeColor(newColor);
        }
        if(!levelEditor.editing && !CameraController.IsPointerOverUIObject() && Input.touchCount < 2) {
            hoveringOverTile = true;
        }
    }

    // Differentiating between tap and drag
    // It's a tap if click begins and ends on the tile without exiting

    void OnMouseExit() {
        hoveringOverTile = false;
    }

    void OnMouseUp() {
        if(hoveringOverTile) {
            piecePlace.place(piecePlace.currentPieceType, coordinate[0], coordinate[1]);
            hoveringOverTile = false;
        }
    }
}
