using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour {

	public GameObject prevStageObjs;
	Dictionary<KeyCode, Const.Direction> keyDirDictionary = new Dictionary<KeyCode, Const.Direction>() {
		{KeyCode.UpArrow, Const.Direction.north},
		{KeyCode.LeftArrow, Const.Direction.west},
		{KeyCode.DownArrow, Const.Direction.south},
		{KeyCode.RightArrow, Const.Direction.east}
	};

	bool isMove = true;

	private void Update() {
		foreach (KeyCode key in keyDirDictionary.Keys) {

			if (Input.GetKeyDown(key) && isMove) {
				Const.Direction direction = keyDirDictionary[key];
				Position position = prevStageObjs.GetComponent<Position>();
				GameObject pathObj = position.dirPathObjs[direction];
				if (!pathObj)
					return;
				Path path = pathObj.GetComponent<Path>();
				if (!path)
					return;

				isMove = false;
				transform.DOPath(path.GetPath(prevStageObjs.transform), 0.8f, PathType.CatmullRom)
						 .SetEase(Ease.Linear).OnComplete(() => isMove = true);
				prevStageObjs = path.GetEndPosition(prevStageObjs.transform);
			}

		}
	}
}
