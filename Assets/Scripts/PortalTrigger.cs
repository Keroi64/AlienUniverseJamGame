using System.Collections;
using UnityEngine;
public class PortalTrigger : MonoBehaviour
{
    public WorldManager WorldManager;
    public GameObject portalObject;
    public AudioSource portalAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            portalAudio.Play();
            WorldManager.ShiftToDarkWorld();
            
        }
    }
}
