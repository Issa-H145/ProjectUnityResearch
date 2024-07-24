using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;

public class PhysicsAndGravity : MonoBehaviour{

    private Dictionary<string, System.Action<GameObject>> actions;

    Rigidbody included;

    void Start(){

            actions = new Dictionary<string, System.Action<GameObject>> {

                        {"Barrel", BarrelPhysics},
                        {"Box_1", Box_1Physics},
                        {"Box_2", Box_2Physics},
                        {"Box-large", Box_large}

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
        included = Barrel.GetComponent<Rigidbody>();

    }

    public void Box_1Physics(GameObject Box_1){
        included = Box_1.GetComponent<Rigidbody>();
    }

    public void Box_2Physics(GameObject Box_2){

    }
    
    public void Box_large(GameObject Box_large){

    }
    
    
    }
        


        
    


