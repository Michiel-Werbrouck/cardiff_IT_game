using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayCoinCollected()
    {
        source.PlayOneShot(audioClips[0]);
    }
    public void PlayVictorySound()
    {
        source.PlayOneShot(audioClips[1]);
    }

    public void PlayDeathSound()
    {
        source.PlayOneShot(audioClips[2]);
    }

   
}
