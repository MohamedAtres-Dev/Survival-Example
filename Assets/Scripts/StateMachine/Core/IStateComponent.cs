namespace Mohamed.StateMachine
{
	interface IStateComponent
	{
		/// <summary>
		/// Called when entering the state.
		/// </summary>
		void OnStateEnter(StateMachine stateMachine);

		/// <summary>
		/// Called when leaving the state.
		/// </summary>
		/// 
		void OnStateExit(StateMachine stateMachine);
	}
}
