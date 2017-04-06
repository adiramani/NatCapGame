using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {

    public int currentRound = 1;

    Calculator calculator;
    MapModeCanvas mapModeCanvas;

    Button continueBtn;
    
	void Start() {
        calculator = gameObject.GetComponent<Calculator>();
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
        continueBtn = GameObject.Find("ContinueBtn").GetComponent<Button>();
        continueBtn.onClick.AddListener(OnButtonClick);
	}

    public void setRound(int round) {
        currentRound = round;
        calculator.setRound(round);
        mapModeCanvas.setRound(round);
    }

    public void OnButtonClick() {
        if(currentRound == 1) {
            setRound(2);
        }
    }
}
