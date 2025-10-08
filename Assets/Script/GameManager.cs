using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerScoreL, playerScoreR;
    public TMPro.TextMeshPro textMeshPro;
    public TMP_Text textScoreL, textScoreR;
    public TMP_Text winText;
    public GameObject winCon;

    private void Start()
    {
        textScoreL.text = playerScoreL.ToString();
    }
    public void Awake()
    {
    if(Instance == null)
        {
        Instance = this;
        }
    else
        {
        Destroy(gameObject);
        }

    } 
    public void AddScore(string wallName)
    {
        if(wallName == "LeftLine")
        {
            playerScoreR = playerScoreR + 10;
            textScoreR.text = playerScoreR.ToString();
            ScoreCheck();
        }
        else
        {
            playerScoreL = playerScoreL + 10;
            textScoreL.text = playerScoreL.ToString();
            ScoreCheck();
        }
    }
    public void ScoreCheck()
    {
        if(playerScoreR == 20) 
        WinCondition("Player R Win!");
        
        else if(playerScoreL == 20) 
        WinCondition("Player L Win!");
    }
    
        private void WinCondition(string text)
        {
            winCon.SetActive(true);
            winText.text = text;
        }
    }
    


