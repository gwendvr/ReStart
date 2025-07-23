using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class LevelRulesManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private SceneFader sceneFader;

    private ILevelRule currentRule;

    private Dictionary<int, ILevelRule> ruleMap;

    private IEnumerator Start()
    {
        if (playerMovement == null)
            playerMovement = FindFirstObjectByType<PlayerMovement>();

        if (sceneFader == null)
            sceneFader = FindFirstObjectByType<SceneFader>();

        while (InputManager.Controls == null)
            yield return null;

        ruleMap = new Dictionary<int, ILevelRule>()
        {
            { 1, new NormalRule() },
            { 2, new OneActionRule(InputManager.Controls) }
        };

        int index = SceneManager.GetActiveScene().buildIndex;

        currentRule = ruleMap.ContainsKey(index) ? ruleMap[index] : new NormalRule();
        currentRule.Apply(playerMovement);
    }

    private void Update()
    {
        currentRule?.Update(playerMovement, sceneFader);
    }
}