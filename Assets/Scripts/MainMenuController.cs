using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private string gameSceneName = "06_Interaction";

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenExitConfirm()
    {
        confirmPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void CloseExitConfirm()
    {
        confirmPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Выход из игры");
        #if  UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif  
    }
}
