using UnityEngine;

public class PlayerDetectedState : State
{
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    public bool performCloseRangeAction;
    public bool isPlayerBehind;

    protected D_PlayerDetected stateData;
    public PlayerDetectedState(Entity entity, StateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.ChekPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.ChekPlayerInMaxAgroRange();
        isPlayerBehind = entity.CheckPlayerBehind();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();


        performLongRangeAction = false;
        entity.SetVeloity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
