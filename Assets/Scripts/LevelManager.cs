using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    public GameObject tilePrototype;
    public int gridResolution = 30;
    public int maxTileScore = 50;
    public Color gridColorScheme = Color.red;
    public float tileOpacity = 0.2f;

    GameObject map;
    public TileScript[,] tiles;

    // Use this for initialization
    void Start() {
        tiles = new TileScript[gridResolution, gridResolution];
        map = GameObject.Find("Map");
        createGrid(tilePrototype);
	}
	
	// Update is called once per frame
	void Update() {

    }

    private void createGrid(GameObject tilePrototype) {
        float tileSize = map.GetComponent<MapController>().mapSize / gridResolution;
        // origin determined by finding top-left corner of map, then adding half of the tile size so that the tiles are contained
        Vector3 tileOrigin = new Vector3(-0.5f * gridResolution * tileSize + 0.5f * tileSize, 0.5f * gridResolution * tileSize + -0.5f * tileSize);
        Vector3 tileScale = new Vector3(tileSize, tileSize, 1);

        for (int x = 0; x < gridResolution; x++) {
            for(int y = 0; y < gridResolution; y++) {
                GameObject tile = Instantiate(tilePrototype);
                tile.name = string.Format("Tile ({0}, {1})", x, y);
                tile.transform.localScale = tileScale;
                tile.transform.position = tileOrigin + new Vector3(x * tileSize, -1 * y * tileSize, 0.5f);
                tile.transform.SetParent(map.transform);

                TileScript tileScript = tile.GetComponent<TileScript>();
                tileScript.setup(x, y);

                tiles[x, y] = tileScript;
            }
        }
    }
}
