using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour
{

    public GameObject menuUI;
    public GameObject settingsMenuUI;
    
    private bool isPaused;
    private bool isInSettings;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        isInSettings = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            menuUI.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }else if (!isInSettings && Input.GetKeyDown(KeyCode.Escape))
        {
            resume();
        }
    }


    public void resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void settingsWindow()
    {
        settingsMenuUI.SetActive(true);
        isInSettings = true;
    }
    public void closeSettingsWindow()
    {
        settingsMenuUI.SetActive(false);
        isInSettings = false;
    }

}
