using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_New : MonoBehaviour
{
    AudioSource audioSource;

    IEnumerator Next()
    {
        audioSource.Play();yield return new WaitForSecondsRealtime(0.8f);
        SceneManager.LoadScene("Past Level");
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
