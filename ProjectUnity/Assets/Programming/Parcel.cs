using UnityVector3 = UnityEngine.Vector3;
using UnityEngine;
using NumericsVector3 = System.Numerics.Vector3;
using UnityEngine.UIElements;

namespace parcal {

public sealed class Parcel : MonoBehaviour{


    public GameObject LargeBoxor; 

    public GameObject ConveyerLong; /* where the LargeBox would go to and labels
                                the truck as a GameObject to be accessible inside 
                                the world. */
    [SerializeField] float speed = 5f; /* The speed of how fast the box is going.
                                            Once the box touches the conveyer via trigger
                                            then it will start moving torwards its destination. Making this a 
                                            SerializeField so we don't tinker the movement while accessing other
                                            scripts and making it visible to the inspector. Makes it public to the
                                            naked eye (*)v(*) but prevents further changes*/

    public Rigidbody LargeBoxConnecter; /*Connecting LargeBoxConnector to the GetComponent<RigidBody>*/

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame  

    void Update() {

    }

    void OnCollisionEnter(Collision other) {

    }



    void OnTriggerEnter(Collider LargeBox) {

        LargeBoxConnecter = LargeBox.GetComponent<Rigidbody>();

                    
                if(LargeBox.CompareTag("box-large") && LargeBoxConnecter != null){ 
                    LargeBoxor.transform.position = Vector3.MoveTowards(LargeBoxor.transform.position, 
                                                                        ConveyerLong.transform.position, 
                                                                        speed * Time.deltaTime); 
                }

        
    }
    
    
}
}
 
