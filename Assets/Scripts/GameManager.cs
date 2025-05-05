using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float killCount;
    public Text killCountText;

    public GameObject pauseMenuUI;
    public GameObject winLevelUI;

    private bool gameIsPaused = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused==true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void WinLevel()
    {
        winLevelUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        AudioListener.pause = true;

    }

    public void AppQuit()
    {
        Application.Quit();

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("EntryScene");
        Time.timeScale = 1;
        AudioListener.pause = false;

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void AddKill()
    {
        killCount++;
        killCountText.text = "Uzaylı Öldürüldü: " + killCount;
    }
}
