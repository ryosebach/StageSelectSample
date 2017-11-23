using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour {

	public GameObject prevStageObjs;
	Dictionary<KeyCode, Const.Stages> keyMap = new Dictionary<KeyCode, Const.Stages>() {
		{KeyCode.UpArrow, Const.Stages.north},
		{KeyCode.LeftArrow, Const.Stages.west},
		{KeyCode.DownArrow, Const.Stages.south},
		{KeyCode.RightArrow, Const.Stages.east}
	};

	bool isMove = true;

	private void Update() {
		foreach (KeyCode key in keyMap.Keys) {

			if (Input.GetKeyDown(key) && isMove) {
				Debug.Log(key);
				Debug.Log(keyMap[key]);
				Const.Stages stage = keyMap[key];
				Debug.Log(stage);
				Position position = prevStageObjs.GetComponent<Position>();
				GameObject obj = position.stageObjs[stage];
				if (!obj)
					return;

				isMove = false;
				prevStageObjs = obj;
				transform.DOPath(new Vector3[] { transform.position, obj.transform.position + Vector3.up * 0.5f }, 0.8f, PathType.CatmullRom)
						 .SetEase(Ease.Linear).OnComplete(() => isMove = true);
			}

		}
	}
}
