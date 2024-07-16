using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Parcel : MonoBehaviour{

    
        List<GameObject> DifferentBoxes = new List<GameObject>(); /*A list that contains
        different parcel GameObjects. This list will contain the GameObjects that will be'
        be used throughout the Conveyor*/
        
        List<int> ZipCode = new List<int>();

        public GameObject boxLong; //Connected to the box-long asset in the scene
        public GameObject boxWide; //Connected to the box-wide asset in the scene
        public GameObject boxLarge; //Connected to the box-large asset in the scene
        public GameObject boxSmall; //Connected to the box--small asset in the scene
        private Vector3 startingPosition; /*Declaring a specifc spawnPoint in the scene
                                             meaning we want all the parcels to spawn at 
                                             the loading area.*/
                                                  
        


    // Start is called before the first frame update
    private void Start(){

        DifferentBoxes.Add(boxLong); /*Once the scene starts, the parcels will immediately be 
                                        added to the DifferentBoxes list/*/
        DifferentBoxes.Add(boxWide);// <--|
        DifferentBoxes.Add(boxLarge);// <-|
        DifferentBoxes.Add(boxSmall);// <-|
        ZipCode.Add(30190);
        ZipCode.Add(46675);
        ZipCode.Add(01075);
        ZipCode.Add(24701);

    }

    // Update is called once per frame
    void Update(){

           if(Input.GetKeyDown(KeyCode.Space)){ //Pressing space makes the box spawn

            RandomBox(); //Calling the RandomBox function to generate a parcel
           }
    }

    private void RandomBox(){

        int randomize = Random.Range(0, DifferentBoxes.Count); /*Making an int randomize by 
                                                                ranging 0 to the size of the 
                                                                list being 3*/
        GameObject ofSomeBox = DifferentBoxes[randomize]; /*Once we have a randomized number from
                                                            the range, we will use this as an element
                                                            to get a specific parcel from the list. We're
                                                            also declaring this as a Gameobject to ge the
                                                            actual 3D asset.*/
        ofSomeBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); /*Scaling the parcel so it's fits inside 
                                                                         inside the conveyor belt.*/

        SpawnBox(ofSomeBox); /*Calling the SpawnBox function with a GameObject
                                ofSomeBox.*/

    }

     public void SpawnBox(GameObject BoxFromOther){ /*This initially was on a seperate 
                                                        script but didn't think it was needed
                                                        because of unecessary code*/
        startingPosition = new Vector3(-2.43f, 0.87f, Random.Range(-0.2f, 1.9f)); /*Making specific coordinates where the parcels 
                                                                                    should spawn in the Gameworld. */
        GameObject CreatingBox = Instantiate(BoxFromOther, startingPosition, Quaternion.identity); /*Creating randomized clones of parcels using the 
                                                                            BoxFromOther that was passed from tge SpawnBox function. 
                                                                            We then use the startingPosition coordinates that we made earlier.
                                                                            The last one that we made was was the Quaternion.identity to make no rotation.*/ 
            
         int randomZipIndex = Random.Range(0, ZipCode.Count);
         int ActualZipCode = ZipCode[randomZipIndex];
         
   


     }
}

/*The first idea of the parcel spawner was that we would have to create a seperate
script that contained the ofSomeBox GameObject it would look like

private Spawner ofSomeSpawn; <-- Calling the Spawner script

ofSomeSpawn = GetComponent<Spawner>(); <-- Finding any object type in that script

ofSomeSpawn.SpawnBox(ofSomeBox); <-- Calling a specific function in that script that we linked together.

I decided to not include in a seperate script and only use it a parcel script.


*/