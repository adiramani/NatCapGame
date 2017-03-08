using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBtn : MonoBehaviour {
    
    public int value = 0;
    LevelEditor levelEditor;
    Button button;
    ColorBlock colorBlock;

	// Use this for initialization
	void Start() {
        levelEditor = GameObject.Find("EditorCanvas").GetComponent<LevelEditor>();
        button = gameObject.GetComponent<Button>();
        ColorBlock colorBlock = button.colors;
        button.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update() {
		
	}

    void OnClick() {
        levelEditor.setBtnValue(value);
        select();
    }

    public void select() {
        //colorBlock.normalColor = new Color(0, 255, 246);
    }

    public void deselect() {
        //colorBlock.normalColor = Color.white;
    }
}
