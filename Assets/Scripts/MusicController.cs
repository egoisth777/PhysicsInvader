using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // Ensure the audio is set to loop
        audioSource.Play(); // Start playing the audio
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
