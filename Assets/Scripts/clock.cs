using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    const float hoursToDegrees = 30f, minutesToDegrees= 6f,secondsToDegrees= 6f;
    TimeSpan time;

    [SerializeField]
    bool analog = true;
    [SerializeField]
    TMP_Text digitalDisplay;
    // Start is called before the first frame update
    void Start()
    {
        time = DateTime.Now.TimeOfDay;
    }
    void UpdateArm(Transform arm,float rotation){
        arm.localRotation = Quaternion.Euler(0,0,rotation);
    }
    // Update is called once per frame
    void Update()
    {
        time = DateTime.Now.TimeOfDay;
        digitalDisplay.text = DateTime.Now.Hour+":"+DateTime.Now.Minute;
        UpdateArm(hoursPivot,hoursToDegrees * (float) (analog?time.TotalHours:Math.Floor(time.TotalHours)));
        UpdateArm(minutesPivot,minutesToDegrees * (float) (analog?time.TotalMinutes:Math.Floor(time.TotalMinutes)));
        UpdateArm(secondsPivot,secondsToDegrees * (float) (analog?time.TotalSeconds:Math.Floor(time.TotalSeconds)));
    }
}
