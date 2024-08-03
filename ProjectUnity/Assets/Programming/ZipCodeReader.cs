using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class ZipCodeReader : MonoBehaviour{

    public int source;

    void OnTriggerEnter(Collider other){
        Debug.Log($"Zip code: {source}");
    }
    
}
