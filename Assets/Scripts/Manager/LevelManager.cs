using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Optional - Button & Door Setup")]
    [SerializeField] private ButtonTrigger button;
    [SerializeField] private Door door;

    [Header("Optional - End Level Setup")]
    [SerializeField] private LevelEndTrigger levelEndTrigger;
    [SerializeField] private string nextSceneName;

    private void Start()
    {
        SetupButtonAndDoor();
        SetupLevelEnd();
    }

    private void SetupButtonAndDoor()
    {
        if (button != null && door != null)
        {
            ICommand openDoorCommand = new OpenDoorCommand(door);
            button.SetCommand(openDoorCommand);
        }
    }

    private void SetupLevelEnd()
    {
        if (levelEndTrigger != null && !string.IsNullOrEmpty(nextSceneName))
        {
            ICommand winCommand = new WinLevelCommand(nextSceneName);
            levelEndTrigger.SetCommand(winCommand);
        }
    }
}
