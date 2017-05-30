using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {

    public int currentRound = 1;
    bool recalculateNeeded = true;

    Calculator calculator;
    MapModeCanvas mapModeCanvas;
    EndScreen endScreen;

    Button continueBtn;
    Button endBtn;
    Button recalculateBtn;
    
	void Start() {
        calculator = gameObject.GetComponent<Calculator>();
        mapModeCanvas = GameObject.Find("MapModeCanvas").GetComponent<MapModeCanvas>();
        endScreen = GameObject.Find("EndScreenCanvas").GetComponent<EndScreen>();

        continueBtn = GameObject.Find("ContinueBtn").GetComponent<Button>();
        continueBtn.onClick.AddListener(OnButtonClick);
        continueBtn.gameObject.SetActive(false);

        endBtn = GameObject.Find("EndBtn").GetComponent<Button>();
        endBtn.onClick.AddListener(OnButtonClick);
        endBtn.gameObject.SetActive(false);

        recalculateBtn = GameObject.Find("RecalculateBtn").GetComponent<Button>();
        recalculateBtn.onClick.AddListener(OnButtonClick);
    }

    public void setRound(int round) {
        currentRound = round;
        calculator.setRound(round);
        mapModeCanvas.setRound(round);
    }

    public void tileEdited() {
        recalculateNeeded = true;
        continueBtn.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(false);
        recalculateBtn.gameObject.SetActive(true);
    }

    public void OnButtonClick() {
        if(recalculateNeeded) {
            recalculateNeeded = false;
            calculator.recalculate();
            recalculateBtn.gameObject.SetActive(false);
            if(currentRound == 1) {
                continueBtn.gameObject.SetActive(true);
            }
            else {
                endBtn.gameObject.SetActive(true);
            }
        }
        else {
            if(currentRound == 1) {
                setRound(2);
                continueBtn.gameObject.SetActive(false);
                recalculateNeeded = true;
                recalculateBtn.gameObject.SetActive(true);
            }
            else if(currentRound == 2) {
                endScreen.show();
            }
        }
    }
}
