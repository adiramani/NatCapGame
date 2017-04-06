using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceScript : MonoBehaviour {

    public int x;
    public int y;

    LevelManager levelManager = null;
    public PiecePlace.PieceType pieceType;

    void Start () {

    }

    public void setup(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getScore() {
        return getScore(true);
    }

    public int getScore(bool includeNegatives) {
        if(levelManager == null)
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        List<TileScript> tiles = new List<TileScript>();
        tiles.Add(levelManager.tiles[x, y]);
        tiles.Add(levelManager.tiles[x + 1, y]);
        tiles.Add(levelManager.tiles[x, y + 1]);
        tiles.Add(levelManager.tiles[x + 1, y + 1]);

        int score = 0;

        foreach(TileScript tile in tiles) {
            score += tile.getScore(pieceType == PiecePlace.PieceType.Port ? MapModeCanvas.MapMode.PortExpansion : MapModeCanvas.MapMode.MineralExtraction);

            if(includeNegatives) {
                score -= tile.getScore(MapModeCanvas.MapMode.FoodSecurity);
                score -= tile.getScore(MapModeCanvas.MapMode.TourismPotential);
            }
        }

        return score;
    }
}
