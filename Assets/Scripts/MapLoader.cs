using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour {

    LevelManager levelManager;

    void Start () {
        levelManager = gameObject.GetComponent<LevelManager>();
    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            ExportMap();
        }
    }

    void ExportMap () {
        Level level = new Level();
        level.loadScores(levelManager);
	}

    // We can't serialize some types, so we have to do it ourselves
    private class Level {
        public string levelName = "Arctic";
        public string mapFileName = "arctic";

        public void loadScores(LevelManager levelManager) {
            string output = "";
            
            // loop y first so that rows match
            for(int y = 0; y < levelManager.gridResolution; y++) {
                for(int x = 0; x < levelManager.gridResolution; x++) {
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.PortExpansion] + ",";
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.MineralExtraction] + ",";
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.FoodSecurity] + ",";
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.TourismPotential] + ",";
                    output += ";";
                }
                output += "\n";
            }

            Debug.Log(output);
        }
    }
}