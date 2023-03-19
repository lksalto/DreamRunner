using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public List<AudioClip> jumpSound;
    public List<AudioClip> deathSound;
    public List<AudioClip> dreamSound;
    public List<AudioClip> clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        // Play the jump sound
        audioSource.PlayOneShot(jumpSound[Random.Range(0, jumpSound.Count - 1)]);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound[Random.Range(0, deathSound.Count - 1)]);
    }
    public void PlayDreamSound()
    {
        audioSource.PlayOneShot(dreamSound[Random.Range(0, dreamSound.Count - 1)]);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound[Random.Range(0, clickSound.Count - 1)]);
    }

}

