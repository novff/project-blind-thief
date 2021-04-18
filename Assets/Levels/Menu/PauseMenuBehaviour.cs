using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseUI;
    void Pause()
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
    public void Resume()
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
    public void Restart()
        {
        }
    public void ToMenu()
        {
            SceneManager.LoadScene(0);
        }
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (IsPaused)
                        {
                            Resume();
                        }
                    else
                        {
                            Pause();
                        }
                }
        }
}