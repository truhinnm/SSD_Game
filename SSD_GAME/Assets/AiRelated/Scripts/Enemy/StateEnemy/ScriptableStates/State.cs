using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableStates
{
    [CreateAssetMenu(menuName = "ScriptableStates/State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transitions;

        public void UpdateState(EnemyController enemyController)
        {
            foreach(Action action in actions)
            {
                action.Act(enemyController);
                CheckTransitions(enemyController);
            }
        }
        public void CheckTransitions(EnemyController enemyController)
        {
            foreach(Transition transition in transitions)
            {
                if (transition.decision.Decide(enemyController) != transition.invertDecision)
                    enemyController.ChangeState(transition.nextState);
            }
        }
    }
}