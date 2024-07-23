using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class Directions : MonoBehaviour{

    int StartingWayPoint = 0;
    float minDistance;
    public GameObject OnSomeWay;
    public bool OnForCheck = true;
    public bool OnForRand = false;

    float speed; 
    public GameObject [] WayPointPositions;
    //public List<GameObject> WayPointPositions1 = new List<GameObject>();
    
    //public List<GameObject> WayPointPositions2 = new List<GameObject>();
   // public List<GameObject> WayPointPositions3 = new List<GameObject>();


    public void Bin1(GameObject usingBox){

        /*
       // float distance = Vector3.Distance(usingBox.transform.position, WayPointPositions[StartingWayPoint].transform.position);
            //Debug.Log($"Distance to waypoint: {distance}");

            if(OnForCheck){
                if(distance <= minDistance || distance >= minDistance){
                    GoingToMove(usingBox);
            }
                else{
                    if(!OnForRand){
                        if(StartingWayPoint + 1 == WayPointPositions.Length){
                            StartingWayPoint = 0;
                        }
                        else{
                            StartingWayPoint++;
                        }
                    }

                }

            }
            */
            

            if(Vector3.Distance(usingBox.transform.position, WayPointPositions[StartingWayPoint].transform.position) <= 3)
                StartingWayPoint++;

            if(StartingWayPoint >= WayPointPositions.Length){
                StartingWayPoint = 0;

                usingBox.transform.LookAt(WayPointPositions[StartingWayPoint].transform);
                usingBox.transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }

        public void GoingToMove(GameObject Rumcation){
            float speed = 3.0f * Time.deltaTime;
            Rumcation.transform.LookAt(WayPointPositions[StartingWayPoint].transform.position);
            Rumcation.transform.position += Rumcation.transform.forward * speed;
            }
        }

        
        


