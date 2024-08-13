using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reroutemovement : MonoBehaviour{

    private int waypointindex = 0;
    private float speedy = 3.5f;
    private float rotatingSpeed = 10.0f;
    public GameObject[] reroutingtype;
    private Parcel.BoxInfo[] BoxSomething;

    public void Initialize(GameObject[] waypoints, Parcel.BoxInfo[] boxInfo) {
        reroutingtype = waypoints;
        BoxSomething = boxInfo;
    }

    void Update() {
        if (reroutingtype != null && reroutingtype.Length > 0) {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint() {
        if (Vector3.Distance(transform.position, reroutingtype[waypointindex].transform.position) <= 0.001F) {
            waypointindex++;

            if (waypointindex >= reroutingtype.Length) {
                waypointindex = 0;
                int rando = Random.Range(0, BoxSomething.Length);
                int ActualZipCode = BoxSomething[rando].zipcode;
                Destroy(gameObject);
                gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                Parcel parcelScript = FindObjectOfType<Parcel>();
                parcelScript.SpawnBox(gameObject, ActualZipCode);
                return;
            }
        }

        Vector3 direction = (reroutingtype[waypointindex].transform.position - transform.position).normalized;
        transform.Translate(direction * speedy * Time.deltaTime, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotatingSpeed * Time.deltaTime);
    }
}
