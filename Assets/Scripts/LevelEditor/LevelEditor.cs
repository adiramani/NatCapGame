using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelEditor : MonoBehaviour {

    // This script manages ValueBtns, which are the buttons to switch between painting scores 0-50

    public bool editing = true;
    List<ValueBtn> valueBtns = new List<ValueBtn>();
    public int currentValue = 0;
    
    void Start() {
        gameObject.GetComponent<Canvas>().enabled = editing;
    }

    public void setBtnValue(int newValue) {
        currentValue = newValue;

        foreach (ValueBtn valueBtn in valueBtns) {
            valueBtn.deselect();
        }

        foreach (ValueBtn valueBtn in valueBtns) {
            if (valueBtn.value == newValue) {
                valueBtn.select();
            }
            else {
                valueBtn.deselect();
            }
        }
    }

    public void registerButton(ValueBtn valueBtn) {
        valueBtns.Add(valueBtn);
    }
}
