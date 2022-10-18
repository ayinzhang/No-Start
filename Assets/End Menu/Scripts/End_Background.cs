using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Background : MonoBehaviour
{
    RectTransform rect;
    public Typer typer;

    IEnumerator Position()
    {
        rect.localPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        yield return new WaitForSecondsRealtime(0.025f); StartCoroutine("Position");
    }

    void Start()
    {
        rect = GetComponent<RectTransform>();
        StartCoroutine("Position"); typer.StartCoroutine("StartTyperStay", "æ„Ÿè°¢æ¸¸çŽ©");
    }
}
