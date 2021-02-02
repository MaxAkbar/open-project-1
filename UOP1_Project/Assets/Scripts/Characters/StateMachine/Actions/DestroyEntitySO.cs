﻿using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "DestroyEntity", menuName = "State Machines/Actions/Destroy Entity")]
public class DestroyEntitySO : StateActionSO
{
	protected override StateAction CreateAction() => new DestroyEntity();
}

public class DestroyEntity : StateAction
{
	private GameObject _gameObject;

	public override void Awake(StateMachine stateMachine)
	{
		_gameObject = stateMachine.gameObject;
	}

	public override void OnUpdate()
	{

	}

	public override void OnStateEnter()
	{
		// Hack to force Collider Exit to be triggered before destroying an object.
		_gameObject.transform.position += - Vector3.up * 1000;
		GameObject.Destroy(_gameObject, 0.1f);
	}
}
