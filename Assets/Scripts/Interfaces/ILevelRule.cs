public interface ILevelRule
{
    void Apply(PlayerMovement player);
    void Update(PlayerMovement player, SceneFader fader);
}
