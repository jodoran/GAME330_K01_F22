using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public string newScene;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newScene);
    }
}
