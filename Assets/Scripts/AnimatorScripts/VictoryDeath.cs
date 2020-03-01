using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryDeath : StateMachineBehaviour
{
    private Text victoryMessage;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<Timer>().EndTimer(true, true);

        victoryMessage = GameObject.FindObjectOfType<Text>();

        victoryMessage.text += "\nOr not...";

        animator.SetBool("Restart", true);
    }
}