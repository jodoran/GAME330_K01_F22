using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenceload : MonoBehaviour
{

    public void laodscene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
