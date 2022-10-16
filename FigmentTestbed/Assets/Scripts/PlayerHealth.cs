using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    float MaxHealth = 80f;
    public float Health = 80f;
    public float healthLoss = 1f;
    public Healthbar healthbar;

    public AudioClip charm;
    public AudioClip Enemy;
    public AudioClip lose;
    AudioSource audioS;

    bool play = true;

    public GameObject losepanel;

    float currtime;
    void Start()
    {

        healthbar.SetMaxHealth(Health);
        audioS = GetComponent<AudioSource>();
    }

    public void SetStageHealth(float Stagehealth)
    {
        Health = Stagehealth;
        MaxHealth = Stagehealth;
        healthbar.SetMaxHealth(Stagehealth);
    }


    private void FixedUpdate()
    {
        Health -= healthLoss * Time.fixedDeltaTime;
        healthbar.SetHealth(Health);
        //Debug.Log(Health);

        if (Health <= 0f)
        {
            losepanel.SetActive(true);
        }

        if (Health <= 0f && play)
        {
            play = false;
            audioS.PlayOneShot(lose);
        }

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Health"))
        {
            Health += 5f;
            audioS.PlayOneShot(charm);
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            healthbar.SetHealth(Health);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            if(currtime >=2)
            {
                audioS.PlayOneShot(Enemy);
                currtime = 0f;
                Health -= 10f;
                healthbar.SetHealth(Health);
            }
        }


    }
    private void Update()
    {
        currtime += Time.deltaTime;

        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton) && Health <= 0)
        {
            SceneManager.LoadScene("FigmentTestScene");
        }
    }





}
