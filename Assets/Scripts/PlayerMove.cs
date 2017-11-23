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
				GameObject obj = prevStageObjs.GetComponent<Position>().stageObjs[stage];
				if (!obj)
					return;

				isMove = false;
				transform.DOMove(obj.transform.position, 1f).SetEase(Ease.InQuint).OnComplete(() => isMove = true);
				prevStageObjs = obj;
			}
		}
	}
}
