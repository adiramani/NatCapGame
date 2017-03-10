using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapModeBtn : MonoBehaviour {

    public MapModeCanvas.MapMode mapMode = MapModeCanvas.MapMode.PortExpansion;
    MapModeCanvas mapModeCanvas;
    Button button;
    ColorBlock colorBlock;

    // Use this for initialization
    void Start() {
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
        button = gameObject.GetComponent<Button>();
        colorBlock = button.colors;
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update() {

    }

    void OnClick() {
        mapModeCanvas.setMapMode(mapMode);
        select();
    }

    public void select() {
        /*
        colorBlock.normalColor = new Color(0, 255, 246);
        button.colors = colorBlock;
        */
    }

    public void deselect() {
        /*
        colorBlock.normalColor = Color.white;
        button.colors = colorBlock;
        */
    }
}
