using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestSo", menuName = "ScriptableObject/TestSo")]
public class TestScriptableObject : ScriptableObject
{
	[SerializeField]
	private int _damage;
	[SerializeField]
	private int _armor;
	[SerializeField]
	private string _id;

	public int Damage { get => _damage; set { _damage = value;} }
	public int Armor { get => _armor; set { _armor = value;} }
	public string Id { get => _id; set { _id = value;} }
}
