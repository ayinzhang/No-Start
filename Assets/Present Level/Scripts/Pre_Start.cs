using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pre_Start : MonoBehaviour
{
    public Typer typer;
    public int cnt;

    IEnumerator Next()
    {
        typer.StartCoroutine("StartTyper", "好吧好吧，其实真还有一个，稍等..."); yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("3D Game");
    }

    void Start()
    {
        typer.StartCoroutine("StartTyper", "感觉如何？现在我们又回到了这");
    }

    public void OnClick()
    {
        cnt++;
        if (cnt == 1) typer.StartCoroutine("StartTyper", "等会...你该不会还想玩吧");
        else if (cnt == 3) StartCoroutine("Next");
    }
}
