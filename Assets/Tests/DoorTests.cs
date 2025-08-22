using NUnit.Framework;
using UnityEngine;

public class DoorTests
{
    [Test]
    public void Door_IsClosed_ByDefault()
    {
        var go = new GameObject();
        var door = go.AddComponent<Door>();

        Assert.IsFalse(door.IsOpen, "La porte doit être fermée par défaut.");
        Assert.IsTrue(go.activeSelf, "Le GameObject doit être actif au départ.");
    }

    [Test]
    public void Door_Open_DisablesGameObjectAndSetsFlag()
    {
        var go = new GameObject();
        var door = go.AddComponent<Door>();

        door.Open();

        Assert.IsTrue(door.IsOpen, "Après Open(), IsOpen doit être vrai.");
        Assert.IsFalse(go.activeSelf, "Après Open(), le GameObject doit être désactivé.");
    }
}
