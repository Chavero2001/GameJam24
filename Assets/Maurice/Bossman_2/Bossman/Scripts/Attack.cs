using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attack : StateMachineBehaviour
{
    bool change = false;
    public static bool finish = false;
    float timer;
    float delay = 5f;
    int style = 0;
    public static bool triggerBoss = false;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(triggerBoss == true){
            timer += Time.deltaTime;
            if (change) {
                style = 1;
            }
            if (!change) {
                style = 2;
            }

            Debug.Log("vcuwdcvbhkdsb");
            if (!change && timer >= delay)
            {
                Debug.Log("worik");


                animator.SetInteger("Attack", style);

                if (finish)
                {

                    timer = 0f;
                    Debug.Log("hello");
                    animator.SetInteger("Attack", 0);
                    change = !change;
                    finish = false;

                }

            }
            if (change && timer >= delay)
            {
                animator.SetInteger("Attack", style);

                if (timer > 10f)
                {
                    change = !change;
                    timer = 0f;
                    animator.SetInteger("Attack", 0);

                }
            }
        }
        
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
      
    }
    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
