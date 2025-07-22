using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] private ButtonTrigger button;
    [SerializeField] private Door door;

    private void Start()
    {
        ICommand openDoorCommand = new OpenDoorCommand(door);
        button.SetCommand(openDoorCommand);
    }
}
