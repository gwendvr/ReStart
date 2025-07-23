using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelRulesManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private SceneFader sceneFader;

    private ILevelRule currentRule;

    private Dictionary<int, ILevelRule> ruleMap;

    private void Awake()
    {
        if (playerMovement == null)
            playerMovement = FindObjectOfType<PlayerMovement>();

        if (sceneFader == null)
            sceneFader = FindObjectOfType<SceneFader>();

        ruleMap = new Dictionary<int, ILevelRule>()
        {
            { 1, new NormalRule() },
            { 2, new OneActionRule(InputManager.Controls) }
        };
    }

    private void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        currentRule = ruleMap.ContainsKey(index) ? ruleMap[index] : new NormalRule();
        currentRule.Apply(playerMovement);
    }

    private void Update()
    {
        currentRule?.Update(playerMovement, sceneFader);
    }
}