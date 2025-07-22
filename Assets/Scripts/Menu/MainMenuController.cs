using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectPanel;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void TogglePanel(bool showLevelSelect)
    {
        mainMenuPanel.SetActive(!showLevelSelect);
        levelSelectPanel.SetActive(showLevelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
