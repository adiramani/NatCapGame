using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public GameObject tileObject;
    
    LevelManager levelManager;
    GameObject[,] panels;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        panels = new GameObject[levelManager.gridResolution, levelManager.gridResolution];
        //createGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void createGrid () {
        int tileSize = (int) gameObject.GetComponent<RectTransform>().rect.width;
        for(int x = 0; x < levelManager.gridResolution; x++) {
            for(int y = 0; y < levelManager.gridResolution; y++) {
                GameObject tile = Instantiate(tileObject);
                tile.transform.position.Set(x * tileSize, y * tileSize, 0);
                tile.transform.SetParent(gameObject.transform);
                tile.name = "Tile (" + x + ", " + y + ")";

                Image image;
                //image = new Image();


                    /*
                GameObject panel = new GameObject("Panel");
                panel.AddComponent<CanvasRenderer>();
                Image i = panel.AddComponent<Image>();
                i.color = Color.red;*/
            }
        }
    }
}
