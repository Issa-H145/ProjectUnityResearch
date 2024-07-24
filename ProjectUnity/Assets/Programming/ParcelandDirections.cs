using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Parcel : MonoBehaviour{

    public struct BoxInfo{
        public GameObject box;
        public int zipcode;
    

    public BoxInfo(GameObject boxing,  int zipper){

        box = boxing;
        zipcode = zipper;

        }
    }

        public BoxInfo [] BoxSomething;

        public GameObject boxLarge; //Connected to the box-long asset in the scene
        public GameObject Box_1;
        public GameObject Box_2;
        public GameObject Barrel;
        private Vector3 startingPosition; /*Declaring a specifc spawnPoint in the scene
                                             meaning we want all the parcels to spawn at 
                                             the loading area.*/
    int StartingWayPoint = 0;
    float speed; 
    public GameObject [] WayPointPositions;
    public GameObject [] WayPointPositions1;
    public GameObject [] WayPointPositions2;
    public GameObject [] WayPointPositions3;
    private GameObject [] introwonings = new GameObject[4];
   
    public PhysicsAndGravity Applied;
                                                  

    // Start is called before the first frame update
    void Start(){

        if(Applied == null){
            Applied = FindObjectOfType<PhysicsAndGravity>();
        if(Applied == null){
            Debug.LogError("PhysicsAndGravity is not found!");
            }
        }


        BoxSomething = new BoxInfo[]{
                new BoxInfo(boxLarge, 30190),
                new BoxInfo(Barrel, 30190),
                new BoxInfo(Box_1, 30190),
                new BoxInfo(Box_2, 30190),
                new BoxInfo(boxLarge, 46675),
                new BoxInfo(Barrel, 46675),
                new BoxInfo(Box_1, 46675),
                new BoxInfo(Box_2, 46675),
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

    // Update is called once per frame
    void Update(){

           if(Input.GetKeyDown(KeyCode.Space)){ //Pressing space makes the box spawn
            RandomBox(); //Calling the RandomBox function to generate a parcel
           }
        for (int i = 0; i < introwonings.Length; i++){
                 if (introwonings[i] != null){
                Movement(introwonings[i], GetWayPointPositions(i));
            }
        }
           
    }

    private void RandomBox(){

        int randomize = Random.Range(0, BoxSomething.Length); /*Making an int randomize by 
                                                                ranging 0 to the size of the 
                                                                list being 3*/
        GameObject ofSomeBox = BoxSomething[randomize].box; /*Once we have a randomized number from
                                                            the range, we will use this as an element
                                                            to get a specific parcel from the list. We're
                                                            also declaring this as a Gameobject to ge the
                                                            actual 3D asset.*/
        int ofSomeZipCode = BoxSomething[randomize].zipcode;
        ofSomeBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); /*Scaling the parcel so it's fits inside 
                                                                         inside the conveyor belt.*/

        SpawnBox(ofSomeBox, ofSomeZipCode); /*Calling the SpawnBox function with a GameObject
                                ofSomeBox.*/

    }

     public void SpawnBox(GameObject BoxFromOther, int ZipCodeFromOther){ /*This initially was on a seperate 
                                                        script but didn't think it was needed
                                                        because of unecessary code*/

            startingPosition = new Vector3(-2.271f, 0.8699999f, 0.8577683f);

                switch(ZipCodeFromOther){

                    case 30190:
                    Debug.Log($"{BoxFromOther} having the zipcode of {ZipCodeFromOther}");
                    introwonings[0] = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                                                     BoxFromOther that was passed from tge SpawnBox function. 
                                                                                                      We then use the startingPosition coordinates that we made earlier.
                                                                                                    The last one that we made was was the Quaternion.identity to make no rotation.*/
                    break;

                    case 46675:
                    Debug.Log($"{BoxFromOther} having the zip code of {ZipCodeFromOther}");
                    introwonings[1] = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                          The last one that we made was was the Quaternion.identity to make no rotation.*/ 
                    break;

                    case 11075:
                    Debug.Log($"{BoxFromOther} having the zip code of {ZipCodeFromOther}");
                    introwonings[2] = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                          The last one that we made was was the Quaternion.identity to make no rotation.*/ 

                    break;

                    case 24701:
                    Debug.Log($"{BoxFromOther} having the zip code of {ZipCodeFromOther}");
                    introwonings[3] = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                          The last one that we made was was the Quaternion.identity to make no rotation.*/ 
                    break;

            }

             Applied.rigidBodyRumcation(BoxFromOther);

        
        }

   private void Movement(GameObject box, GameObject[] waypoints){
        if (waypoints == null || waypoints.Length == 0) return;

        float step = speed * Time.deltaTime;
        if (Vector3.Distance(box.transform.position, waypoints[StartingWayPoint].transform.position) <= 0.005f){
            StartingWayPoint++;
        }

        if (StartingWayPoint >= waypoints.Length){
            StartingWayPoint = 0;
        }

        box.transform.LookAt(waypoints[StartingWayPoint].transform);
        box.transform.Translate(0, 0, step);
    }

            private GameObject[] GetWayPointPositions(int index){

                switch (index){

                     case 0: return WayPointPositions;
                     case 1: return WayPointPositions1;
                     case 2: return WayPointPositions2;
                     case 3: return WayPointPositions3;
                     default: return null;
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