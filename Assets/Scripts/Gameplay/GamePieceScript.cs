using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceScript : MonoBehaviour {

    public int x;
    public int y;

    LevelManager levelManager;

    void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void setup(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getScore() {
        return getScore(true);
    }

    public int getScore(bool includeNegatives) {
        TileScript[] tiles = new TileScript[4];
        tiles[0] = levelManager.tiles[x, y];
        tiles[1] = levelManager.tiles[x + 1, y];
        tiles[2] = levelManager.tiles[x, y + 1];
        tiles[3] = levelManager.tiles[x + 1, y + 1];

        int score = 0;

        for(int i = 0; i < tiles.Length; i++) {
            score += tiles[i].getScore(MapModeCanvas.MapMode.PortExpansion);
            score += tiles[i].getScore(MapModeCanvas.MapMode.MineralExtraction);

            if(includeNegatives) {
                score -= tiles[i].getScore(MapModeCanvas.MapMode.FoodSecurity);
                score -= tiles[i].getScore(MapModeCanvas.MapMode.TourismPotential);
            }
        }

        return score;
    }
}
