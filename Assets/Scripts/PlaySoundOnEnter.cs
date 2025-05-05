using UnityEngine;

public class PlaySoundOnEnter : MonoBehaviour
{
    public AudioSource soundToPlay;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            soundToPlay.Play();
            hasPlayed = true;
        }
    }
}


