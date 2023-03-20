using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button ContinueButton;
    public Button EndRunButton;

    public GameObject deadMenu;
    public Button deadMenuButton;
    [SerializeField] public GameObject IsDeadTrigger;

    public GameObject victoryMenu;
    public Button victoryMenuButton;
    [SerializeField] public GameObject VictoryTrigger;

    public static bool isPaused;
    //public bool isDead;

    private static bool isDead = false;

    void Start()
    {
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);  
        victoryMenu.SetActive(false);

        //  Pause Menu
        ContinueButton.onClick.AddListener(ResumeGame);
        EndRunButton.onClick.AddListener(ToMenu);

        //  Dead Menu
        deadMenuButton.onClick.AddListener(ToMenu);

        //  Victory Menu
        victoryMenuButton.onClick.AddListener(ToMenu);
    }
    void Update()
    {
        ////  Pause Menu
        //ContinueButton.onClick.AddListener(ResumeGame);
        //EndRunButton.onClick.AddListener(ToMenu);

        ////  Dead Menu
        //deadMenuButton.onClick.AddListener(ToMenu);

        ////  Victory Menu
        //victoryMenuButton.onClick.AddListener(ToMenu);
        
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
        
        if (IsDeadTrigger.activeSelf) 
        {
            //Debug.Log("Game should pause now 2");
            deadMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        if (VictoryTrigger.activeSelf)
        {
            Debug.Log("TIMES UP TWO");
            victoryMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused= true;
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
        Debug.Log("Quiting...");
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //  crashe3d game, lol
        //  something in the interrum

        //Application.Quit();
    }
}
