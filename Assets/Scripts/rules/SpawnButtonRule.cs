using System.Collections.Generic;
using UnityEngine;

public class SpawnButtonRule : ILevelRule
{
    private PlayerMovement player;
    private SceneFader sceneFader;

    private int buttonsSpawned = 0;
    private int maxButtons = 5;

    private GameObject buttonPrefab;
    private Door door;
    private List<Transform> spawnPoints;

    private List<GameObject> activeButtons = new List<GameObject>();

    public SpawnButtonRule(GameObject buttonPrefab, List<Transform> spawnPoints, Door door)
    {
        this.buttonPrefab = buttonPrefab;
        this.spawnPoints = spawnPoints;
        this.door = door;
    }

    public void Apply(PlayerMovement player)
    {
        this.player = player;
        buttonsSpawned = 0;
        SpawnNextButton();
    }

    public void Update(PlayerMovement player, SceneFader fader)
    {

    }

    private void SpawnNextButton()
    {
        if (buttonsSpawned < maxButtons && buttonsSpawned < spawnPoints.Count)
        {
            GameObject newButton = GameObject.Instantiate(buttonPrefab, spawnPoints[buttonsSpawned].position, Quaternion.identity);
            ButtonTrigger btnTrigger = newButton.GetComponent<ButtonTrigger>();
            btnTrigger.SetCommand(new SpawnButtonCommand(this));
            activeButtons.Add(newButton);
            buttonsSpawned++;
        }
        else
        {
            door.Open();
        }
    }

    public void OnButtonPressed()
    {
        if (activeButtons.Count > 0)
        {
            GameObject lastBtn = activeButtons[activeButtons.Count - 1];
            activeButtons.RemoveAt(activeButtons.Count - 1);
            GameObject.Destroy(lastBtn);
        }

        SpawnNextButton();
    }
}

public class SpawnButtonCommand : ICommand
{
    private SpawnButtonRule rule;

    public SpawnButtonCommand(SpawnButtonRule rule)
    {
        this.rule = rule;
    }

    public void Execute()
    {
        rule.OnButtonPressed();
    }
}
