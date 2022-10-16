using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Exit : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
