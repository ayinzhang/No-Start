using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public float interval = 0.15f;
    public string words;
    Text character;
    AudioSource audioSource;

    IEnumerator StartTyper()
    {
        audioSource.Play();
        for (int i = 0; i <= words.Length; i++) { character.text = words.Substring(0, i);yield return new WaitForSecondsRealtime(interval); }
        audioSource.Stop();
    }

    void Start()
    {
        character = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("StartTyper");
    }
}
