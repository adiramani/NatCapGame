using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModeCanvas : MonoBehaviour {
    
    public enum MapMode {
        PortExpansion = 0,
        MineralExtraction = 1,
        FoodSecurity = 2,
        TourismPotential = 3
    }

    List<MapModeBtn> mapModeBtns = new List<MapModeBtn>();
    public MapMode currentMode = MapModeCanvas.MapMode.PortExpansion;
    LevelManager levelManager;

    // Use this for initialization
    void Start() {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void setMapMode(MapMode newMode) {
        currentMode = newMode;

        for(int x = 0; x < levelManager.gridResolution; x++) {
            for (int y = 0; y < levelManager.gridResolution; y++) {
                TileScript tile = levelManager.tiles[x, y];
                tile.changeColor(tile.colorCache[currentMode]);
            }
        }
        /*
        foreach (MapModeBtn mapModeBtn in mapModeBtns) {
            mapModeBtn.deselect();
        }*/
    }

    public void registerButton(MapModeBtn mapModeBtn) {
        mapModeBtns.Add(mapModeBtn);
    }
}
