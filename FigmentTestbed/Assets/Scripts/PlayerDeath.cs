using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject endgameCanvas;
    public GameObject gameCanvas;
    public AudioSource backgroundMusic;
    public AudioSource endgameSound;
    private bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("DEATH");
            gameOver = true;
            gameCanvas.SetActive(false);
            endgameCanvas.SetActive(true);
            backgroundMusic.Stop();
            endgameSound.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        endgameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("space") && gameOver == true)
        {
            SceneManager.LoadScene("FigmentTestScene");
        }
    }
}
