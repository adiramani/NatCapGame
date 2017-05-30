using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

    LevelManager levelManager;
    PiecePlace piecePlace;
    RoundController roundController;
    public int maximumScore = 13890; // calculated from calculateTotalScore -- rerun method if you update the map
    public int score = 0;
    Text scoreTextA;
    Text scoreTextB;
    Image scorePanelB;

    void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        piecePlace = levelManager.GetComponent<PiecePlace>();
        roundController = gameObject.GetComponent<RoundController>();

        scoreTextA = gameObject.transform.FindChild("ScoreTextA").GetComponent<Text>();
        scoreTextB = gameObject.transform.FindChild("ScoreTextB").GetComponent<Text>();
        scorePanelB = gameObject.transform.FindChild("PanelB").gameObject.GetComponent<Image>();

        scoreTextB.gameObject.SetActive(false);
        scorePanelB.enabled = false;

    }

    public void recalculate() {
        // Round 1: start at 0 and add. Round 2: start at max and subtract.
        score = roundController.currentRound == 2 ? maximumScore : 0;

        foreach(GamePieceScript piece in piecePlace.pieces) {
            // Round 1: only positive values. Round 2: only negative debuffs
            score += roundController.currentRound == 2 ? piece.getNegativeScore() : piece.getPositiveScore();
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

    public void calculateTotalScore() {
        for(int y = 0; y < levelManager.gridResolution; y++) {
            for(int x = 0; x < levelManager.gridResolution; x++) {
                TileScript tile = levelManager.tiles[x, y];
                maximumScore += tile.getScore(MapModeCanvas.MapMode.PortExpansion);
                maximumScore += tile.getScore(MapModeCanvas.MapMode.MineralExtraction);
            }
        }
    }
}
