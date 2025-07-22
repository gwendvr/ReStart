using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    private ICommand command;

    public void SetCommand(ICommand newCommand)
    {
        command = newCommand;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bouton touché !");
            command?.Execute();
        }
    }
}
