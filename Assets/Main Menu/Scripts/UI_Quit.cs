using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Quit : MonoBehaviour
{
    AudioSource audioSource;

    IEnumerator Next()
    {
        audioSource.Play(); yield return new WaitForSecondsRealtime(0.8f);
        Application.Quit();
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
