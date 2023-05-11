using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class firebase : MonoBehaviour
{
    DatabaseReference m_Reference;
    private bool m_IsBreak; //무한반복 방지용
    string angle;
   public  GameObject test;
    float ft;
    Vector3 TEST;
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        //WriteUserData("0", "aaaa");
        //WriteUserData("1", "bbbb");
        //WriteUserData("2", "cccc");
        //WriteUserData("3", "dddd");

        //ReadUserData();
        m_IsBreak = true;
        StartCoroutine("ReadData");

    }

    private void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_IsBreak = false;
            Debug.Log(12);
        }
            // 무한반복문 종료
      
    }

    void ReadUserData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("angle")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
              
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                  //  Debug.Log("연결됨");
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    Debug.Log(snapshot.Value);
                    

                }
            });
    }

    void WriteUserData(string userId, string username)
    {
        m_Reference.Child("users").Child(userId).Child("username").SetValueAsync(username);
    }

    IEnumerator ReadData()
    {
        while (m_IsBreak)
        {
            
            yield return new WaitForSeconds(0.2f);
            FirebaseDatabase.DefaultInstance.GetReference("angle")
           .GetValueAsync().ContinueWithOnMainThread(task =>
           {

               if (task.IsFaulted)
               {
                    // Handle the error...
                }
               else if (task.IsCompleted)
               {
                    //  Debug.Log("연결됨");
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    Debug.Log(snapshot.Value.ToString());
                   angle = snapshot.Value.ToString();
                   ft= float.Parse(angle);
                   test.transform.rotation = Quaternion.Euler(ft, 0.0f, 0.0f);
                   //test.transform.Rotate(new Vector3(ft, 0.0f, 0.0f) * 0.3f);
                   //test.transform.Rotate(new Vector3(f, 0.0f, 0.0f));

                   // TEST = (float.Parse(angle),0.0f,0.0f);
                   // test.transform.Rotate(new Vector3(float.Parse(angle), 0f, 0f) * Time.deltaTime);
               }
           });
        }
    }//
}
