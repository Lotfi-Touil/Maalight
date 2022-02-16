using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;

    public GameObject turnOffLight;
    // Start is called before the first frame update
    void Start()
    {
        
    } 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }

        instance = this;
    }
    
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
        turnOffLight.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    
    
    public void RetryButton()
    {
        //Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
