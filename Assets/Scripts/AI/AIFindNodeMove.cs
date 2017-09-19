using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFindNodeMove : MonoBehaviour,IAIMoveStrategy {
    public float _speed;
	private Vector3? _nextNodePosition = new Vector3(0f,0f,0f);
    private List<Vector3> _nodePositions;
    private Vector3? _prevNodePosition;
	// Use this for initialization
	void Start () {
		_nodePositions = new List<Vector3>();
		foreach (var node in GameObject.FindGameObjectsWithTag("Node"))
		{
			_nodePositions.Add(node.transform.position);
		}

		_speed = MoveSpeed.WalkSpeed;
        _prevNodePosition = new Vector3(0f, 0f, 0f);
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
	public void Destory()
	{
		Destroy(this);
	}
    public float DoMove()
    {
        if (_nextNodePosition == null){
			RaycastHit hit = new RaycastHit();
			int mask = 1 << 8;
            List<Vector3> tmpList = new List<Vector3>();
            foreach (var nodePosition in _nodePositions)
            {
                Physics.Raycast(this.transform.position, (nodePosition-this.transform.position).normalized, out hit, Vector3.Distance(this.transform.position,nodePosition), mask);
                if (hit.collider == null)
                {
                    if(nodePosition!=(Vector3)_prevNodePosition)
                    tmpList.Add(nodePosition);
                }
            }

           var index  = (int)Random.Range(0, tmpList.Count - 0.01f);
            if(index<tmpList.Count)
            _nextNodePosition = tmpList[index];
        }
        var moveDirection = (Vector3)(_nextNodePosition - this.transform.position);
        this.transform.forward = Vector3Utiltiy.ReturnNormalizedYZeroVec3(moveDirection);
		//this.GetComponent<Rigidbody>().MovePosition(Vector3Utiltiy.ReturnNormalizedYZeroVec3(nextPosition - this.transform.position)*_speed*Time.deltaTime);
        this.transform.position += Vector3Utiltiy.ReturnNormalizedYZeroVec3(moveDirection) * _speed;
        if (moveDirection.magnitude < 1f){
            _prevNodePosition = _nextNodePosition;
			_nextNodePosition = null;

        }
		return _speed;
    }

}
