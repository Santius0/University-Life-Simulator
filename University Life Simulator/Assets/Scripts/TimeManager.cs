using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameFramework.GameStructure.Levels;
using GameFramework.GameStructure.Levels.ObjectModel;
using GameFramework.GameStructure.GameItems.ObjectModel;

// Singleton Design Pattern.
// Can be used to update TIme with UpdateTime.Instance.addTime()
public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;

    private TimeManager() { }

    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TimeManager();
            }
            return instance;
        }
    }

    public float dilation = 1;

    public Text timeString;
    public Text dateString;

    private Level level;
    private Counter timeCounter;
    private int startTime = 7;

    // Use this for initialization
    void Start()
    {
        // time = GetComponent<Text> ();

        level = LevelManager.Instance.Level;
        timeCounter = level.GetCounter("Time");
    }

    // Update is called once per frame
    void Update()
    {
        // print (timeCounter.GetInt());
        timeString.text = counterToTime(timeCounter.GetInt() * dilation);
        dateString.text = counterToDate(timeCounter.GetInt() * dilation);
    }

    string counterToDate(float counter)
    {
        // Note: We add (7 * 60) to account for fact that day starts at 7am
        int startTimeOffset = startTime * 60;
        counter += startTimeOffset;

        int week = (int)(counter / (7 * 24 * 60)) + 1;
        string strWeek = week.ToString();

        int day = (int)(counter / (24 * 60)) % 7;
        string strDay = "Unknown";
        switch (day)
        {
            case 0:
                strDay = "Monday";
                break;
            case 1:
                strDay = "Tuesday";
                break;
            case 2:
                strDay = "Wednesday";
                break;
            case 3:
                strDay = "Thursday";
                break;
            case 4:
                strDay = "Friday";
                break;
            case 5:
                strDay = "Saturday";
                break;
            case 6:
                strDay = "Sunday";
                break;
        }

        return "Week " + strWeek + ", " + strDay;
    }

    string counterToTime(float counter)
    {
        float time = counter % (24 * 60);

        int hours = (int)((time / (60)) + startTime) % 24;
        string strHours = hours.ToString("D2");


        int minutes = (int)(time % 60);
        string strMinutes = minutes.ToString("D2");

        return strHours + ":" + strMinutes;
    }

    public void addTime(int hours)
    {
        Counter timeCounter = GameFramework.GameStructure.Levels.LevelManager.Instance.Level.GetCounter("Time");
        timeCounter.Increase(hours * 60);

    }
}
