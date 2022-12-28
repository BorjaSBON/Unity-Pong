using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Tabs")]
    public GameObject mainMenu;
    public GameObject play;
    public GameObject stadistics;
    public GameObject options;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Back();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Stadistics ()
    {
        stadistics.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Options()
    {
        options.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Back()
    {
        if (play.activeInHierarchy == true)
        {
            mainMenu.SetActive(true);
            play.SetActive(false);
        }
        else if (stadistics.activeInHierarchy == true)
        {
            mainMenu.SetActive(true);
            stadistics.SetActive(false);
        }
        else if (options.activeInHierarchy == true)
        {
            mainMenu.SetActive(true);
            options.SetActive(false);
        }
    }
}
