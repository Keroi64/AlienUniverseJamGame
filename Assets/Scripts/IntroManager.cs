using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public AudioSource introAudio;
    public GameObject startButton;

    void Start()
    {
        if (startButton != null)
            startButton.SetActive(false); 

        if (introAudio != null)
            StartCoroutine(ShowButtonAfterAudio());
        else
            Debug.LogError("Intro AudioSource bağlı değil!");
    }

    IEnumerator ShowButtonAfterAudio()
    {
        yield return new WaitForSeconds(introAudio.clip.length);
        if (startButton != null)
            startButton.SetActive(true);
    }

    
    public void GoToForest()
    {
        SceneManager.LoadScene("RealWorld"); 
    }
}

