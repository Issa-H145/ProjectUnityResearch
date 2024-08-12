using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Faulty : MonoBehaviour{

    public GameObject conveyorError;

    Vector3 FaultPosition = new Vector3(-17.912f, 1.59f, 2.373f);
    Quaternion EulerPosition = Quaternion.Euler(-90.0f, 0.0f, 0.0f);

    public void Faultys(){
        conveyorError.transform.localScale = new Vector3(1.5038f, 1.5038f, 1.5038f);
        GameObject ErrorSign = Instantiate(conveyorError, FaultPosition, EulerPosition);

    }
}
