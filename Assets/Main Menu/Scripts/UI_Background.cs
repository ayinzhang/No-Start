using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Background : MonoBehaviour
{
    RectTransform rect;

    IEnumerator Position()
    {
        rect.localPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        yield return new WaitForSecondsRealtime(0.025f); StartCoroutine("Position");
    }

    void Start()
    {
        UI_Announcement.A += GameStart;
        rect = GetComponent<RectTransform>();
    }

    void GameStart()
    {
        StartCoroutine("Position");
    }
}
