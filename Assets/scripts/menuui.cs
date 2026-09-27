using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuui : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
