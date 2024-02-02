using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestScriptableObject))]
public class TestSoEditor : Editor
{
	bool _isOpen = false;
	int _index = 0;
	int _prefabIndex = 0;
	string[] _names;
	TestScriptableObject _testSo;

	private void Awake()
	{
		_testSo = (TestScriptableObject)target;
		Debug.LogError("Awake");

		//var resources = Resources.LoadAll("Data/Abuilities");
		//_names = new string[resources.Length];
		//for (var i = 0; i < resources.Length; i++)
		//{
		//	_names[i] = resources[i].name;
		//}

		_index = 0;
		if (_testSo.Damage > 0)
		{
			_index = 1;
		}

		//resources = null;
		//Resources.UnloadUnusedAssets();
	}

	public override void OnInspectorGUI()
	{
		var data = new []{ "Armor", "Damage"};
		_index = EditorGUILayout.Popup(_index, data);

		if (_index == 0)
		{
			UpdateArmor();
		}
		else
		{
			UpdateDamage();
		}

		_prefabIndex = EditorGUILayout.Popup(_prefabIndex, _names);
		_testSo.Id = _names[_prefabIndex];

		_isOpen = GUILayout.Toggle(_isOpen, "Show Default Inspector");
		if (_isOpen)
		{
			DrawDefaultInspector();
		}

		EditorUtility.SetDirty(target);
	}

	private void UpdateArmor()
	{
		_testSo.Armor = EditorGUILayout.DelayedIntField("Armor", _testSo.Armor);
		_testSo.Damage = 0;
	}

	private void UpdateDamage()
	{
		_testSo.Damage = EditorGUILayout.DelayedIntField("Damage", _testSo.Damage);
		_testSo.Armor = 0;
	}
}
