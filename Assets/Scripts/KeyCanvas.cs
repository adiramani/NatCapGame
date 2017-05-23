using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCanvas : MonoBehaviour {

    MapModeCanvas mapModeCanvas;

    Image tenPoint;
    Image twentyPoint;
    Image thirtyPoint;
    Image fortyPoint;
    Image fiftyPoint;

    void Start() {
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();

        tenPoint = gameObject.transform.Find("TenPointPanel").GetComponent<Image>();
        twentyPoint = gameObject.transform.Find("TwentyPointPanel").GetComponent<Image>();
        thirtyPoint = gameObject.transform.Find("ThirtyPointPanel").GetComponent<Image>();
        fortyPoint = gameObject.transform.Find("FortyPointPanel").GetComponent<Image>();
        fiftyPoint = gameObject.transform.Find("FiftyPointPanel").GetComponent<Image>();

        setMapMode(MapModeCanvas.MapMode.PortExpansion);
    }

    public void setMapMode(MapModeCanvas.MapMode mapMode) {
        tenPoint.color = mapModeCanvas.gridColorSchemes[mapMode][0];
        twentyPoint.color = mapModeCanvas.gridColorSchemes[mapMode][1];
        thirtyPoint.color = mapModeCanvas.gridColorSchemes[mapMode][2];
        fortyPoint.color = mapModeCanvas.gridColorSchemes[mapMode][3];
        fiftyPoint.color = mapModeCanvas.gridColorSchemes[mapMode][4];
    }
}
