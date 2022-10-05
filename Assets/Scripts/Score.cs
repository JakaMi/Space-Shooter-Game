using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{   
    public static Score instance;
    private int score = 0;
    private Text scoreText;

    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            scoreText = GameObject.Find("TextScore").GetComponent<Text>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log(score);
        scoreText.text = score.ToString();
    }
}
