using System.Collections.Generic;
using UnityEngine;


public class Parcel : MonoBehaviour{
        List<GameObject> DifferentBoxes = new List<GameObject>();
        public GameObject boxLong;
        public GameObject boxWide;
        public GameObject boxLarge;
        public GameObject boxSmall;
        //public GameObject anotherConveyor;
        private Vector3 startingPosition;


    // Start is called before the first frame update
    void Start(){

        DifferentBoxes.Add(boxLong);
        DifferentBoxes.Add(boxWide);
        DifferentBoxes.Add(boxLarge);
        DifferentBoxes.Add(boxSmall);
    }

    // Update is called once per frame
    void Update(){

            RandomBox();
    }

    private void RandomBox(){

        int randomize = Random.Range(0, DifferentBoxes.Count);
        GameObject ofSomeBox = DifferentBoxes[randomize];
        ofSomeBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        SpawnBox(ofSomeBox);

    }

     public void SpawnBox(GameObject BoxFromOther){
        
        if(Input.GetKeyDown(KeyCode.Space)){
        startingPosition = new Vector3(-2.43f, 0.87f, Random.Range(-0.2f, 1.9f));
        Instantiate(BoxFromOther, startingPosition, Quaternion.identity);
         }
    }

  
}
