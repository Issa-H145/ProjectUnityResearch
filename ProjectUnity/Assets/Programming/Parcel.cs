using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Reflection;
using System.Threading;
using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;


public class Parcel : MonoBehaviour{

    /*All of the parcels data will go here so when we create a new element inside of the BoxSomething Array of structs, all
of the information will go in here will be used throughout the program. This is a form of encapsulation so if somethihng is passed
then it will go here.*/
    public struct BoxInfo
    {
        public GameObject box;
        public int zipcode;

        public BoxInfo(GameObject boxing, int zipper)
        {
            box = boxing;
            zipcode = zipper;
        }
    }

    [SerializeField] private BoxInfo[] BoxSomething; //Declaring the BoxInfo[] struct as BoxSomething
    [SerializeField] private GameObject boxLarge; //BoxLarge also known as box-large in the Game world
    [SerializeField] private GameObject Box_1; //Box_1 GameObject in the Game World
    [SerializeField] private GameObject Box_2; //Box_2 GameObject in the Game World
    [SerializeField] private GameObject Barrel; //Barrel GameObject in the Game World
    private GameObject reroutedBox;
    private int waypointindex = 0;
    private float speedy = 3.5f;
    private float rotatingSpeed = 10.0f;
    public GameObject [] WayPointPositions1; //WayPointPositions for the zip code 30190
    public GameObject [] WayPointPositions2; //WayPointPositions for the zip code 46675
    public GameObject [] WayPointPositions3; //WayPointPositions for the zip code 72532
    public GameObject [] EmergencyRoute3;
    public GameObject [] WayPointPositions4; //WayPointPositions for the zip code 11075
    public GameObject [] EmergencyRoute4;
    public GameObject [] WayPointPositions5; //WayPointPositions for the zip code 24701
    public GameObject [] EmergencyRoute5;
    public GameObject [] reroutingSystem;
    public List<GameObject> Destroyed = new List<GameObject>();

    public Faulty willCauseError;

    void Start(){

        willCauseError = GetComponent<Faulty>();
        /*All the parcels and there corresponding information. Other attempts were made for this to be shorter like randomizing zip codes
        into randomized boxes but it lead to constant dead ends so it wasn't and option to use. Instead we use an array of structs with encapsulation to hold all 
        the information in as we start randomizing them.*/

        BoxSomething = new BoxInfo[]{
            new BoxInfo(boxLarge, 30190),
            new BoxInfo(Barrel, 30190),
            new BoxInfo(Box_1, 30190),
            new BoxInfo(Box_2, 30190),
            new BoxInfo(boxLarge, 46675),
            new BoxInfo(Barrel, 46675),
            new BoxInfo(Box_1, 46675),
            new BoxInfo(Box_2, 46675),
            new BoxInfo(boxLarge, 72532),
            new BoxInfo(Barrel, 72532),
            new BoxInfo(Box_1, 72532),
            new BoxInfo(Box_2, 72532),
            new BoxInfo(boxLarge, 11075),
            new BoxInfo(Barrel, 11075),
            new BoxInfo(Box_1, 11075),
            new BoxInfo(Box_2, 11075),
            new BoxInfo(boxLarge, 24701),
            new BoxInfo(Barrel, 24701),
            new BoxInfo(Box_1, 24701),
            new BoxInfo(Box_2, 24701),
            new BoxInfo(boxLarge, 0),
            new BoxInfo(Barrel, 0),
            new BoxInfo(Box_1, 0),
            new BoxInfo(Box_2, 0)
        };

    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){ //Pressing space makes the box spawn
            RandomBox(); //Calling the RandomBox function to generate a parcel
        }

        else if(Input.GetKeyDown(KeyCode.S)){
           foreach(GameObject destroying in Destroyed){
           Destroy(destroying);
           }
           willCauseError.Faultys();
        }
        if(reroutedBox != null){
            reroute(reroutedBox);
        }
    }

    private void RandomBox(){
        int randomize = Random.Range(0, BoxSomething.Length);/*Making an int randomize by 
                                                                ranging 0 to the size of the 
                                                                list being 15*/
        GameObject ofSomeBox = BoxSomething[randomize].box; /*Once we have a randomized number from
                                                            the range, we will use this as an element
                                                            to get a specific parcel from the list. We're
                                                            also declaring this as a Gameobject to ge the
                                                            actual 3D asset. All of the data is coming from the BoxInfo
                                                            struct besides the zip code data.*/
        int ofSomeZipCode = BoxSomething[randomize].zipcode; /*The randomized number can also go to the randomized zip code
                                                                and obtain a randomized zip code from the BoxInfo data
                                                                handler.*/
        ofSomeBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); /*Scaling the parcel so it's fits inside 
                                                                         inside the conveyor belt.*/
        SpawnBox(ofSomeBox, ofSomeZipCode); /*Calling the SpawnBox function with a GameObject
                                            ofSomeBox and am integer zip code number*/
    }

    private void SpawnBox(GameObject box, int zipCode){ /*This initially was on a seperate 
                                                        script but didn't think it was needed
                                                        because of unecessary code*/
        
        
        Vector3 startingPosition = new Vector3(2.379f, 0.871f, 6.02f); //The positiin where the parcel is supposed to spawn.

        GameObject spawnedBox = Instantiate(box, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                                            The last one that we made was was the Quaternion.identity to make no rotation.*/
        if(zipCode != 0){
    
        ParcelMovement parcelMovement = spawnedBox.AddComponent<ParcelMovement>(); /*Attaching the GameObject to the parcel movement script to gain the functionality of movement. The parcel
                                                                                    movement script is where all the WayPointPosition arrays will go for movement based parcels*/
        GameObject found = GameObject.Find("Sign_4(Clone)");

        

        /*This is where the zip codes will go to depending on which zip code is spawned. Once the zipcode is spawned, it will be going to one of the test cases to see which one it goes to.
        The parcelMovement.WayPointPositions = WayPointPositions, etc will call the WayPointPositions in the script and will use what it's given to move the parcel.*/

        switch (zipCode){
            case 30190:
                Debug.Log($"{box} with a zip code {zipCode}");
                parcelMovement.WayPointPositions = WayPointPositions1; //Parcel Movement script will use the 30190 WayPointPositions
                break;

            case 46675:
                Debug.Log($"{box} with a zip code {zipCode}");
                parcelMovement.WayPointPositions = WayPointPositions2; //Parcel Movement script will use the 46675 WayPointPositions
                break;

            case 72532:
                Debug.Log($"{box} with a zip code {zipCode}");
                if(found == null){
                    parcelMovement.WayPointPositions = WayPointPositions3;
                }
                else if(found != null){
                    parcelMovement.WayPointPositions = EmergencyRoute3;
                }
                break;

            case 11075:
                Debug.Log($"{box} with a zip code {zipCode}");
                if(found == null){
                    parcelMovement.WayPointPositions = WayPointPositions4; //Parcel Movement script will use the 11075 WayPointPositions
                }
                else if(found != null){
                    parcelMovement.WayPointPositions = EmergencyRoute4;
                }
                break;

            case 24701:
                Debug.Log($"{box} with a zip code {zipCode}");
                if(found == null){
                    parcelMovement.WayPointPositions = WayPointPositions5; //Parcel Movement script will use the 24701 WayPointPositions
                }
                else if(found != null){
                    parcelMovement.WayPointPositions = EmergencyRoute5;
                }
                break;
                }
        }

        else{
            Debug.Log("No visible zip code! Time to reroute again");
            reroutedBox = spawnedBox;
        }
    }
        
        private void reroute(GameObject mislead){

                if(Vector3.Distance(mislead.transform.position, reroutingSystem[waypointindex].transform.position) <= 0.001F){
                    waypointindex++;

                    if(waypointindex >= reroutingSystem.Length){
                        waypointindex = 0;
                        int rando = Random.Range(0, BoxSomething.Length);
                        int ActualZipCode = BoxSomething[rando].zipcode;
                        reroutedBox = null;
                        Destroy(mislead);
                        SpawnBox(mislead, ActualZipCode);
                        return;
                    }
                }

            Vector3 unidirection = (reroutingSystem[waypointindex].transform.position - mislead.transform.position).normalized;

            mislead.transform.Translate(unidirection * speedy * Time.deltaTime, Space.World);

            Quaternion lookingfor = Quaternion.LookRotation(unidirection);

            mislead.transform.rotation = Quaternion.Slerp(mislead.transform.rotation, lookingfor,  rotatingSpeed * Time.deltaTime);
        }
    }

    
    

/*The first idea of the parcel spawner was that we would have to create a seperate
script that contained the ofSomeBox GameObject it would look like

private Spawner ofSomeSpawn; <-- Calling the Spawner script

ofSomeSpawn = GetComponent<Spawner>(); <-- Finding any object type in that script

ofSomeSpawn.SpawnBox(ofSomeBox); <-- Calling a specific function in that script that we linked together.

I decided to not include in a seperate script and only use it a parcel script.


*/