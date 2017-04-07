using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {

    public int currentRound = 1;

    Calculator calculator;
    MapModeCanvas mapModeCanvas;
    EndScreen endScreen;

    Button continueBtn;
    Button endBtn;
    
	void Start() {
        calculator = gameObject.GetComponent<Calculator>();
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
        endScreen = GameObject.Find("EndScreenCanvas").GetComponent<EndScreen>();

        continueBtn = GameObject.Find("ContinueBtn").GetComponent<Button>();
        continueBtn.onClick.AddListener(OnButtonClick);

        endBtn = GameObject.Find("EndBtn").GetComponent<Button>();
        endBtn.onClick.AddListener(OnButtonClick);
        endBtn.gameObject.SetActive(false);
    }

    public void setRound(int round) {
        currentRound = round;
        calculator.setRound(round);
        mapModeCanvas.setRound(round);
    }

    public void OnButtonClick() {
        if(currentRound == 1) {
            setRound(2);
            continueBtn.gameObject.SetActive(false);
            endBtn.gameObject.SetActive(true);
        }
        else if(currentRound == 2) {
            endScreen.show();
        }
    }
}
