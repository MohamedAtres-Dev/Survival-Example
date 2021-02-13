using UnityEngine;
using Mohamed.StateMachine;
using Mohamed.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsRunning", menuName = "State Machines/Conditions/Is Running")]
public class IsRunningSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsRunning();
}

public class IsRunning : Condition
{
	protected new IsRunningSO OriginSO => (IsRunningSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	protected override bool Statement()
	{
		return false;
	}
	
}
