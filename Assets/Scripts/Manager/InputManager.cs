using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputSystem_Actions Controls { get; private set; }

    private void Awake()
    {
        if (Controls == null)
        {
            Debug.Log("InputManager Awake");
            Controls = new InputSystem_Actions();
            Controls.Player.Enable();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
