using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private ICommand winCommand;

    public void SetCommand(ICommand command)
    {
        winCommand = command;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winCommand?.Execute();
        }
    }
}
