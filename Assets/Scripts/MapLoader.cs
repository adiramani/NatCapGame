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
        level.export(levelManager);
	}

    // We can't serialize some types, so we have to do it ourselves
    private class Level {
        public string levelName = "Arctic";
        public string mapFileName = "arctic";

        /* 
         * each line of text is one row
         * each column within line is split with a semicolon
         * each of the four values (for each map) is split with a comma (ie 0,50,20,30)
        */
        public void export(LevelManager levelManager) {
            string output = "";
            
            // loop y first so that rows match
            for(int y = 0; y < levelManager.gridResolution; y++) {
                for(int x = 0; x < levelManager.gridResolution; x++) {
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.PortExpansion] + ",";
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.MineralExtraction] + ",";
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.FoodSecurity] + ",";
                    output += levelManager.tiles[x, y].scores[MapModeCanvas.MapMode.TourismPotential];
                    output += (x != levelManager.gridResolution - 1) ? ";" : "";
                }
                output += (y != levelManager.gridResolution - 1) ? ";" : "";
            }

            Debug.Log(output);
        }

        public void load(LevelManager levelManager, string levelData) {
            string[] rows = levelData.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
            for(int y = 0; y < rows.Length; y++) {
                string[] columns = rows[y].Split(new string[] { ";" }, System.StringSplitOptions.None);
                for(int x = 0; x < columns.Length; x++) {
                    string[] values = columns[x].Split(new string[] { "," }, System.StringSplitOptions.None);

                    TileScript tile = levelManager.tiles[x, y];

                    tile.scores[MapModeCanvas.MapMode.PortExpansion] = int.Parse(values[0]);
                    tile.scores[MapModeCanvas.MapMode.MineralExtraction] = int.Parse(values[1]);
                    tile.scores[MapModeCanvas.MapMode.FoodSecurity] = int.Parse(values[2]);
                    tile.scores[MapModeCanvas.MapMode.TourismPotential] = int.Parse(values[3]);

                    tile.calculateAllColors();
                    //tile.changeColor(tile.colorCache[mapModeCanvas.currentMode]);
                }
            }
        }
    }
}