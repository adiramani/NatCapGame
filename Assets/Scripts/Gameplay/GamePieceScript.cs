using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceScript : MonoBehaviour {

    public int x;
    public int y;

    GameObject map;
    CameraController cameraController;
    LevelManager levelManager = null;
    PiecePlace piecePlace;
    public PiecePlace.PieceType pieceType;

    float doubleTapCooldown = 0; // seconds

    // dragging:
    private Vector3 screenPoint;
    private Vector3 offset;

    void Start() {
        map = GameObject.Find("Map").gameObject;
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        piecePlace = GameObject.Find("LevelManager").GetComponent<PiecePlace>();
    }

    void Update() {
        if(doubleTapCooldown > 0)
            doubleTapCooldown -= Time.deltaTime;
    }

    public void setup(int x, int y) {
        this.x = x;
        this.y = y;
    }
    
    public int getScore() {
        return getScore(0);
    }

    public int getPositiveScore() {
        return getScore(1);
    }

    public int getNegativeScore() {
        return getScore(2);
    }

    public int getScore(int mode) {
        /*
         * Modes:
         * 0 = net value of tile
         * 1 = sum of positive values
         * 2 = sum of negative values
         */
        if (levelManager == null)
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        List<TileScript> tiles = new List<TileScript>();
        tiles.Add(levelManager.tiles[x, y]);
        tiles.Add(levelManager.tiles[x + 1, y]);
        tiles.Add(levelManager.tiles[x, y + 1]);
        tiles.Add(levelManager.tiles[x + 1, y + 1]);

        int score = 0;

        foreach (TileScript tile in tiles) {
            if(mode == 0 || mode == 1) {
                score += tile.getScore(pieceType == PiecePlace.PieceType.Port ? MapModeCanvas.MapMode.PortExpansion : MapModeCanvas.MapMode.MineralExtraction);
            }

            if (mode == 2) {
                score -= tile.getScore(MapModeCanvas.MapMode.FoodSecurity);
                score -= tile.getScore(MapModeCanvas.MapMode.TourismPotential);
            }
        }

        return score;
    }

    void OnMouseDown() {
        if(doubleTapCooldown > 0) {
            piecePlace.removePiece(x, y);
            return;
        }
        else {
            doubleTapCooldown = 0.7f;
        }

        cameraController.frozen = true;

        // set invalid coordinates while moving so it can snap onto its previous position
        x = -5;
        y = -5;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag() {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp() {
        cameraController.frozen = false;
        Vector3 position = gameObject.transform.position;

        // do the opposite transforms as in PiecePlace to get new x, y coord
        float tileSize = levelManager.getTileSize();
        Vector3 tileOrigin = map.transform.position + new Vector3(-0.5f * levelManager.gridResolution * tileSize + tileSize, 0.5f * levelManager.gridResolution * tileSize - tileSize, 0);
        position = position - tileOrigin;
        position = Vector3.Scale(position, new Vector3(1 / tileSize, -1 / tileSize, 0));

        int newX = Mathf.RoundToInt(position.x);
        int newY = Mathf.RoundToInt(position.y);

        bool decrease = true;
        while(!piecePlace.canPlace(newX, newY)) {
            if(decrease) {
                newX = Mathf.Max(0, newX - 1);
                newY = Mathf.Max(0, newY - 1);

                if (newX == 0 && newY == 0) {
                    decrease = false;
                }
            }
            else {
                newX++;
                newY++;
            }
        }

        x = newX;
        y = newY;

        gameObject.transform.position = tileOrigin + new Vector3(x * tileSize, -1 * y * tileSize, -1.5f);
        piecePlace.calculator.recalculate();
    }
}
