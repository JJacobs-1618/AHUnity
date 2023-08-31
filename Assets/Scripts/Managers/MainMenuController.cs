using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public void OnNewGame()
    {
        // Load Investigator Selection Screen
        // Give Control back to Player
        // TODO: This is just for testing purposes ONLY. Needs to be removed and set up on Start Game button offered in the others.
        OnStartGame();
    }

    public void OnContinue()
    {

    }

    public void OnLoadGame()
    {

    }

    public void OnStartGame()
    {
        // Show Choose Investigator Screen
        // TODO : Testing. Set up new SO to test.

        ScriptableObject.CreateInstance<NewGameDataSO>();
        SceneManager.LoadScene(1);
    }

    public void OnOptions()
    {

    }

    public void OnQuitGame()
    {

    }

    
}
