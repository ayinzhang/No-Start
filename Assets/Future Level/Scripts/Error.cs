using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Error : MonoBehaviour
{
    public GameObject[] gameObjects;
    AudioSource audioSource;

    IEnumerator Fuck()
    {
        yield return new WaitForSecondsRealtime(3f);
        for (int i = 0; i < 70; i++) { gameObjects[i].SetActive(true); yield return new WaitForSecondsRealtime(0.15f); }
        yield return new WaitForSecondsRealtime(3f);audioSource.Play();
        yield return new WaitForSecondsRealtime(3f);SceneManager.LoadScene("End Menu");
    }

    void Start()
    {
        StartCoroutine("Fuck");audioSource = GetComponent<AudioSource>();
    }
}
