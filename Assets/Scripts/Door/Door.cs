using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    public bool IsOpen => isOpen;

    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            gameObject.SetActive(false);
        }
    }
}
