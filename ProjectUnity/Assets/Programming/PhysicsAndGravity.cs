using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.UIElements;

public class PhysicsAndGravity : MonoBehaviour{

    private Dictionary<string, System.Action<GameObject>> actions;

    void Start(){

            actions = new Dictionary<string, System.Action<GameObject>> {

                        {"Barrel", BarrelPhysics},
                        {"Box_1", Box_1Physics},
                        {"Box_2", Box_2Physics},
                        {"box-large", Box_large}

            };

    }
    public void rigidBodyRumcation(GameObject AppliedBoxPhysics){
          if (AppliedBoxPhysics != null) {
            string objectName = AppliedBoxPhysics.name;
            Debug.Log($"Checking GameObject: {objectName}");

            if (actions.TryGetValue(objectName, out var action)) {
                action.Invoke(AppliedBoxPhysics); // Example calling BarrelPhysics(AppliedBoxPhysics) if the name is "Barrel
            } else {
                Debug.LogWarning("No action defined for " + objectName);
            }
        } else {
            Debug.LogError("AppliedBoxPhysics is null");
        }
            
    }

    public void BarrelPhysics(GameObject Barrel){
           ApplyRBandMC(Barrel);
           
    }

    public void Box_1Physics(GameObject Box_1){
           ApplyRBandMC(Box_1);
    }

    public void Box_2Physics(GameObject Box_2){
          ApplyRBandMC(Box_2);
    }
    
    public void Box_large(GameObject Box_large){
          ApplyRBandMC(Box_large);
    }

    public void ApplyRBandMC(GameObject Parcel){

       Rigidbody Included = Parcel.GetComponent<Rigidbody>();
       MeshCollider Oncluded = Parcel.GetComponent<MeshCollider>();

        switch(Parcel.name){

            case "Barrel": 

                if(Included && Oncluded != null){
                    Included.useGravity = true;
                    Oncluded.convex = true;
                }

            break;

            case "Box_1": 

                if(Included != null){
                    Included.useGravity = true;
                }

            break;

            case "Box_2": 

                if(Included != null){
                    Included.useGravity = true;
                }

            break;

            case "box-large": 

                if(Included != null){
                    Included.useGravity = true;
                }

            break;
        }
    }
}
    
    

        


        
    


