using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    public GameObject tile1;

	// Use this for initialization
	void Start () {
        createLevel(tile1);
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void createLevel (GameObject tile) {
        float tileSize = tile.GetComponent <SpriteRenderer>().sprite.bounds.size.x;
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < 30; y++)
        {
            for(int x = 0; x < 30; x++)
            {
                GameObject newTile = Instantiate(tile);
                newTile.transform.position = new Vector3(worldStart.x + (tileSize * x) - tileSize / 2, worldStart.y - (tileSize * y) - tileSize / 2, 0f);
                //newTile.GetComponent<TileScript>().setup(new Point((int) newTile.transform.position.x, (int) newTile.transform.position.y));
            }
        }
    }
}
