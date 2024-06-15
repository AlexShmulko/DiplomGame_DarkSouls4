using UnityEngine;

public class E3_MoveState : MoveState
{
    private Enemy3 enemy;

    public E3_MoveState(Entity entity, StateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Debug.Log(isPlayerInMaxAgroRange);

        if (isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isPlayerBehind)
        {
            entity.Flip();
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
