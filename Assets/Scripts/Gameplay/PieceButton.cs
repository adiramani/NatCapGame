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
    Color defaultColor;
    Color highlightColor = new Color(0, 1f, 0.96f);

    void Start() {
        piecePlace = GameObject.Find("LevelManager").GetComponent<PiecePlace>();
        button = gameObject.GetComponent<Button>();
        image = gameObject.transform.FindChild("Image").GetComponent<Image>();
        remainderText = gameObject.transform.FindChild("Remainder").GetComponent<Text>();

        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = highlightColor;
        button.colors = colorBlock;

        defaultColor = colorBlock.disabledColor;

        if(pieceType == PiecePlace.PieceType.Port) {
            select();
        }
        else {
            deselect();
        }
    }

    public void updateRemainder(int remainder) {
        remainderText.text = remainder.ToString();
    }

    public void select() {
        button.interactable = true;
        piecePlace.setPiece(pieceType);
        image.color = highlightColor;
    }

    public void deselect() {
        button.interactable = false;
        image.color = defaultColor;
    }
}
