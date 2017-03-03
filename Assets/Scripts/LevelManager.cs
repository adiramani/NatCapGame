using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    public GameObject tilePrototype;
    public int gridResolution = 30;

    GameObject map;

    // Use this for initialization
    void Start () {
        map = GameObject.Find("Map");
        createLevel(tilePrototype);
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void createLevel (GameObject tilePrototype) {
        float tileSize = map.GetComponent<MapController>().mapSize / gridResolution;
        // origin determined by finding top-left corner of map, then adding half of the tile size so that the tiles are contained
        Vector3 tileOrigin = new Vector3(-0.5f * gridResolution * tileSize + 0.5f * tileSize, 0.5f * gridResolution * tileSize + -0.5f * tileSize);
        Vector3 tileScale = new Vector3(tileSize, tileSize, 1);

        for (int x = 0; x < 30; x++) {
            for(int y = 0; y < 30; y++) {
                GameObject tile = Instantiate(tilePrototype);
                tile.name = string.Format("Tile ({0}, {1})", x, y);
                tile.transform.localScale = tileScale;
                tile.transform.position = tileOrigin + new Vector3(x * tileSize, -1 * y * tileSize, 0);
                tile.transform.SetParent(map.transform);

                //newTile.transform.position = new Vector3(worldStart.x + (tileSize * x) - tileSize / 2, worldStart.y - (tileSize * y) - tileSize / 2, 0f);
                //newTile.GetComponent<TileScript>().setup(new Point((int) newTile.transform.position.x, (int) newTile.transform.position.y));
            }
        }
    }
}
