using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    Button restartBtn;
    Text scoreText;
    Canvas canvas;
    Calculator calculator;

	void Start() {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;

        scoreText = gameObject.transform.FindChild("Panel/ScoreLabel/ScoreText").gameObject.GetComponent<Text>();

        restartBtn = gameObject.transform.FindChild("Panel/RestartBtn").gameObject.GetComponent<Button>();
        restartBtn.onClick.AddListener(RestartBtnClick);

        calculator = GameObject.Find("CalculatorCanvas").GetComponent<Calculator>();
    }

    public void show() {
        scoreText.text = calculator.score + " points";
        canvas.enabled = true;
    }

    void RestartBtnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
