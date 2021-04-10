using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public void NewGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    public void QuitGame()
        {
            Application.Quit();
        }
    public void GitHubLink()
        {
            Application.OpenURL("https://github.com/novff/project-blind-thief");
        }
}
