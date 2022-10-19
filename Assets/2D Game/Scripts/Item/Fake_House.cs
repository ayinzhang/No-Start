using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fake_House : MonoBehaviour
{
    bool isDoor = false;

    void Update()
    {
        if (isDoor && Player.move.y > 0) 
        { 
            SceneManager.LoadScene("2D Game");Save.returnTime++;
            if (Save.returnTime == 1) Save.leavedwords = "怎么绘世";
            else if (Save.returnTime == 2) Save.leavedwords = "这好像是个循环";
            else Save.leavedwords = "我们不会就这样被困这了吧";
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") isDoor = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") isDoor = false;
    }
}
