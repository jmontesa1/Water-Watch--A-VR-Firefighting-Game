using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

//Created by John Montesa
public class PauseScript : MonoBehaviour
{
    public GameObject UI;
    public bool activeUI = true;

    void Start() 
    {
        DisplayUI();
    }
    // Start is called before the first frame update
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void PauseButtonPressed(InputAction.CallbackContext context) 
    {
        if (context.performed){
            DisplayUI();
        }
    }

    public void DisplayUI() 
    {
        if (activeUI)
        {
            UI.SetActive(false);
            activeUI = false;
            Time.timeScale = 1;
        }
        else if (!activeUI) {
            UI.SetActive(true);
            activeUI = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}
