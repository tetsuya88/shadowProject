using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharmMove : MonoBehaviour ,IAIMoveStrategy{
    private Vector3 _moveDirection;
    private Transform charmTransform;
    private float _speed;
    public float GetSpeed(){
        return _speed;
    }
    public void SetSpeed(float speed){
        _speed = speed;
    }
	public void DoMove()
	{
		if (_moveDirection == null)
		{
			Debug.Log("方向が設定されていません");
			return;
		}
        this.transform.position += Vector3Utiltiy.ReturnNormalizedYZeroVec3(charmTransform.position-this.transform.position) * _speed;
	}

    public void SetTransofrm(ref Transform transform)
	{
        charmTransform = transform;
	} 
	
}
