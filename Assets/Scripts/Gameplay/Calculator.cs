using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {
    
    PiecePlace piecePlace;
    RoundController roundController;
    int score = 0;
    Text scoreTextA;
    Text scoreTextB;
    Image scorePanelB;

    void Start () {
        piecePlace = GameObject.Find("LevelManager").GetComponent<PiecePlace>();
        roundController = gameObject.GetComponent<RoundController>();

        scoreTextA = gameObject.transform.FindChild("ScoreTextA").GetComponent<Text>();
        scoreTextB = gameObject.transform.FindChild("ScoreTextB").GetComponent<Text>();
        scorePanelB = gameObject.transform.FindChild("PanelB").gameObject.GetComponent<Image>();

        scoreTextB.gameObject.SetActive(false);
        scorePanelB.enabled = false;
    }

    public void recalculate() {
        score = 0;

        foreach(GamePieceScript piece in piecePlace.pieces) {
            score += piece.getScore(roundController.currentRound == 2); // only include negatives in round 2
        }

        displayScore(score);
    }

    public void setRound(int round) {
        if(round == 2) {
            scoreTextB.gameObject.SetActive(true);
            scorePanelB.enabled = true;
            recalculate();
        }
    }

    public void displayScore(int score) {
        if(roundController.currentRound == 1)
            scoreTextA.text = "Round 1: " + score.ToString() + "pts";
        if (roundController.currentRound == 2)
            scoreTextB.text = "Round 2: " + score.ToString() + "pts";
    }
}
