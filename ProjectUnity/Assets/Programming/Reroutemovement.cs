using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reroutemovement : MonoBehaviour{

    private int waypointindex = 0; //Declaring the waypointindex starting at 0 for the MoveToNextWaypoint function
    private float speedy = 3.5f; //Speed of the parcel going through the conveyor belt
    private float rotatingSpeed = 10.0f; //Rotation speed of the parcel through the conveyor belt
    public GameObject [] reroutingtype; //Declaring reroutingtype and whatever is passed from script
    private Parcel.BoxInfo [] BoxSomething; //Getting the BoxInfo from the Parcel script

    public void Initialize(GameObject[] waypoints, Parcel.BoxInfo[] boxInfo) {
        reroutingtype = waypoints; //Setting the reroutingtype to the waypoints
        BoxSomething = boxInfo; //Setting the BoxSomething to the boxInfo
    }

    void Update() {
        if (reroutingtype != null && reroutingtype.Length > 0) { //Checking to see if the array has elements. If it doesn't then it will not run any further code.
            MoveToNextWaypoint(); //Using the MoveToNextWaypoint function if there is elements inside of the array.
        }
    }

    private void MoveToNextWaypoint() { //Creating the MoveToNextWaypoint function`
        string findingCloneClone = gameObject.name;
        if (Vector3.Distance(transform.position, reroutingtype[waypointindex].transform.position) <= 0.001F) { /*What we first do is find the distance that is between the parcel 
                                                                                                                and the next waypoint. we would then use a relational operator 
                                                                                                                is less than the fixed number that we gave it. This is saying that 
                                                                                                                the number that is less than 0.001f then it would increment and
                                                                                                                got to the next waypoint of the the potets/WaypointPositions array. */
            waypointindex++; //Increments to the next part of the WayPointPositions array.

            if (waypointindex >= reroutingtype.Length) { //Checking to see if the waypointindex is greater than or equal to the reroutingtype array
                waypointindex = 0; //If the waypointindex is greater than or equal to the reroutingtype array, then it will go back to the first index of the array
                int rando = Random.Range(0, BoxSomething.Length); //Randomizing the BoxSomething array
                int ActualZipCode = BoxSomething[rando].zipcode; //Getting the zipcode from the BoxSomething array
                Destroy(gameObject); //Once the box is destroyed/stored, the return will not execute any further code after.
                gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); //Setting the scale of the parcel
                Parcel parcelScript = FindObjectOfType<Parcel>(); //Finding the Parcel script
                parcelScript.SpawnBox(gameObject, ActualZipCode); //Spawning the box with the gameObject and the ActualZipCode
                return; //Once the box is destroyed/stored, the return will not execute any further code after.
            }
            if(findingCloneClone.Contains("(Clone)(Clone)")){
                    Destroy(gameObject);
                }
        }

        Vector3 direction = (reroutingtype[waypointindex].transform.position - transform.position).normalized; /*A little concept was needed to perform this and what this would
                                                                                                                do is calculate the normalized direction vector from the current
                                                                                                                position of the box to the target waypoint. In General, this indicate 
                                                                                                                the direction and distance to the target wayPoint. Using normalized
                                                                                                                will make the rotations consistent and control movement to be much 
                                                                                                                easier to deal with.*/

        transform.Translate(direction * speedy * Time.deltaTime, Space.World);//Using translate function to oversee the coordinates

        Quaternion targetRotation = Quaternion.LookRotation(direction);//Using the Quaternion.LookRotation to make the parcel look and turn to the next waypoint of the system.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotatingSpeed * Time.deltaTime);//Using the Quaternion.Slerp will make the rotations have a smoother transiton from one rotation to another.
    }
}
