using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    float time;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f; //in seconds

    DayOfWeek dayOfWeek = DayOfWeek.Monday;

    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text dayOfWeekText;
    //[SerializeField] Light2D globalLight;
    private int days;

    float Hours
    {
        get
        {
            return time / 3600f;
        }
    }

    float Minutes
    {
        get
        {
            return time % 3600f / 60f;
        }
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        timeText.SetText(hh.ToString("00") + ":" + mm.ToString("00"));
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        //globalLight.color = c;
        if (time > secondsInDay)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;

        int dayNum = (int)dayOfWeek;
        dayNum += 1;
        if (dayNum >= 7)
        {
            dayNum = 0;
        }
        dayOfWeek = (DayOfWeek)dayNum;

        dayOfWeekText.SetText(dayOfWeek.ToString());
    }
}
