public class WinLevelCommand : ICommand
{
    private string nextSceneName;

    public WinLevelCommand(string sceneToLoad)
    {
        nextSceneName = sceneToLoad;
    }

    public void Execute()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}