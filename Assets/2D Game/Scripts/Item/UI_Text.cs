using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Text : MonoBehaviour
{
    string s;

    void Update()
    {
        if (Player.lv <= 3) s = "Master";
        else if (Player.lv <= 8) s = "Expert";
        else if (Player.lv <= 16) s = "Newbie";
        else s = "Fool | Cheater ?";
        GetComponent<Text>().text = "LV:" + Player.lv.ToString() + " - " + s;
    }
}
