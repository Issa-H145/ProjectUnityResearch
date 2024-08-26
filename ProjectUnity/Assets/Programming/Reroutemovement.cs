using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Reroutemovement : MonoBehaviour{

    private int waypointindex = 0; //Declaring the waypointindex starting at 0 for the MoveToNextWaypoint function
    private float speedy = 3.5f; //Speed of the parcel going through the conveyor belt
    private float rotatingSpeed = 10.0f; //Rotation speed of the parcel through the conveyor belt
    public GameObject [] reroutingtype; //Declaring reroutingtype and whatever is passed from script
    private Parcel.BoxInfo [] BoxSomething; //Getting the BoxInfo from the Parcel script

    void Update() { 
        if (reroutingtype.Length == 0) return; //Checking to see if the array has elements. If it doesn't then it will not run any further code.
            MoveToNextWaypoint(); //Using the MoveToNextWaypoint function if there is elements inside of the array.

    }

    public void MoveToNextWaypoint(){

        Parcel getting = FindAnyObjectByType<Parcel>();

        if (Vector3.Distance(transform.position, reroutingtype[waypointindex].transform.position) <= 0.01f){
            waypointindex++;

            if (waypointindex >= reroutingtype.Length){
                waypointindex = 0;
                Destroy(gameObject);
                int rando = Random.Range(0, getting.BoxSomething.Length);
                int actualZipCode = getting.BoxSomething[rando].zipcode;

                // If we are rerouting
                if (actualZipCode == 0){
                    getting.SpawnBox(gameObject, actualZipCode);
                    
                }
                else{
                    getting.SpawnBox(gameObject, actualZipCode);
                }
                 return;
            }
        }

        Vector3 direction = (reroutingtype[waypointindex].transform.position - transform.position).normalized;
        transform.Translate(direction * speedy * Time.deltaTime, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotatingSpeed * Time.deltaTime);
    }

}
