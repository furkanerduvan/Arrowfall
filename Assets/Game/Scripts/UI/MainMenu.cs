using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        ScoreManager.Instance.ResetScore();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }
}
