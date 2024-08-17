using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Faulty : MonoBehaviour{

    public GameObject conveyorError; //Declaring the conveyorError GameObject

    Vector3 FaultPosition = new Vector3(-17.912f, 1.59f, 2.373f); //Declaring the position of the conveyorError GameObject
    Quaternion EulerPosition = Quaternion.Euler(-90.0f, 0.0f, 0.0f); //Declaring the rotation of the conveyorError GameObject

    public void Faultys(){
        conveyorError.transform.localScale = new Vector3(1.5038f, 1.5038f, 1.5038f); //Setting the scale of the conveyorError GameObject
        GameObject ErrorSign = Instantiate(conveyorError, FaultPosition, EulerPosition); //Instantiating the conveyorError GameObject

    }
}