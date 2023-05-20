using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class text : MonoBehaviour
{
    string fullpth = "Assets/text/test";
    //string fullpth = Application.streamingAssetsPath;
    StreamWriter sw;
    // Start is called before the first frame update

    private void create()
    {
        if (false == File.Exists(fullpth))
        {
            sw = new StreamWriter(fullpth + ".txt");
            sw.WriteLine("쓰고 싶은 내용");

            // 예시
            // sw.WriteLine(qq + " " + n + " " + listener.transform.position.x + " " + listener.transform.position.y + " " + listener.transform.position.z + " " + loudness);

            sw.Flush();
            sw.Close();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            create();
            Debug.Log("저장");

        }
    }
}
