using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerMovementTests
{
    private GameObject playerObj;
    private PlayerMovement player;
    private GameObject inputManagerObj;

    [SetUp]
    public void Setup()
    {
        inputManagerObj = new GameObject("InputManager");
        inputManagerObj.AddComponent<InputManager>();

        playerObj = new GameObject("Player");
        player = playerObj.AddComponent<PlayerMovement>();

        playerObj.AddComponent<Rigidbody2D>();

        var groundCheck = new GameObject("GroundCheck").transform;
        var wallLeft = new GameObject("WallCheckLeft").transform;
        var wallRight = new GameObject("WallCheckRight").transform;

        typeof(PlayerMovement).GetField("groundCheck", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(player, groundCheck);
        typeof(PlayerMovement).GetField("wallCheckLeft", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(player, wallLeft);
        typeof(PlayerMovement).GetField("wallCheckRight", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(player, wallRight);

        var faderObj = new GameObject("SceneFader");
        var fader = faderObj.AddComponent<SceneFader>();
        typeof(PlayerMovement).GetField("sceneFader", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(player, fader);
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(playerObj);
        Object.Destroy(inputManagerObj);
    }

    [UnityTest]
    public IEnumerator SetCanMoveDisablesMovement()
    {
        player.SetCanMove(false);

        var rb = playerObj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(5f, 0f);

        yield return null;

        Assert.AreEqual(0f, rb.linearVelocity.x, 0.01f, "Player horizontal movement should be zero when canMove is false.");
    }

    [UnityTest]
    public IEnumerator SetMoveSpeedUpdatesSpeed()
    {
        float newSpeed = 10f;
        player.SetMoveSpeed(newSpeed);

        var moveSpeed = (float)typeof(PlayerMovement)
            .GetField("moveSpeed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(player);

        Assert.AreEqual(newSpeed, moveSpeed, 0.01f);
        yield return null;
    }
}
