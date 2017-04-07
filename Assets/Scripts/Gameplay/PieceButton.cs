using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PieceButton : MonoBehaviour {

    // set default piece type
    public PiecePlace.PieceType pieceType = PiecePlace.PieceType.Mine;
    PiecePlace piecePlace;
    Button button;
    Image image;
    Text remainderText;
    ColorBlock defaultColorBlock;
    ColorBlock selectedColorBlock;

    void Start() {
        piecePlace = GameObject.Find("LevelManager").GetComponent<PiecePlace>();
        button = gameObject.GetComponent<Button>();
        image = gameObject.transform.FindChild("Image").GetComponent<Image>();
        remainderText = gameObject.transform.FindChild("Remainder").GetComponent<Text>();

        defaultColorBlock = button.colors;
        selectedColorBlock = button.colors;
        selectedColorBlock.normalColor = new Color(0, 1f, 0.96f);
        selectedColorBlock.highlightedColor = new Color(0, 1f, 0.96f);
        selectedColorBlock.pressedColor = new Color(0, 1f, 0.96f);

        button.onClick.AddListener(OnClick);
        piecePlace.registerButton(this);

        if(pieceType == PiecePlace.PieceType.Port) {
            select();
        }
    }

    void OnClick() {
        piecePlace.setPiece(pieceType);
    }

    public void updateRemainder(int remainder) {
        remainderText.text = remainder.ToString();
    }

    public void select() {
        button.colors = selectedColorBlock;
        image.color = selectedColorBlock.normalColor;
    }

    public void deselect() {
        button.colors = defaultColorBlock;
        image.color = defaultColorBlock.normalColor;
    }
}
