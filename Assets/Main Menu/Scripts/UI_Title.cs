using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Title : MonoBehaviour
{
    IEnumerator Scale()
    {
        float x = Random.Range(0.8f, 1.2f), y = Random.Range(0.8f, 1.2f);
        float dx = x - transform.localScale.x, dy = y - transform.localScale.y;
        for (int i = 0; i < 50; i++)
        {
            transform.localScale += new Vector3(dx/50, dy/50, 0); yield return new WaitForSecondsRealtime(0.02f);
        }
        StartCoroutine("Scale");
    }

    IEnumerator Rotate()
    {
        for (int i = 0; i < 100; i++) { transform.Rotate(0, 0, 0.2f); yield return new WaitForSecondsRealtime(0.02f); }
        for (int i = 0; i < 200; i++) { transform.Rotate(0, 0, -0.2f); yield return new WaitForSecondsRealtime(0.02f); }
        for (int i = 0; i < 100; i++) { transform.Rotate(0, 0, 0.2f); yield return new WaitForSecondsRealtime(0.02f); }
        StartCoroutine("Rotate");
    }

    void GameStart()
    {
        GetComponent<AudioSource>().Play();
    }

    void Start()
    {
        StartCoroutine("Scale"); StartCoroutine("Rotate");
        UI_Announcement.A += GameStart;
    }
}
