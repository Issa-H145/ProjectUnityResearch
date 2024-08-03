using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Threading;
using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
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

    public BoxInfo[] BoxSomething; //Declaring the BoxInfo[] struct as BoxSomething
    public GameObject boxLarge; //BoxLarge also known as box-large in the Game world
    public GameObject Box_1; //Box_1 GameObject in the Game World
    public GameObject Box_2; //Box_2 GameObject in the Game World
    public GameObject Barrel; //Barrel GameObject in the Game World
    public GameObject [] WayPointPositions1; //WayPointPositions for the zip code 30190
    public GameObject [] WayPointPositions2; //WayPointPositions for the zip code 46675
    public GameObject [] WayPointPositions3; //WayPointPositions for the zip code 72532
    public GameObject [] WayPointPositions4; //WayPointPositions for the zip code 11075
    public GameObject [] WayPointPositions5; //WayPointPositions for the zip code 24701

    

   //private PhysicsAndGravity Applied;

    void Start(){
        /*
        Applied = FindObjectOfType<PhysicsAndGravity>();
        if (Applied == null)
        {
            Debug.LogError("PhysicsAndGravity is not found!");
        }
        */

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
            new BoxInfo(Box_2, 24701)
        };
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){ //Pressing space makes the box spawn

            RandomBox(); //Calling the RandomBox function to generate a parcel
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
        Vector3 startingPosition = new Vector3(-0.629f, 0.872f, 6.0296f); //The positiin where the parcel is supposed to spawn.
        GameObject spawnedBox = Instantiate(box, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                                            The last one that we made was was the Quaternion.identity to make no rotation.*/
       

        ParcelMovement parcelMovement = spawnedBox.AddComponent<ParcelMovement>(); /*Attaching the GameObject to the parcel movement script to gain the functionality of movement. The parcel
                                                                                    movement script is where all the WayPointPosition arrays will go for movement based parcels*/
        

        /*This is where the zip codes will go to depending on which zip code is spawned. Once the zipcode is spawned, it will be going to one of the test cases to see which one it goes to.
        The parcelMovement.WayPointPositions = WayPointPositions, etc will call the WayPointPositions in the script and will use what it's given to move the parcel.*/
        switch (zipCode){
            case 30190:
                parcelMovement.WayPointPositions = WayPointPositions1; //Parcel Movement script will use the 30190 WayPointPositions

                break;
            case 46675:
                parcelMovement.WayPointPositions = WayPointPositions2; //Parcel Movement script will use the 46675 WayPointPositions
                break;

            case 72532:
                parcelMovement.WayPointPositions = WayPointPositions3;
                break;

            case 11075:
                parcelMovement.WayPointPositions = WayPointPositions4; //Parcel Movement script will use the 11075 WayPointPositions
                break;

            case 24701:
                parcelMovement.WayPointPositions = WayPointPositions5; //Parcel Movement script will use the 24701 WayPointPositions
                break;
        }
    }
}
    
    

/*The first idea of the parcel spawner was that we would have to create a seperate
script that contained the ofSomeBox GameObject it would look like

private Spawner ofSomeSpawn; <-- Calling the Spawner script

ofSomeSpawn = GetComponent<Spawner>(); <-- Finding any object type in that script

ofSomeSpawn.SpawnBox(ofSomeBox); <-- Calling a specific function in that script that we linked together.

I decided to not include in a seperate script and only use it a parcel script.


*/