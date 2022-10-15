using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_New : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Past Level");
    }
}
