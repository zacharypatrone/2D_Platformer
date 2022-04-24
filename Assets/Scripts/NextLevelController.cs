using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour
{

    private int sceneID;

    // AUDIO
    [SerializeField] private AudioSource levelCompleteSound;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        sceneID = SceneManager.GetActiveScene().buildIndex;
        sceneID++;
        levelCompleteSound.Play();
        SceneManager.LoadScene(sceneID);
    }
}
