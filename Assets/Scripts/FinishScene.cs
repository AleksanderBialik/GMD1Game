
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    private void Start()
    {
        timerText.text = PlayerPrefs.GetString("finish");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("LEVEL1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
