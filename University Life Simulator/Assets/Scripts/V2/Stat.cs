using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

    private Image stat_bar;
    private float curr_fill;
    [SerializeField]
    private float lerp_speed;
    [SerializeField]
    private Text stat_value;
    private string stat_name;
    public float max_value { get; set; }

    private float curr_value;
    private Color32 color;
    public float current_value
    {
        get
        {
            return curr_value;
        }

        set
        {
            if (value > max_value)
                curr_value = max_value;
            else if(value < 0)
                curr_value = 0;
            else
                curr_value = value;
            if (stat_name == "coins")
            {
                stat_value.text = "$" + (current_value / 100).ToString("F");
                if (curr_value > 1000)
                    color = new Color32(197, 128, 54, 255);
                //else
                //    color = new Color32(0, 0, 0, 0);
                curr_fill = 100;
            }
            else
            {
                curr_fill = current_value / max_value;
                stat_value.text = current_value + "/" + max_value;
            }
        }

    }

    // Use this for initialization
    void Start () {
        stat_bar = GetComponent<Image>();
        color = new Color32(255, 255, 255, 255);
	}

    public void Initialize(float curr, float max, string name)
    {
        stat_name = name;
        max_value = max;
        current_value = curr;
    }
    // Update is called once per frame
    void Update () {
        if (Time.timeScale > 0)
        {
            if(stat_name == "coins")
                stat_bar.color = color;
            if (curr_fill != stat_bar.fillAmount)
                stat_bar.fillAmount = Mathf.Lerp(stat_bar.fillAmount, curr_fill, Time.deltaTime * lerp_speed);
        }
	}
}
