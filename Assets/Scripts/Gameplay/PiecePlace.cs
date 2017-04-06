using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlace : MonoBehaviour {

    LevelManager levelManager;
    public Dictionary<PieceType, int> piecesRemaining = new Dictionary<PieceType, int>();
    List<GamePieceScript> pieces = new List<GamePieceScript>();
    GameObject map;
    public GameObject MineGameObject;
    public GameObject PortGameObject;

    public enum PieceType {
        Port = 0,
        Mine = 1,
        Shipping = 2
    }

    void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        piecesRemaining[PieceType.Port] = 8;
        piecesRemaining[PieceType.Mine] = 8;
        piecesRemaining[PieceType.Shipping] = 4;

        map = GameObject.Find("Map");
    }

    public void placePiece(PieceType pieceType, int x, int y) {
        if(piecesRemaining[pieceType] == 0 || !canPlace(x, y))
            return;

        piecesRemaining[pieceType] -= 1;

        GameObject gameObject;
        if(pieceType == PieceType.Mine) gameObject = Instantiate(MineGameObject);
        else if(pieceType == PieceType.Port) gameObject = Instantiate(PortGameObject);
        else gameObject = Instantiate(MineGameObject);

        float tileSize = map.GetComponent<MapController>().mapSize / levelManager.gridResolution;
        Vector3 tileOrigin = new Vector3(-0.5f * levelManager.gridResolution * tileSize + tileSize, 0.5f * levelManager.gridResolution * tileSize - tileSize, 0);
        gameObject.transform.position = tileOrigin + new Vector3(x * tileSize, -1 * y * tileSize, 0.6f);
        gameObject.transform.SetParent(map.transform);

        GamePieceScript pieceScript = gameObject.GetComponent<GamePieceScript>();
        pieceScript.setup(x, y);

        pieces.Add(pieceScript);
    }

    public bool canPlace(int x, int y) {
        return !isSpaceOccupied(x, y) && !isSpaceOccupied(x + 1, y) && !isSpaceOccupied(x, y + 1) && !isSpaceOccupied(x + 1, y + 1) && x < 29 && y < 29;
    }

    public bool isSpaceOccupied(int x, int y) {
        return getPiece(x, y) != null;
    }

    public GamePieceScript getPiece(int x, int y) {
        foreach(GamePieceScript piece in pieces) {
            if((piece.x == x || piece.x + 1 == x) && (piece.y == y || piece.y + 1 == y)) {
                return piece;
            }
        }

        return null;
    }
}
