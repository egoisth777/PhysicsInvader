using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UltBN : MonoBehaviour
{   
    // pass the global controller parameter to the button
    public GlobalController globalController; // set to be the globalController at the beginning
    public InvaderRowController InvaderRowController; // get the invader row controller
    private Button thisButton;
    public GameObject UltimateExplosion;
    public  Material DeadMaterial;
    public UltimateExplosion explosionController;

    private void Awake()
    {
        thisButton = GetComponent<Button>(); // get the reference to the button
        thisButton.onClick.AddListener(ButtonClicked); // add an event listener to the button
    }

    void Start()
    {   
        thisButton = GetComponent<Button>();
        thisButton.interactable = false;
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
                invaderRigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ |
                                           RigidbodyConstraints.FreezeRotationY;
                invaderRender.sharedMaterial = DeadMaterial;
                invaderRigid.useGravity = true;
                invaderRigid.velocity = Vector3.zero;
            }
        }
    }
}