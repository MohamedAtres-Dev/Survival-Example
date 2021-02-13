using UnityEngine;
using Mohamed.StateMachine;
using Mohamed.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "RotateAction", menuName = "State Machines/Actions/Rotate Action")]
public class RotateActionSO : StateActionSO<RotateAction>
{
	public float turnSmoothTime = 0.2f;
}

public class RotateAction : StateAction
{
	private PlayerMovement _playerMovement = default;
	private Transform _transform;
	protected new RotateActionSO OriginSO => (RotateActionSO)base.OriginSO;

	private float _turnSmoothSpeed; //Used by Mathf.SmoothDampAngle to smoothly rotate the character to their movement direction
	private const float ROTATION_TRESHOLD = .02f; // Used to prevent NaN result causing rotation in a non direction
	public override void Awake(StateMachine stateMachine)
	{
		_playerMovement = stateMachine.GetComponent<PlayerMovement>();
		_transform = stateMachine.GetComponent<Transform>();
	}
	
	public override void OnUpdate()
	{
		Vector3 horizontalMovement = _playerMovement.movementVector;
		horizontalMovement.y = 0f;

		if (horizontalMovement.sqrMagnitude >= ROTATION_TRESHOLD)
		{
			float targetRotation = Mathf.Atan2(_playerMovement.movementVector.x, _playerMovement.movementVector.z) * Mathf.Rad2Deg;
			_transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(
				_transform.eulerAngles.y,
				targetRotation,
				ref _turnSmoothSpeed,
				0.2f);
		}
	}
	
}
