using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEscapeMove : MonoBehaviour,IAIMoveStrategy {
    private Vector3 _moveDireciton;
    public float _speed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public float GetSpeed()
	{
		return _speed;
	}
	public void SetSpeed(float speed)
	{
		_speed = speed;
	}
    public void DoMove(){
        if(_moveDireciton==null){
            Debug.Log("方向が設定されていません");
            return;
        }
        this.transform.position += _moveDireciton*_speed;
    }

    public void SetMoveDirection(Vector3 moveDirection){
        _moveDireciton = Vector3Utiltiy.ReturnNormalizedYZeroVec3(moveDirection);
    }
}
