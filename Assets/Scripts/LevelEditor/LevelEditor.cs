using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelEditor : MonoBehaviour {

    // This script manages ValueBtns, which are the buttons to switch between painting scores 0-50

    public bool editing = true;
    public ValueBtn defaultButton; // configurable
    List<ValueBtn> valueBtns = new List<ValueBtn>();
    public int currentValue = 0;
    
    void Start() {
        defaultButton.select();
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
