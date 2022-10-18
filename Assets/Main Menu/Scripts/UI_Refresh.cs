using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Refresh : MonoBehaviour
{
    AudioSource audioSource;

    IEnumerator Next()
    {
        audioSource.Play(); yield return new WaitForSecondsRealtime(0.8f);
        Time.timeScale = 1; SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        StartCoroutine("Next");
    }
}
