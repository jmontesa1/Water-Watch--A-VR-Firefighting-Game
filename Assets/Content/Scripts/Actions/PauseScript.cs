using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
//Created by John Montesa
public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
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
}
