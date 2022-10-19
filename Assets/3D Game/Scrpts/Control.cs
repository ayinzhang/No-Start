using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public Typer typer;

    void Guide()
    {
        if (Save.transmitTime == 1) typer.StartCoroutine("StartTyper", "刚刚一闪而过的是？幻觉吧");
        else if (Save.transmitTime == 2) typer.StartCoroutine("StartTyper", "好吧，也可能是BUG，毕竟还未完成");
        else if (Save.transmitTime == 3) typer.StartCoroutine("StartTyper", "我说，这个楼梯到底有尽头吗？");
        else if (Save.transmitTime == 5) typer.StartCoroutine("StartTyper", "刚刚谷歌了下，这个好像叫潘洛斯阶梯");
        else if (Save.transmitTime == 7) typer.StartCoroutine("StartTyper", "要不...我们还是放弃吧");
        else if (7 < Save.transmitTime && Save.transmitTime < 14) typer.StartCoroutine("StartTyper", new string('.', Save.transmitTime - 7));
        else if (Save.transmitTime == 14) typer.StartCoroutine("StartTyper", "要不...你还是放弃吧");
        else if (Save.transmitTime == 15) typer.StartCoroutine("StartTyper", "总之，我可不管你了");
        else if (Save.transmitTime == 35) SceneManager.LoadScene("Future Level");
    }

    void Start()
    {
        typer.StartCoroutine("StartTyper", "据我所知这可没有什么房子，尽你所能探索吧");
    }

    void FixedUpdate()
    {
        //print(Save.transmitTime);
        if (transform.position.y < 0) { Save.transmitTime++; transform.position += new Vector3(0, 15.4f, 0); Guide();  }
        else if (transform.position.y > 30) { Save.transmitTime++; transform.position -= new Vector3(0, 15.4f, 0); Guide();  }
    }
}
