using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOver;
    public TextMeshProUGUI winLoseText;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        gameOver.SetActive(false);
    }

    public void ShowGameOver(bool isWin)
    {
        winLoseText.text = isWin ? "YOU WON!" : "YOU LOST!";
        gameOver.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Selection");
    }
}
