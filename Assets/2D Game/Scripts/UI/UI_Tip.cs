using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tip : MonoBehaviour
{
    Typer typer;
    public string words;

    void Start()
    {
        typer = GameObject.Find("Canvas/Text").GetComponent<Typer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        typer.StartCoroutine("StartTyper", words);
        Destroy(gameObject);
    }
}
