using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryDeath : StateMachineBehaviour
{
    private Text victoryMessage;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        victoryMessage = GameObject.FindObjectOfType<Text>();

        victoryMessage.text += "\nOr not...";

        SceneManager.LoadScene(0);
    }
}