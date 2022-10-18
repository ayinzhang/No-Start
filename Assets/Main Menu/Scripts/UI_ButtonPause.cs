using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonPause : MonoBehaviour
{
    public Sprite play;
    public Sprite pause;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        audioSource.Play();
        if (gameObject.GetComponent<Image>().sprite == play)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<Image>().sprite = pause;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
            gameObject.GetComponent<Image>().sprite = play; 
        }
    }
}
