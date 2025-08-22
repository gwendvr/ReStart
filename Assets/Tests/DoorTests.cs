using NUnit.Framework;
using UnityEngine;

public class DoorTests
{
    [Test]
    public void Door_IsClosed_ByDefault()
    {
        var go = new GameObject();
        var door = go.AddComponent<Door>();

        Assert.IsFalse(door.IsOpen, "La porte doit �tre ferm�e par d�faut.");
        Assert.IsTrue(go.activeSelf, "Le GameObject doit �tre actif au d�part.");
    }

    [Test]
    public void Door_Open_DisablesGameObjectAndSetsFlag()
    {
        var go = new GameObject();
        var door = go.AddComponent<Door>();

        door.Open();

        Assert.IsTrue(door.IsOpen, "Apr�s Open(), IsOpen doit �tre vrai.");
        Assert.IsFalse(go.activeSelf, "Apr�s Open(), le GameObject doit �tre d�sactiv�.");
    }
}
