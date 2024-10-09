using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerSc : MonoBehaviour
{
    [SerializeField] private float playerHealth = 10f;
    float damageTaken = 0;
    public healthSystemUI UIsystem;
    //Score
    public TextMeshProUGUI scoreText;
    int kills = 0;

    //DeadScene
    public GameObject pannel;

    public void PlayerHit(float giveDamage)
    {
        if (damageTaken < playerHealth)
        {
            damageTaken += giveDamage;
            UIsystem.removeHealth((playerHealth - damageTaken) / playerHealth);
        }
        else
        {
            pannel.SetActive(true);
            Debug.Log("Player Dead");
            Time.timeScale = 0f;
        }

        Debug.Log("Player Hit");
    }

    public void AddKills()
    {
        kills++;
        scoreText.text = "Kills : " + kills;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
