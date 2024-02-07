using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateExplosion : MonoBehaviour
{
    public GameObject ultimateExplosion; // the explosion particle system for generation
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateExplosion()
    {
        Instantiate(ultimateExplosion);
    }

}
