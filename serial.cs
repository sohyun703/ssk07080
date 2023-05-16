using UnityEngine;
using System.IO.Ports;

public class serial : MonoBehaviour
{
    SerialPort m_SerialPort = new SerialPort("COM3", 8800, Parity.None, 8, StopBits.One);
    // Start is called before the first frame update
    void Start()
    {
        m_SerialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SerialPortWrite("LOW"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.
            print(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SerialPortWrite("HIGH"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.
            print(2);
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("end")){
            SerialPortWrite("HIGH"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.
            Invoke("sendLow", 2f);
            print(2);
        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("end")){
            SerialPortWrite("LOW"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.
            print(1);
        }
    }

    void SerialPortWrite(string message)
    {
        m_SerialPort.Write(message);
    }
    void sendLow()
    {
        SerialPortWrite("LOW");
    }
}
