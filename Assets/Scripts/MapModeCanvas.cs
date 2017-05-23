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

    public Dictionary<MapModeCanvas.MapMode, Color[]> gridColorSchemes;
    List<MapModeBtn> mapModeBtns = new List<MapModeBtn>();
    public MapMode currentMode = MapModeCanvas.MapMode.PortExpansion;
    LevelManager levelManager;
    KeyCanvas keyCanvas;
    
    void Start() {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        keyCanvas = GameObject.Find("KeyCanvas").GetComponent<KeyCanvas>();

        gridColorSchemes = new Dictionary<MapModeCanvas.MapMode, Color[]>() {
            { MapMode.PortExpansion,
                new Color[] {
                    new Color(232f / 255f, 233f / 255f, 234f / 255f),
                    new Color(204f / 255f, 205f / 255f, 207f / 255f),
                    new Color(175f / 255f, 177f / 255f, 179f / 255f),
                    new Color(147f / 255f, 147f / 255f, 150f / 255f),
                    new Color(90f / 255f, 87f / 255f, 87f / 255f)
                }
            },
            { MapMode.MineralExtraction,
                new Color[] {
                    new Color(255f / 255f, 252f / 255f, 228f / 255f),
                    new Color(254f / 255f, 226f / 255f, 180f / 255f),
                    new Color(250f / 255f, 188f / 255f, 112f / 255f),
                    new Color(224f / 255f, 153f / 255f, 100f / 255f),
                    new Color(189f / 255f, 126f / 255f, 103f / 255f)
                }
            },
            { MapMode.FoodSecurity,
                new Color[] {
                    new Color(254f / 255f, 240f / 255f, 230f / 255f),
                    new Color(248f / 255f, 207f / 255f, 192f / 255f),
                    new Color(241f / 255f, 163f / 255f, 164f / 255f),
                    new Color(210f / 255f, 113f / 255f, 135f / 255f),
                    new Color(171f / 255f, 96f / 255f, 134f / 255f)
                }
            },
            { MapMode.TourismPotential,
                new Color[] {
                    new Color(240f / 255f, 243f / 255f, 236f / 255f),
                    new Color(204f / 255f, 216f / 255f, 200f / 255f),
                    new Color(158f / 255f, 186f / 255f, 165f / 255f),
                    new Color(103f / 255f, 164f / 255f, 147f / 255f),
                    new Color(65f / 255f, 141f / 255f, 126f / 255f)
                }
            }
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

        keyCanvas.setMapMode(newMode);

        foreach (MapModeBtn mapModeBtn in mapModeBtns) {
            if(mapModeBtn.mapMode == newMode) {
                mapModeBtn.select();
            }
            else {
                mapModeBtn.deselect();
            }
        }
    }

    public void registerButton(MapModeBtn mapModeBtn) {
        mapModeBtns.Add(mapModeBtn);

        if(mapModeBtns.Count == 4) {
            setRound(1);
        }
    }

    public void setRound(int round) {
        foreach (MapModeBtn mapModeBtn in mapModeBtns) {
            if (mapModeBtn.mapMode == MapMode.FoodSecurity || mapModeBtn.mapMode == MapMode.TourismPotential) {
                mapModeBtn.gameObject.SetActive(round == 2 ? true : false);
            }
            else {
                mapModeBtn.gameObject.SetActive(true);
            }
        }
    }
}
