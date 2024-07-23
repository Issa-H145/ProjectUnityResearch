using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDirections : MonoBehaviour
{

    int StartingWayPoint = 0;
    float speed; 
    public GameObject [] WayPointPositions;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
          speed = 3.0f * Time.deltaTime;
            if(Vector3.Distance(this.transform.position, WayPointPositions[StartingWayPoint].transform.position) > 0)
                StartingWayPoint++;
                
            

            if(StartingWayPoint >= WayPointPositions.Length)
                StartingWayPoint = 0;
            
                this.transform.LookAt(WayPointPositions[StartingWayPoint].transform);
                this.transform.Translate(0, 0, speed);
            
        }
        
    }

