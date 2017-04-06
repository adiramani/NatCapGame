using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {
    
    PiecePlace piecePlace;
    int score = 0;
    Text scoreText; 

	void Start () {
        piecePlace = GameObject.Find("LevelManager").GetComponent<PiecePlace>();
        scoreText = gameObject.transform.FindChild("ScoreText").GetComponent<Text>();
	}

    public void recalculate() {
        score = 0;

        foreach(GamePieceScript piece in piecePlace.pieces) {
            score += piece.getScore();
        }

        displayScore(score);
    }

    public void displayScore(int score) {
        scoreText.text = "Score: " + score.ToString();
    }
}
