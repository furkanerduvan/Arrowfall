using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    public static GameoverUI Instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Show(int score)
    {
        panel.SetActive(true);
        scoreText.text = "Score: " + score;
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
