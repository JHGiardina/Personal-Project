using UnityEngine;

public class AttackState : BaseState
{

    public override void Enter()
    {

    }
    public override void Perform()
    {
        AttackCycle();
        enemy.currentState = "Attack";
    }
    public override void Exit()
    {

    }

    public void AttackCycle()
    {
        enemy.Agent.SetDestination(enemy.Target.transform.position);
    }
}
