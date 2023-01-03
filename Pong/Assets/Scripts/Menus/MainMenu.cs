using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Tabs")]
    public GameObject mainMenu;
    public GameObject play;
    public GameObject stadistics;
    public GameObject options;

    [Header("Play")]
    public TextMeshProUGUI map;
    public TextMeshProUGUI level;

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
        mainMenu.SetActive(false);
        play.SetActive(true);
    }

    public void PlayGame()
    {
        MapSelection.mapType = map.text;

        if (level.text == "Easy")
        {
            MapSelection.levelIA = 0;
        } else if (level.text == "Normal")
        {
            MapSelection.levelIA = 1;
        } else if (level.text == "Hard")
        {
            MapSelection.levelIA = 2;
        } else
        {
            MapSelection.levelIA = -1;
        }

        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Stadistics()
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
