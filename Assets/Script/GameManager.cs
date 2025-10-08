using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 
using System.Collections;          

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Scores")]
    public int playerScoreL;
    public int playerScoreR;

    [Header("UI References")]
    public TMP_Text textScoreL;
    public TMP_Text textScoreR;
    public TMP_Text winText;
    public GameObject winCon; 

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        textScoreL.text = playerScoreL.ToString();
        textScoreR.text = playerScoreR.ToString();

        if (winCon != null)
            winCon.SetActive(false);
    }

    public void AddScore(string wallName)
    {
        
        if (wallName == "LeftLine")
        {
            playerScoreR += 10;
            textScoreR.text = playerScoreR.ToString();
            ScoreCheck();
        }
        else if (wallName == "RightLine")
        {
            playerScoreL += 10;
            textScoreL.text = playerScoreL.ToString();
            ScoreCheck();
        }
    }

    private void ScoreCheck()
    {
    
        if (playerScoreR >= 50)
        {
            WinCondition("Player R Wins!");
        }
    
        else if (playerScoreL >= 50)
        {
            WinCondition("Player L Wins!");
        }
    }

    private void WinCondition(string text)
    {
        
        if (winCon != null)
            winCon.SetActive(true);

        if (winText != null)
            winText.text = text;

        
        StartCoroutine(ReturnToMainMenuCoroutine());
    }

    private IEnumerator ReturnToMainMenuCoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);

        
        SceneManager.LoadScene("MainMenu");
    }
}
