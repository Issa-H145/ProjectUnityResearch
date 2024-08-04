using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Faulty : MonoBehaviour{

    public GameObject conveyorError;

    private Vector3 rotation;

    public void Faultys(){

        Vector3 FaultPosition = new Vector3(-17.912f, 1.025f, 2.592f);
        GameObject ErrorSign = Instantiate(conveyorError, FaultPosition, Quaternion.identity);
        //ErrorSign.transform.rotation = Quaternion.euler)

    }
    
}
