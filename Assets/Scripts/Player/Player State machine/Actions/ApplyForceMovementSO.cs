using UnityEngine;
using Mohamed.StateMachine;
using Mohamed.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ApplyForceMovement", menuName = "State Machines/Actions/Apply Force Movement")]
public class ApplyForceMovementSO : StateActionSO
{
	protected override StateAction CreateAction() => new ApplyForceMovement();
}

public class ApplyForceMovement : StateAction
{
	protected new ApplyForceMovementSO OriginSO => (ApplyForceMovementSO)base.OriginSO;

	private PlayerMovement _playerMovement = default;

	public override void Awake(StateMachine stateMachine)
	{
		_playerMovement = stateMachine.GetComponent<PlayerMovement>();
	}
	
	public override void OnUpdate()
	{
		
		//_playerMovement._rigidBody.AddForce(_playerMovement.movementVector);
		
	}
	
	public override void OnStateEnter(StateMachine stateMachine)
	{
	}
	
	public override void OnStateExit(StateMachine stateMachine)
	{
	}
}
