public class OpenDoorCommand : ICommand
{
    private Door door;

    public OpenDoorCommand(Door door)
    {
        this.door = door;
    }

    public void Execute()
    {
        door.Open();
    }
}
