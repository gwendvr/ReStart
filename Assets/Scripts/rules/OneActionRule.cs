using UnityEngine;

public class OneActionRule : ILevelRule
{
    private bool hasActed = false;
    private float timer = 0f;
    private float duration = 5f;
    private bool timerActive = false;

    private InputSystem_Actions controls;

    public OneActionRule(InputSystem_Actions sharedControls)
    {
        controls = sharedControls;
    }

    public void Apply(PlayerMovement player)
    {
        player.SetCanMove(false);
        player.SetMoveSpeed(4f);
    }

    public void Update(PlayerMovement player, SceneFader fader)
    {
        if (!hasActed)
        {
            Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
            bool jumpPressed = controls.Player.Jump.triggered;

            if (moveInput.x != 0 || jumpPressed)
            {
                hasActed = true;
                timer = duration;
                timerActive = true;
                player.SetCanMove(true);
            }
        }
        else if (timerActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timerActive = false;
                fader.FadeAndReload();
            }
        }
    }
}
