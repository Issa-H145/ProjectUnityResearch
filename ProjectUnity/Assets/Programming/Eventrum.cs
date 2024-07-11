using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Eventrum : MonoBehaviour{

    public event EventHandler OnSpacePressed;

    // Start is called before the first frame update
    private void Start(){
        OnSpacePressed += Testing_OnSpacePressed;
        
    }

    private void Testing_OnSpacePressed(object sender, EventArgs e){
        Debug.Log("Space is provided");
    }

    private void Update(){

        if(Input.GetKeyDown(KeyCode.Space)){
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }
    }

    
}
