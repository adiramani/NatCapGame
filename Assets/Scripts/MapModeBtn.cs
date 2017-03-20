using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapModeBtn : MonoBehaviour {

    // set default map mode
    public MapModeCanvas.MapMode mapMode = MapModeCanvas.MapMode.PortExpansion;
    MapModeCanvas mapModeCanvas;
    Button button;
    ColorBlock defaultColorBlock;
    ColorBlock selectedColorBlock;
    
    void Start() {
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
        button = gameObject.GetComponent<Button>();

        defaultColorBlock = button.colors;
        selectedColorBlock = button.colors;
        selectedColorBlock.normalColor = new Color(0, 1f, 0.96f);
        selectedColorBlock.highlightedColor = new Color(0, 1f, 0.96f);
        selectedColorBlock.pressedColor = new Color(0, 1f, 0.96f);

        button.onClick.AddListener(OnClick);
        mapModeCanvas.registerButton(this);

        if(mapMode == MapModeCanvas.MapMode.PortExpansion) {
            select();
        }
    }

    void OnClick() {
        mapModeCanvas.setMapMode(mapMode);
    }

    public void select() {
        button.colors = selectedColorBlock;
    }

    public void deselect() {
        button.colors = defaultColorBlock;
    }
}
