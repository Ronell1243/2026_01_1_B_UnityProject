using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CubeGameUI : MonoBehaviour
{
    public TextMeshProUGUI TimerText;                             //UI 선언
    public float Timer;                                          //타이머 선언

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = "생존 시간 : " + Timer.ToString("0.00");
    }
}
