using System.Collections.Generic;
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
    public struct BoxInfo{
        public GameObject box;
        public int zipcode;
    

    public BoxInfo(GameObject boxing,  int zipper){

        box = boxing;
        zipcode = zipper;

     }
    }

    public BoxInfo [] BoxSomething;

    /*
        public Dictionary<GameObject, int> DifferentBoxes = new Dictionary<GameObject, int>(); /*A list that contains
        different parcel GameObjects. This list will contain the GameObjects that will be'
        be used throughout the Conveyor*/
        public GameObject boxLarge; //Connected to the box-long asset in the scene
        public GameObject Box_1;
        public GameObject Box_2;
        public GameObject Barrel;
        private Vector3 startingPosition; /*Declaring a specifc spawnPoint in the scene
                                             meaning we want all the parcels to spawn at 
                                             the loading area.*/
    int StartingWayPoint = 0;
    float speed; //Speed for the parcel
    float rotSpeed; // rotation speed for the parcel
    public GameObject [] WayPointPositions; // fixed positions for the zip code 30190
    public GameObject [] WayPointPositions1; // fixed positions for the zip code 46675
    public GameObject [] WayPointPositions2; // fixed positons of the zip code 11075
    public GameObject [] WayPointPositions3; // fixed positions for the zip code 24701
    private GameObject introwoning; //Used for null checking and the MoveBox function. Associated with WayPointPositions and 30190
    private GameObject introwoning1; //Used for null checking and the MoveBox function. Associated with WayPointPositions1 and 46675
    private GameObject introwoning2; //Used for null checking and the MoveBox function. Associated with WayPointPositions2 and 11075
    private GameObject introwoning3; //Used for null checking and the MoveBox function. Associated with WayPointPositions3 and 24701

    public PhysicsAndGravity Applied;
                                                  

    // Start is called before the first frame update
    void Start(){

    /*Checking to see if the PhysicsAndGravity script is connected to the ParcelAndDirections script
        so we can use the RigidBody and MeshCollider functionality*/

        if(Applied == null){
            Applied = FindObjectOfType<PhysicsAndGravity>();
        if(Applied == null){
            Debug.Log("PhysicsAndGravity is not found!");
            }
        }



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
           if(introwoning != null){ //checks to see if the presence of the GameObject is available
                MoveBox(introwoning, WayPointPositions);
           }
           if(introwoning1 != null){ //checks to see if the presence of the GameObject is available
                MoveBox1(introwoning1, WayPointPositions1);
           }
           if(introwoning2 != null){ //checks to see if the presence of the GameObject is available
                MoveBox2(introwoning2, WayPointPositions2);
           }
           if(introwoning3 != null){ //checks to see if the presence of the GameObject is available
                MoveBox3(introwoning3, WayPointPositions3);
           }
           
    }

    private void RandomBox(){

        int randomize = Random.Range(0, BoxSomething.Length); /*Making an int randomize by 
                                                                ranging 0 to the size of the 
                                                                list being 15*/
        GameObject ofSomeBox = BoxSomething[randomize].box; /*Once we have a randomized number from
                                                            the range, we will use this as an element
                                                            to get a specific parcel from the list. We're
                                                            also declaring this as a Gameobject to ge the
                                                            actual 3D asset. All of the data is coming from the BoxInfo
                                                            struct besides the zip code data.*/
        int ofSomeZipCode = BoxSomething[randomize].zipcode;/*The randomized number can also go to the randomized zip code
                                                                and obtain a randomized zip code from the BoxInfo data
                                                                handler.*/
        ofSomeBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); /*Scaling the parcel so it's fits inside 
                                                                         inside the conveyor belt.*/

        SpawnBox(ofSomeBox, ofSomeZipCode); /*Calling the SpawnBox function with a GameObject
                                ofSomeBox and am integer zip code number*/

    }

     public void SpawnBox(GameObject BoxFromOther, int ZipCodeFromOther){ /*This initially was on a seperate 
                                                        script but didn't think it was needed
                                                        because of unecessary code*/
        switch(ZipCodeFromOther){
            case 30190: //If the parcel contains the zip code 30190 then it will go here
            Debug.Log($"{BoxFromOther} having the zipcode of {ZipCodeFromOther}");
            startingPosition = new Vector3(-2.271f, 0.8699999f, 0.8577683f);
            introwoning = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                                                     BoxFromOther that was passed from tge SpawnBox function. 
                                                                                                      We then use the startingPosition coordinates that we made earlier.
                                                                                                    The last one that we made was was the Quaternion.identity to make no rotation.*/
                    Applied.rigidBodyRumcation(BoxFromOther);
            
            break;

            case 46675:
            Debug.Log($"{BoxFromOther} having the zip code of {ZipCodeFromOther}");
            startingPosition = new Vector3(-2.271f, 0.8699999f, 0.8577683f); /*Making specific coordinates where the parcels                                                                should spawn in the Gameworld. */
            introwoning1 = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                          The last one that we made was was the Quaternion.identity to make no rotation.*/ 
                    Applied.rigidBodyRumcation(BoxFromOther);


            break;
            case 11075:
            Debug.Log($"{BoxFromOther} having the zip code of {ZipCodeFromOther}");
            startingPosition = new Vector3(-2.271f, 0.8699999f, 0.8577683f); /*Making specific coordinates where the parcels                                                                should spawn in the Gameworld. */
            introwoning2 = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                          The last one that we made was was the Quaternion.identity to make no rotation.*/ 
                    Applied.rigidBodyRumcation(BoxFromOther);

            break;
            case 24701:
            Debug.Log($"{BoxFromOther} having the zip code of {ZipCodeFromOther}");
            startingPosition = new Vector3(-2.271f, 0.8699999f, 0.8577683f); /*Making specific coordinates where the parcels                                                                should spawn in the Gameworld. */
            introwoning3 = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                          The last one that we made was was the Quaternion.identity to make no rotation.*/ 

                    Applied.rigidBodyRumcation(BoxFromOther);
            break;

            }
        }

         public void MoveBox(GameObject usingBox, GameObject [] potets){ /*This is where the introwoning GameObjects and the WayPointPositions array will go to so the
                                                                           Parcels can go to the trucks with the positions that they are assigned to */

            speed = 3.5f * Time.deltaTime; //Specified the speed of the Parcel with the Time.deltaTime to be caught each frame
            rotSpeed = 10.0f * Time.deltaTime; //Specified the rotation speed of the Parcel with the Time.deltaTime to be caught each frame
            if(Vector3.Distance(usingBox.transform.position, potets[StartingWayPoint].transform.position) <= 0.001f){/*What we first do is find the distance that is between the parcel 
                                                                                                                        and the next waypoint. we would then use a relational operator 
                                                                                                                        is less than the fixed number that we gave it. This is saying that 
                                                                                                                        the number that is less than 0.001f then it would increment and
                                                                                                                        got to the next waypoint of the the potets/WaypointPositions array. */
                StartingWayPoint++; //Increments to the next part of the potets/WayPointPositions array.
         }

            if(StartingWayPoint >= WayPointPositions.Length){ /*We would use this condition to see if the WayPointPositions array length that we have in the  
                                                                is equal to the last waypoint like the waypoint is element 7 and the length of the array is the same case */
                StartingWayPoint = 0; //Used for when the parcel reaches the truck.
                Destroy(usingBox);/* Once the parcel reaches for the truck or when we start to put back the parcel into index 0, we destroy the GameObject. In technicallity, 
                does go inside the truck but it's destroyed in the inside pretending that the parcel is shipped inside of a container */
                }

                Vector3 direction = (potets[StartingWayPoint].transform.position - usingBox.transform.position).normalized;/*A little concept was needed to perform this and what this would
                                                                                                                            do is calculate the normalized direction vector from the current
                                                                                                                            position of the box to the target waypoint. In General, this indicate 
                                                                                                                            the direction and distance to the target wayPoint. Using normalized
                                                                                                                            will make the rotations consistent and control movement to be much 
                                                                                                                            easier to deal with.*/
                usingBox.transform.Translate(direction * speed, Space.World); /*Using translate function to oversee the coordinates 
                                                                                of the game world so the parcel is knowledgeable to 
                                                                                know what to do.*/

    
                 Quaternion targetRotation = Quaternion.LookRotation(direction); /*Using the Quaternion.LookRotation to make the parcel look and turn 
                                                                                    to the next waypoint of the system.*/
                 usingBox.transform.rotation = Quaternion.Slerp(usingBox.transform.rotation, targetRotation, rotSpeed); /*Using the Quaternion.Slerp will make the rotations have a 
                                                                                                                            smoother transiton from one rotation to another.*/

    
            }

             public void MoveBox1(GameObject usingBox, GameObject [] potets){ /*This is where the introwoning GameObjects and the WayPointPositions array will go to so the
                                                                           Parcels can go to the trucks with the positions that they are assigned to */

            speed = 3.5f * Time.deltaTime; //Specified the speed of the Parcel with the Time.deltaTime to be caught each frame
            rotSpeed = 10.0f * Time.deltaTime; //Specified the rotation speed of the Parcel with the Time.deltaTime to be caught each frame
            if(Vector3.Distance(usingBox.transform.position, potets[StartingWayPoint].transform.position) <= 0.001f){/*What we first do is find the distance that is between the parcel 
                                                                                                                        and the next waypoint. we would then use a relational operator 
                                                                                                                        is less than the fixed number that we gave it. This is saying that 
                                                                                                                        the number that is less than 0.001f then it would increment and
                                                                                                                        got to the next waypoint of the the potets/WaypointPositions array. */
                StartingWayPoint++; //Increments to the next part of the potets/WayPointPositions array.
         }

            if(StartingWayPoint >= WayPointPositions.Length){ /*We would use this condition to see if the WayPointPositions array length that we have in the  
                                                                is equal to the last waypoint like the waypoint is element 7 and the length of the array is the same case */
                StartingWayPoint = 0; //Used for when the parcel reaches the truck.
                Destroy(usingBox);/* Once the parcel reaches for the truck or when we start to put back the parcel into index 0, we destroy the GameObject. In technicallity, 
                does go inside the truck but it's destroyed in the inside pretending that the parcel is shipped inside of a container */
                }

                Vector3 direction = (potets[StartingWayPoint].transform.position - usingBox.transform.position).normalized;/*A little concept was needed to perform this and what this would
                                                                                                                            do is calculate the normalized direction vector from the current
                                                                                                                            position of the box to the target waypoint. In General, this indicate 
                                                                                                                            the direction and distance to the target wayPoint. Using normalized
                                                                                                                            will make the rotations consistent and control movement to be much 
                                                                                                                            easier to deal with.*/
                usingBox.transform.Translate(direction * speed, Space.World); /*Using translate function to oversee the coordinates 
                                                                                of the game world so the parcel is knowledgeable to 
                                                                                know what to do.*/

    
                 Quaternion targetRotation = Quaternion.LookRotation(direction); /*Using the Quaternion.LookRotation to make the parcel look and turn 
                                                                                    to the next waypoint of the system.*/
                 usingBox.transform.rotation = Quaternion.Slerp(usingBox.transform.rotation, targetRotation, rotSpeed); /*Using the Quaternion.Slerp will make the rotations have a 
                                                                                                                            smoother transiton from one rotation to another.*/

    
            }

             public void MoveBox2(GameObject usingBox, GameObject [] potets){ /*This is where the introwoning GameObjects and the WayPointPositions array will go to so the
                                                                           Parcels can go to the trucks with the positions that they are assigned to */

            speed = 3.5f * Time.deltaTime; //Specified the speed of the Parcel with the Time.deltaTime to be caught each frame
            rotSpeed = 10.0f * Time.deltaTime; //Specified the rotation speed of the Parcel with the Time.deltaTime to be caught each frame
            if(Vector3.Distance(usingBox.transform.position, potets[StartingWayPoint].transform.position) <= 0.001f){/*What we first do is find the distance that is between the parcel 
                                                                                                                        and the next waypoint. we would then use a relational operator 
                                                                                                                        is less than the fixed number that we gave it. This is saying that 
                                                                                                                        the number that is less than 0.001f then it would increment and
                                                                                                                        got to the next waypoint of the the potets/WaypointPositions array. */
                StartingWayPoint++; //Increments to the next part of the potets/WayPointPositions array.
         }

            if(StartingWayPoint >= WayPointPositions.Length){ /*We would use this condition to see if the WayPointPositions array length that we have in the  
                                                                is equal to the last waypoint like the waypoint is element 7 and the length of the array is the same case */
                StartingWayPoint = 0; //Used for when the parcel reaches the truck.
                Destroy(usingBox);/* Once the parcel reaches for the truck or when we start to put back the parcel into index 0, we destroy the GameObject. In technicallity, 
                does go inside the truck but it's destroyed in the inside pretending that the parcel is shipped inside of a container */
                }

                Vector3 direction = (potets[StartingWayPoint].transform.position - usingBox.transform.position).normalized;/*A little concept was needed to perform this and what this would
                                                                                                                            do is calculate the normalized direction vector from the current
                                                                                                                            position of the box to the target waypoint. In General, this indicate 
                                                                                                                            the direction and distance to the target wayPoint. Using normalized
                                                                                                                            will make the rotations consistent and control movement to be much 
                                                                                                                            easier to deal with.*/
                usingBox.transform.Translate(direction * speed, Space.World); /*Using translate function to oversee the coordinates 
                                                                                of the game world so the parcel is knowledgeable to 
                                                                                know what to do.*/

    
                 Quaternion targetRotation = Quaternion.LookRotation(direction); /*Using the Quaternion.LookRotation to make the parcel look and turn 
                                                                                    to the next waypoint of the system.*/
                 usingBox.transform.rotation = Quaternion.Slerp(usingBox.transform.rotation, targetRotation, rotSpeed); /*Using the Quaternion.Slerp will make the rotations have a 
                                                                                                                            smoother transiton from one rotation to another.*/

    
            }

             public void MoveBox3(GameObject usingBox, GameObject [] potets){ /*This is where the introwoning GameObjects and the WayPointPositions array will go to so the
                                                                           Parcels can go to the trucks with the positions that they are assigned to */

            speed = 3.5f * Time.deltaTime; //Specified the speed of the Parcel with the Time.deltaTime to be caught each frame
            rotSpeed = 10.0f * Time.deltaTime; //Specified the rotation speed of the Parcel with the Time.deltaTime to be caught each frame
            if(Vector3.Distance(usingBox.transform.position, potets[StartingWayPoint].transform.position) <= 0.001f){/*What we first do is find the distance that is between the parcel 
                                                                                                                        and the next waypoint. we would then use a relational operator 
                                                                                                                        is less than the fixed number that we gave it. This is saying that 
                                                                                                                        the number that is less than 0.001f then it would increment and
                                                                                                                        got to the next waypoint of the the potets/WaypointPositions array. */
                StartingWayPoint++; //Increments to the next part of the potets/WayPointPositions array.
         }

            if(StartingWayPoint >= WayPointPositions.Length){ /*We would use this condition to see if the WayPointPositions array length that we have in the  
                                                                is equal to the last waypoint like the waypoint is element 7 and the length of the array is the same case */
                StartingWayPoint = 0; //Used for when the parcel reaches the truck.
                Destroy(usingBox);/* Once the parcel reaches for the truck or when we start to put back the parcel into index 0, we destroy the GameObject. In technicallity, 
                does go inside the truck but it's destroyed in the inside pretending that the parcel is shipped inside of a container */
                }

                Vector3 direction = (potets[StartingWayPoint].transform.position - usingBox.transform.position).normalized;/*A little concept was needed to perform this and what this would
                                                                                                                            do is calculate the normalized direction vector from the current
                                                                                                                            position of the box to the target waypoint. In General, this indicate 
                                                                                                                            the direction and distance to the target wayPoint. Using normalized
                                                                                                                            will make the rotations consistent and control movement to be much 
                                                                                                                            easier to deal with.*/
                usingBox.transform.Translate(direction * speed, Space.World); /*Using translate function to oversee the coordinates 
                                                                                of the game world so the parcel is knowledgeable to 
                                                                                know what to do.*/

    
                 Quaternion targetRotation = Quaternion.LookRotation(direction); /*Using the Quaternion.LookRotation to make the parcel look and turn 
                                                                                    to the next waypoint of the system.*/
                 usingBox.transform.rotation = Quaternion.Slerp(usingBox.transform.rotation, targetRotation, rotSpeed); /*Using the Quaternion.Slerp will make the rotations have a 
                                                                                                                            smoother transiton from one rotation to another.*/

    
            }
}
    
    

/*The first idea of the parcel spawner was that we would have to create a seperate
script that contained the ofSomeBox GameObject it would look like

private Spawner ofSomeSpawn; <-- Calling the Spawner script

ofSomeSpawn = GetComponent<Spawner>(); <-- Finding any object type in that script

ofSomeSpawn.SpawnBox(ofSomeBox); <-- Calling a specific function in that script that we linked together.

I decided to not include in a seperate script and only use it a parcel script.


*/