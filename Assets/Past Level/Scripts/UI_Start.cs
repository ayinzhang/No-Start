﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{
    public Typer typer;
    public Transform[] trans;
    public int current;
    AudioSource audioSource;

    IEnumerator Next()
    {
        typer.StartCoroutine("StartTyper", "好吧好吧，我知道了");yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("2D Game"); Save.leavedwords = "既然你如此锲而不舍，那这正好有个游戏";
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        typer.StartCoroutine("StartTyper", "欢迎，其实这个游戏还未完成，所以不用继续了，直接退出吧");
    }

    public void OnClick()
    {
        audioSource.Play(); transform.position = trans[(++current) % 5].position;
        if (current == 1) typer.StartCoroutine("StartTyper", "额，直接退出啊，莫非你还真的想玩这个");
        else if(current==3) typer.StartCoroutine("StartTyper", "这...让我考虑下先");
        else if (current == 5) StartCoroutine("Next");
    }    
}
