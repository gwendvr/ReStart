public class NormalRule : ILevelRule
{
    public void Apply(PlayerMovement player)
    {
        player.SetCanMove(true);
        player.SetMoveSpeed(5f);
    }

    public void Update(PlayerMovement player, SceneFader fader)
    {
        
    }
}
