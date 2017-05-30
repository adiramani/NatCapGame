﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour {

    // TODO: find a better way to store this data :)
    string arcticLevel = "0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,20,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,30,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,40,0,0;0,0,0,0;0,0,0,0;0,30,0,0;0,30,0,0;0,40,0,0;0,40,0,0;0,40,0,0\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,10,0;0,40,0,20;0,0,20,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,20;0,0,0,20;0,0,0,20;0,30,0,40;0,50,10,20;0,40,20,20;0,0,10,0;0,0,10,0;0,0,10,0;0,40,10,0;0,0,10,0;0,0,20,0;0,0,20,0;0,40,40,0;0,0,0,0;0,0,0,0;0,30,30,50;0,30,30,50;0,30,0,20;0,40,0,20;0,40,0,20\n"
                        + "0,0,10,0;0,0,10,0;0,0,10,0;0,0,0,0;0,0,20,20;0,0,20,0;0,0,0,0;0,0,0,20;0,0,0,20;0,30,0,20;0,30,0,10;0,30,0,20;0,30,0,50;0,0,50,50;0,0,40,20;0,0,20,40;0,0,20,0;0,0,20,40;0,0,40,40;0,0,10,30;0,0,0,30;0,0,10,30;0,0,40,30;0,0,0,30;0,0,10,0;0,10,30,50;0,40,30,40;0,40,30,40;0,30,10,10;0,40,0,20\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,20;0,0,0,20;0,0,0,50;0,0,0,50;0,0,0,50;0,0,0,50;0,0,20,40;0,0,20,40;0,0,10,40;0,0,10,40;0,0,0,40;0,0,0,40;0,0,0,30;0,0,0,30;0,0,0,30;0,40,0,30;0,40,0,30;0,10,10,30;0,10,10,30;0,20,20,30;0,30,20,40;0,40,30,50;0,40,0,20\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,20;0,0,0,20;0,0,0,40;0,0,0,40;0,0,0,40;0,0,0,40;0,0,0,40;0,0,0,40;0,0,0,40;0,0,0,40;0,0,0,30;0,0,0,30;0,0,0,30;0,40,0,30;0,40,0,30;0,10,0,30;0,20,0,30;0,20,10,30;0,20,10,20;0,0,30,50;0,10,0,20;0,20,0,20\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,30,0,0;0,0,0,0;0,0,0,50;0,0,0,10;0,0,0,20;0,0,0,20;0,0,0,20;0,0,0,20;0,0,10,40;0,0,0,40;0,0,0,40;0,0,0,40;0,0,0,30;0,0,0,30;0,0,0,30;0,0,0,30;0,0,0,30;0,40,40,30;50,40,40,30;50,40,40,30;10,40,10,30;0,40,0,30;0,20,0,20;0,10,0,20;0,20,20,40;0,20,0,20\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,50;0,0,10,50;0,0,10,0;0,0,10,20;0,0,10,20;0,0,10,20;0,0,10,20;0,0,10,20;0,0,0,20;0,0,0,20;0,0,20,40;0,0,0,30;0,0,0,30;0,0,0,0;0,0,0,0;0,40,50,30;50,40,50,30;50,40,40,20;20,40,50,20;20,40,20,20;10,30,10,40;10,30,0,40;0,30,0,40;0,40,0,40\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,20;0,0,0,0;0,0,0,0;0,0,10,40;0,0,10,30;0,0,10,50;0,0,10,10;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,0,0;0,0,20,40;0,0,20,40;0,0,20,40;0,0,30,50;0,0,0,0;0,0,0,0;0,40,0,30;20,40,40,20;20,40,40,20;10,40,40,40;20,40,40,40;10,40,50,40;0,30,50,40;0,30,20,40;0,40,40,40\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,10,20;0,0,10,40;0,0,10,40;0,0,10,50;0,0,10,10;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,50;0,0,30,50;0,0,30,50;0,0,10,10;0,0,0,0;0,30,30,20;20,40,10,20;20,40,10,20;20,40,10,20;0,40,30,10;0,40,40,40;0,40,40,20;0,40,40,20;0,40,50,20;0,40,50,40;0,40,50,10\n"
                        + "0,0,0,0;0,0,0,0;0,40,0,0;0,0,20,30;0,0,10,30;0,0,10,50;0,0,10,10;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,30;0,0,20,30;0,40,10,0;0,50,50,0;50,30,20,0;20,30,10,0;20,40,0,10;0,40,10,10;0,40,30,20;0,40,30,20;0,30,30,20;0,40,30,20;0,40,40,10;0,40,40,10\n"
                        + "0,0,0,0;0,0,10,50;0,30,30,50;0,40,20,40;0,0,10,50;0,0,10,50;0,0,10,10;0,0,10,0;0,0,10,0;0,0,40,0;0,0,40,0;0,0,40,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,40,0,0;0,40,10,0;0,40,40,0;40,30,10,0;10,30,10,0;10,40,0,10;0,40,10,10;0,40,30,20;0,40,30,20;0,30,30,20;0,30,30,20;0,30,40,10;0,30,30,10\n"
                        + "0,0,0,0;0,0,0,0;0,0,10,10;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,20,0;0,0,50,0;0,0,40,10;0,0,40,20;0,0,40,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,30,0;0,0,0,0;0,0,0,0;0,40,20,0;0,40,40,0;40,10,20,0;10,30,10,0;10,30,0,0;0,30,0,10;0,30,20,10;0,30,20,10;0,30,30,20;0,30,30,20;0,30,30,20;0,30,30,10\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,20,0;0,0,50,0;0,20,50,10;0,20,50,50;0,20,40,50;0,20,40,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,20,0;0,40,10,0;0,40,10,0;0,40,40,0;40,30,30,0;10,10,10,0;0,30,0,0;0,30,0,10;0,30,0,10;0,30,0,10;0,30,10,20;0,30,10,20;0,30,20,20;0,30,30,10\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,10,0;0,0,10,0;0,0,20,0;0,0,20,0;0,20,50,0;0,50,50,50;0,50,50,20;0,20,40,20;0,20,40,0;0,0,40,0;0,0,20,0;0,0,20,0;0,0,20,0;0,40,30,0;0,40,20,0;0,50,50,50;0,50,50,0;0,30,30,0;10,10,20,0;0,10,0,0;0,10,0,0;0,20,0,10;0,20,0,10;0,20,10,20;0,20,10,20;0,20,10,20;0,30,10,0\n"
                        + "0,0,0,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,10,0;0,0,20,0;0,0,20,0;0,50,50,10;0,30,50,50;0,30,50,40;0,30,40,0;0,0,40,0;0,0,40,0;0,0,0,0;0,0,0,0;0,40,10,0;20,40,30,0;0,30,30,0;0,50,50,50;10,50,50,0;40,40,40,0;10,10,20,0;0,10,0,0;0,10,0,0;0,20,0,0;0,20,0,10;0,20,10,20;0,20,10,20;0,20,10,20;0,30,10,0\n"
                        + "0,0,0,0;0,0,10,0;0,0,10,0;0,0,30,0;0,0,30,0;0,0,20,0;0,20,20,0;0,20,50,10;0,30,50,10;0,30,40,50;0,20,40,0;0,0,40,0;0,0,40,0;0,0,0,0;0,0,0,0;0,40,30,0;20,40,20,0;20,40,40,0;10,30,30,40;0,40,40,0;0,10,20,0;10,10,20,0;0,10,0,0;0,10,0,0;0,10,0,0;0,20,0,10;0,20,10,10;0,20,10,20;0,10,10,20;0,10,10,0\n"
                        + "0,0,0,0;0,0,10,0;0,0,10,0;0,0,20,0;0,0,30,0;0,0,20,0;0,20,20,0;0,20,50,0;0,20,50,0;0,20,40,0;0,0,40,0;0,0,40,0;0,30,20,0;50,0,0,0;0,0,0,0;0,10,10,0;20,40,30,0;50,0,40,0;10,40,40,40;0,50,50,50;10,0,20,0;0,40,40,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,10;0,10,10,10;0,10,10,0;0,10,10,0\n"
                        + "0,0,0,0;0,0,10,0;0,0,30,0;0,0,30,50;0,0,30,20;0,0,20,0;0,0,20,0;0,0,40,0;0,0,40,0;0,0,40,30;0,0,40,0;0,0,30,40;0,40,40,50;50,50,50,0;50,40,40,0;50,20,30,0;20,10,10,0;10,50,50,50;10,40,40,0;40,40,40,40;0,50,50,40;0,40,40,0;0,30,30,0;0,10,20,0;0,10,10,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,0,0;0,30,30,0;0,40,30,0;0,40,30,0;0,40,30,0;0,0,20,0;0,0,20,0;0,0,0,0;0,0,0,30;0,0,20,30;0,0,0,50;0,0,30,50;0,40,40,40;0,50,50,0;50,50,50,0;50,10,20,0;10,10,20,0;10,30,30,0;10,50,50,40;0,30,30,0;0,40,20,0;0,50,50,40;0,50,50,50;0,10,20,0;0,10,20,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,0,0;0,40,30,0;0,40,30,40;0,40,30,0;0,30,20,0;0,0,20,0;0,0,20,0;0,0,0,0;0,0,20,0;0,0,20,50;0,40,40,0;20,50,50,50;20,50,50,50;30,50,50,0;50,40,40,0;10,10,20,0;0,10,10,0;0,10,20,0;0,50,50,40;0,40,40,0;0,30,30,0;0,40,20,0;0,50,50,50;0,10,20,0;0,10,20,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,0,0;0,10,30,0;0,10,30,10;0,40,20,10;0,30,20,0;0,0,20,0;0,0,0,0;0,0,0,0;0,0,0,0;0,10,30,30;0,40,40,0;50,50,50,0;20,40,50,0;30,10,30,0;20,40,30,0;10,40,10,0;0,50,10,0;0,30,0,0;0,40,0,0;0,50,50,0;0,50,50,0;0,30,30,0;0,30,30,0;0,10,20,0;0,10,20,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,10,0;0,10,10,0;0,10,20,0;0,10,20,0;0,0,20,0;0,0,20,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,20,30;0,0,0,30;0,0,0,0;0,0,0,0;0,0,0,0;0,0,20,0;10,40,20,0;10,10,20,0;0,10,0,0;0,10,0,0;0,30,0,0;0,50,50,0;0,30,30,0;0,30,30,0;0,30,30,0;0,10,20,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,10,0;0,10,10,0;0,10,20,0;0,10,20,0;0,0,20,0;0,0,10,0;0,0,0,0;0,0,0,0;0,0,0,10;0,0,20,50;0,0,20,0;0,50,50,0;30,0,0,0;0,0,0,0;0,30,30,0;10,30,30,0;10,10,20,0;10,10,10,0;0,10,10,0;0,10,20,0;0,40,40,0;0,30,30,0;0,10,20,0;0,10,20,0;0,10,10,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,20,0;0,0,10,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,10,0;0,0,0,0;0,0,0,0;0,0,10,10;0,30,30,50;0,0,20,0;20,50,50,0;50,40,40,0;20,40,40,0;50,10,20,0;10,30,30,0;10,10,20,0;0,10,10,0;0,10,0,0;0,10,20,0;0,10,20,0;0,10,20,0;0,10,10,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,10,0;0,0,10,10;0,0,20,30;0,0,20,0;0,0,20,0;0,0,20,0;0,0,0,0;0,0,0,0;0,0,10,40;0,30,30,40;0,30,30,0;20,50,50,0;50,10,10,0;20,10,10,0;20,10,0,0;0,10,10,0;0,10,10,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,10,0;0,0,10,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,0,0;0,0,20,0;0,0,20,50;0,0,20,0;10,10,20,0;10,10,10,0;20,10,10,20;10,10,10,20;10,10,0,20;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,10,0;0,0,10,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,20,0;0,10,20,0;0,0,0,0;0,0,0,0;0,30,30,0;0,0,0,50;0,40,40,0;50,10,20,10;20,40,40,10;20,10,20,0;0,10,20,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,20,0;0,0,10,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,0,0;0,0,0,0;0,0,0,0;0,30,30,0;0,40,40,40;50,50,20,10;0,50,20,10;0,10,20,10;0,10,10,20;0,10,10,0;0,10,10,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,0,0;0,0,0,0;0,0,20,0;0,0,20,0;0,0,20,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,30,30,40;0,50,50,10;0,40,40,10;0,50,20,10;0,50,20,0;0,10,10,0;0,10,10,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0\n"
                        + "0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,0,0;0,0,20,0;0,50,50,0;0,50,50,0;0,50,20,0;0,30,30,0;0,10,10,0;0,10,10,0;0,10,10,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0;0,10,0,0";
    LevelManager levelManager;
    MapModeCanvas mapModeCanvas;
    bool firstTick = true;

    void Start() {
        levelManager = gameObject.GetComponent<LevelManager>();
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
    }

    void Update() {
        if(Input.GetKeyDown("space")) {
            exportMap();
        }
        if(firstTick) {
            firstTick = false;
            loadMap();
        }
    }

    void exportMap() {
        Level level = new Level();
        level.export(levelManager);
	}

    void loadMap() {
        Level.load(levelManager, mapModeCanvas, arcticLevel);
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
                output += (y != levelManager.gridResolution - 1) ? "\n" : "";
            }

            Debug.Log(output);
        }

        public static void load(LevelManager levelManager, MapModeCanvas mapModeCanvas, string levelData) {
            string[] rows = levelData.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
            for(int y = 0; y < rows.Length; y++) {
                string[] columns = rows[y].Split(new string[] { ";" }, System.StringSplitOptions.None);
                for(int x = 0; x < columns.Length; x++) {
                    string[] values = columns[x].Split(new string[] { "," }, System.StringSplitOptions.None);

                    TileScript tile = levelManager.tiles[x, y];

                    tile.setValues(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

                    tile.calculateAllColors();
                    tile.changeColor(tile.colorCache[mapModeCanvas.currentMode]);
                }
            }
        }
    }
}