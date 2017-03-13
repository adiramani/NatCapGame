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

    public Dictionary<MapModeCanvas.MapMode, Color> gridColorSchemes;
    List<MapModeBtn> mapModeBtns = new List<MapModeBtn>();
    public MapMode currentMode = MapModeCanvas.MapMode.PortExpansion;
    LevelManager levelManager;
    
    void Start() {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        gridColorSchemes = new Dictionary<MapModeCanvas.MapMode, Color>() {
            { MapMode.PortExpansion, new Color(10f / 255f, 10f / 255f, 10f / 255f) },
            { MapMode.MineralExtraction, new Color(255f / 255f, 178f / 255f, 0) },
            { MapMode.FoodSecurity, new Color(255f / 255f, 20f / 255f, 20f / 255f) },
            { MapMode.TourismPotential, new Color(0, 175 / 255f, 11f / 255f) }
        };
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
        }
        */
    }

    public void registerButton(MapModeBtn mapModeBtn) {
        mapModeBtns.Add(mapModeBtn);
    }
}
