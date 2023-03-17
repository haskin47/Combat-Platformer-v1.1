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
    public Button mainMenuButton;

    public GameObject victoryMenu;


    public static bool isPaused;
    //public bool isDead;

    private static bool isDead = false;
    [SerializeField] private Animator animator;

    void Start()
    {
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);  
        victoryMenu.SetActive(false);

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
