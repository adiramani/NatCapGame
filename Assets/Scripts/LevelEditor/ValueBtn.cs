using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBtn : MonoBehaviour {
    
    public int value = 0;
    LevelEditor levelEditor;
    Button button;
    ColorBlock defaultColorBlock;
    ColorBlock selectedColorBlock;

	// Use this for initialization
	void Start() {
        levelEditor = GameObject.Find("EditorCanvas").GetComponent<LevelEditor>();
        button = gameObject.GetComponent<Button>();

        defaultColorBlock = button.colors;
        selectedColorBlock = button.colors;
        selectedColorBlock.normalColor = new Color(0.97f, 0.61f, 0.133f);
        selectedColorBlock.highlightedColor = new Color(0.97f, 0.61f, 0.133f);
        selectedColorBlock.pressedColor = new Color(0.97f, 0.61f, 0.133f);

        button.onClick.AddListener(OnClick);
        levelEditor.registerButton(this);

        if (value == 0) {
            select();
        }
    }

    void OnClick() {
        levelEditor.setBtnValue(value);
    }

    public void select() {
        button.colors = selectedColorBlock;
    }

    public void deselect() {
        button.colors = defaultColorBlock;
    }
}
