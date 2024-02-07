using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents the ultimate bomb navigator class.
/// </summary>
public class UltBN : MonoBehaviour
{   
    // pass the global controller parameter to the button
    public GlobalController globalController; // set to be the globalController at the beginning
    public InvaderRowController InvaderRowController; // get the invader row controller
    private Button thisButton;
    public  Material DeadMaterial;
    public UltimateExplosion explosionController;
    public bool ButtonEnabledAtBeginning;
    public float forceMagnitude = 10.0f;
    private void Awake()
    {
        thisButton = GetComponent<Button>(); // get the reference to the button
        thisButton.onClick.AddListener(ButtonClicked); // add an event listener to the button
    }

    void Start()
    {   
        thisButton = GetComponent<Button>();
        thisButton.interactable = ButtonEnabledAtBeginning;
    }

    void Update()
    {
        if (globalController.EnemyTakenDown % 8 == 0
        &&  globalController.EnemyTakenDown != 0)
        {
            thisButton.interactable = true;
        }
    }

    private void ButtonClicked() 
    {
        // instantiate the ultimate explosion
        explosionController.generateExplosion();
        
        globalController.OnGameWin();
        foreach (var linked_list in InvaderRowController.invadersLinkedLists)
        {
            foreach (var invader in linked_list)
            {
                if (invader.IsDestroyed())
                {
                    continue;
                }
                // Set the invader's gravity to be on
                
                Rigidbody invaderRigid = invader.GetComponent<Rigidbody>();
                MeshRenderer invaderRender = invader.GetComponent<MeshRenderer>();
                invaderRigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                Vector3 forceDirection = new Vector3(0, 0, -1);
                invaderRigid.AddForce(forceDirection.normalized * forceMagnitude);

                // set the rigid body use gravity to be true
                invaderRigid.useGravity = true;
                
                invaderRigid.velocity = Vector3.zero;
            }
        }
    }
}