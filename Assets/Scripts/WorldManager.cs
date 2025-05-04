using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject normalWorld;
    public GameObject darkWorld;

    void Start()
    {
        normalWorld.SetActive(true);
        darkWorld.SetActive(false);
    }
    public void ShiftToDarkWorld()
    {
        normalWorld.SetActive(false);
        darkWorld.SetActive(true);
    }

}
