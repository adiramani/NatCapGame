using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelEditor : MonoBehaviour {

    public bool editing = true;
    List<ValueBtn> valueBtns = new List<ValueBtn>();
    public int currentValue = 0;

	// Use this for initialization
	void Start() {

    }
	
	// Update is called once per frame
	void Update() {
		
	}

    public void setBtnValue(int newValue) {
        Debug.Log("New value: " + newValue);
        currentValue = newValue;

        foreach (ValueBtn valueBtn in valueBtns) {
            valueBtn.deselect();
        }
    }

    public void registerButton(ValueBtn valueBtn) {
        valueBtns.Add(valueBtn);
    }
}
