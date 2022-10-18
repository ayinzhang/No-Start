using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Pre_Start : MonoBehaviour
{
    public Typer typer;
    public GameObject photo;
    public Transform pos;
    public VideoPlayer movie;
    public AudioClip play;
    public AudioClip click;
    int cnt;
    Vector3 nor;
    AudioSource audioSource;

    IEnumerator RunAway()
    {
        typer.StartCoroutine("StartTyper", "其实...准确说来是跑路了"); yield return new WaitForSecondsRealtime(2.5f);
        photo.SetActive(true);
        for (float i = 2; i >= 1; i -= 0.02f) { photo.transform.localScale = new Vector3(i, i, i); yield return new WaitForSecondsRealtime(0.02f); }
        for(int i=0;i<100;i++) { photo.transform.position += nor/100; yield return new WaitForSecondsRealtime(0.02f); }
    }

    IEnumerator Play()
    {
        typer.StartCoroutine("StartTyper", "没完没了了是吧? "); yield return new WaitForSecondsRealtime(2.5f);
        audioSource.clip = play; audioSource.Play(); yield return new WaitForSecondsRealtime(4f); audioSource.clip = click;
    }

    IEnumerator Study()
    {
        movie.Play(); yield return new WaitForSecondsRealtime(16f);Destroy(movie);
    }

    IEnumerator Next()
    {
        typer.StartCoroutine("StartTyper", "算了算了，那就把他未完成的场景搬上来吧"); yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("3D Game");
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); nor = pos.position - photo.transform.position;
        typer.StartCoroutine("StartTyper", "恭喜，打破了无限的回环");
    }

    public void OnClick()
    {
        cnt++; audioSource.Play();
        if (cnt == 1) typer.StartCoroutine("StartTyper", "你...不会还想");
        else if (cnt == 2) typer.StartCoroutine("StartTyper", "没了，制作者根本就没怎么做");
        else if (cnt == 3) StartCoroutine("RunAway");
        else if (cnt == 5) StartCoroutine("Play");
        else if (cnt == 10) movie.Play();//StartCoroutine("Study");
        else if (cnt == 20) StartCoroutine("Next");
    }
}
