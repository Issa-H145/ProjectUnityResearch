using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

using UnityEngine;
using UnityEngine.AI;

public class Directions : MonoBehaviour{

    int StartingWayPoint = 0;
    
    public List<Transform> WayPointPositions = new List<Transform>();
    public List<Transform> WayPointPositions1 = new List<Transform>();
    public List<Transform> WayPointPositions2 = new List<Transform>();
    public List<Transform> WayPointPositions3 = new List<Transform>();
    
    private Vector3 startingPosition;

    public void Bin1(GameObject usingBox, int usingZipcode){
        while(usingZipcode == 30190){
            usingBox.transform.position = WayPointPositions[StartingWayPoint].transform.position;
        }
        
    }


}
