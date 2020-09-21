using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    struct Score
    {
        public string name;
        public float time;
    }

    public static string currentName = "High Roller";
    static List<Score> scores = new List<Score>();
    const int SCORELIMIT = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float currentTime)
    {
        Score currentScore = new Score { name = currentName, time = currentTime };

        if (scores.Count == 0)
            scores.Add(currentScore);
        else
        {
            bool inserted = false;
            for (int i = 0; i < scores.Count; i++)
            {
                if (currentScore.time < scores[i].time)
                {
                    scores.Insert(i, currentScore);
                    inserted = true;
                    break;
                }
            }

            if (!inserted)
                scores.Add(currentScore);

            if (scores.Count > SCORELIMIT)
                scores.RemoveAt(SCORELIMIT);
        }
    }

    public string DisplayScores()
    {
        string board = "  <pos=8%>Name <pos=75%>Time \n";

        for (int i = 0; i < scores.Count; i++)
        {
            board += (i+1).ToString() + ". <pos=8%>" + scores[i].name + " <pos=75%>" + scores[i].time.ToString("0.00") + "\n";
        }

        return board;
    }
}
