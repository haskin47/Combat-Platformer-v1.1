using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public Button ContinueButton;
    public Button EndRunButton;

    public static bool isPaused;

    void Start()
    {
        
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        ContinueButton.onClick.AddListener(ResumeGame);
        EndRunButton.onClick.AddListener(ToMenu);

        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void ToMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //  crashe3d game, lol
        //  something in the interrum

        Debug.Log("Quit");
        Application.Quit();
    }
}
