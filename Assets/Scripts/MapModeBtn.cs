using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapModeBtn : MonoBehaviour {

    // set default map mode
    public MapModeCanvas.MapMode mapMode = MapModeCanvas.MapMode.PortExpansion;
    MapModeCanvas mapModeCanvas;
    Button button;
    ColorBlock colorBlock;
    
    void Start() {
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
        button = gameObject.GetComponent<Button>();
        colorBlock = button.colors;
        button.onClick.AddListener(OnClick);
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
