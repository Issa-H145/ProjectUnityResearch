using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.AI;

public class Directions : MonoBehaviour{

    int StartingWayPoint = 0;
    float minDistance = 0.001f;
    public GameObject OnSomeWay;

    float speed;
    public GameObject [] WayPointPositions;
    public List<GameObject> WayPointPositions1 = new List<GameObject>();
    public List<GameObject> WayPointPositions2 = new List<GameObject>();
    public List<GameObject> WayPointPositions3 = new List<GameObject>();
    
    void Start (){

        
    }
    
    void Update(){

    }

    public void Bin1(GameObject usingBox){
        //usingBox.transform.position = Vector3.MoveTowards(WayPointPositions[StartingWayPoint].transform.position);

        //Vector3 targetSpot = WayPointPositions[StartingWayPoint].transform.position;
        //Vector3 currentSpot = usingBox.transform.position;
        float distance = Vector3.Distance(usingBox.transform.position, WayPointPositions[StartingWayPoint]
                                                .transform.position);

            speed = 5.0f * Time.deltaTime;

                checkingDistance(distance);

            //usingBox.transform.position = Vector3.MoveTowards(currentSpot, targetSpot, speed);

            
        }

        public void checkingDistance(float distance){
            if(distance <= minDistance){
                nextSpot();
            }
        }

        public void nextSpot(){
            OnSomeWay = WayPointPositions[StartingWayPoint++];
        }
        
    }



