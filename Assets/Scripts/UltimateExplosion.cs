using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateExplosion : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public GameObject ultimateExplosion; // the explosion particle system for generation
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Generate explosion at certain point
    /// </summary>
    public void generateExplosion()
    {
        AudioSource.PlayClipAtPoint(clip1, gameObject.transform.position);
        AudioSource.PlayClipAtPoint(clip2, gameObject.transform.position);
        Instantiate(ultimateExplosion, transform.position, transform.rotation, transform);
    }
}
