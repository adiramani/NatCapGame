using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelEditor : MonoBehaviour {

    public bool editing = true;
    List<ValueBtn> valueBtns = new List<ValueBtn>();
    public int currentValue = 0;
    public ValueBtn defaultButton;

    // Use this for initialization
    void Start() {
        defaultButton.select();
    }
	
	// Update is called once per frame
	void Update() {
		
	}

    public void setBtnValue(int newValue) {
        currentValue = newValue;

        foreach (ValueBtn valueBtn in valueBtns) {
            valueBtn.deselect();
        }
    }

    public void registerButton(ValueBtn valueBtn) {
        valueBtns.Add(valueBtn);
    }
}
