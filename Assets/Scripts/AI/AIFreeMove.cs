using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[DisallowMultipleComponent]
[AddComponentMenu("AIScript/AIFreeMove")]
public class AIFreeMove : MonoBehaviour,IAIMoveStrategy {
    private Vector3 _movingDiretion = Vector3.right;
	[SerializeField]private float limit = 5f;
    [SerializeField]private float _speed = 0.1f;
	// Use this for initialization

    void Start(){
		float rx = Random.Range (0, 1f);
		float rz = Random.Range (0, 1f);

		Vector3 direction = new Vector3 (rx, 0, rz);//Vector3.left;
		direction = Quaternion.Euler(0, 5f, 0) * direction;
        _movingDiretion = direction;

	}
	public void Destory()
	{
        
		Destroy(this);
	}
    public float DoMove(){
		RaycastHit hit = new RaycastHit();
		int mask = 1 << 8;
		Physics.Raycast(this.transform.position, _movingDiretion, out hit, Mathf.Infinity, mask);
		Debug.Log (hit.distance);
        if (hit.collider != null && hit.distance<limit){
			_movingDiretion = GetNextDirection();
		}
        this.transform.forward = Vector3Utiltiy.ReturnNormalizedYZeroVec3(_movingDiretion);
		this.transform.position += _movingDiretion * _speed;
        return _speed;
    }
	public float GetSpeed()
	{
		return _speed;
	}
	public void SetSpeed(float speed)
	{
		_speed = speed;
	}
    private Vector3 GetNextDirection(){
		RaycastHit hit = new RaycastHit();
        int mask = 1 << 8;
		var rayDirection = Vector3.right;
		var vecList = new List<Vector2>();
		for (int i = 0; i < 72; i++)
		{
			Physics.Raycast(this.transform.position, rayDirection, out hit, Mathf.Infinity, mask);
            if(hit.collider == null){
  
                return rayDirection;
            }
            Debug.DrawLine(this.transform.position,hit.point,Color.red);
            vecList.Add(new Vector2(i, hit.distance));
			rayDirection = Quaternion.Euler(0, 5f, 0) * rayDirection;
		}
        float index = vecList.Where(v=>v.y == vecList.Max(m=>m.y)).ElementAt(0).x;
        return Quaternion.Euler(0, 5f * index, 0) * Vector3.right;
    }
}
