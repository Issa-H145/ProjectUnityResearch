using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class ParcelMovement : MonoBehaviour{
    public GameObject[] WayPointPositions; //Declaring WayPoint Positions and whatever is passed from script
    private int currentWaypointIndex = 0; //CurrentWayPointIndex starting at 0 for the MoveBox function 
    private float speed = 3.5f; //Speed of the parcel going through the conveyor belt
    private float rotSpeed = 10.0f; //Rotation speed of the parcel through the conveyor belt

    void Update(){
        if (WayPointPositions.Length == 0) return; //Checking to see if the array has elements. If it doesn't then it will not run any further code.

        MoveBox(); //Using the MoveBox function if there is elements inside of the array.
    }

    private void MoveBox(){
        if (Vector3.Distance(transform.position, WayPointPositions[currentWaypointIndex].transform.position) <= 0.001f){ /*What we first do is find the distance that is between the parcel 
                                                                                                                        and the next waypoint. we would then use a relational operator 
                                                                                                                        is less than the fixed number that we gave it. This is saying that 
                                                                                                                        the number that is less than 0.001f then it would increment and
                                                                                                                        got to the next waypoint of the the potets/WaypointPositions array. */
        
            currentWaypointIndex++; //Increments to the next part of the WayPointPositions array.
            if (currentWaypointIndex >= WayPointPositions.Length){
                Destroy(gameObject); /* Once the parcel reaches for the truck or when we start to put back the parcel into index 0, we destroy the GameObject. In technicallity, 
                                        does go inside the truck but it's destroyed in the inside pretending that the parcel is shipped inside of a container */
                return; //Once the box is destroyed/stored, the return will not execute any further code after.
            }
        }

        Vector3 direction = (WayPointPositions[currentWaypointIndex].transform.position - transform.position).normalized; /*A little concept was needed to perform this and what this would
                                                                                                                            do is calculate the normalized direction vector from the current
                                                                                                                            position of the box to the target waypoint. In General, this indicate 
                                                                                                                            the direction and distance to the target wayPoint. Using normalized
                                                                                                                            will make the rotations consistent and control movement to be much 
                                                                                                                            easier to deal with.*/
        transform.Translate(direction * speed * Time.deltaTime, Space.World); /*Using translate function to oversee the coordinates 
                                                                                of the game world so the parcel is knowledgeable to 
                                                                                know what to do.*/

        Quaternion targetRotation = Quaternion.LookRotation(direction); /*Using the Quaternion.LookRotation to make the parcel look and turn 
                                                                          to the next waypoint of the system.*/
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime); /*Using the Quaternion.Slerp will make the rotations have a 
                                                                                                                smoother transiton from one rotation to another.*/

    }
}
