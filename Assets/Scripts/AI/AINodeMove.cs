using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
public class AINodeMove : MonoBehaviour {
    public List<Transform> _transformList;
    private List<Vector3> _positionList;
    private int _index = 0;
    [SerializeField] private float speed;
	// Use this for initialization
	void Start () {
        _positionList = new List<Vector3>(_transformList.Select(t=>t.position));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        if(_index<_positionList.Count){
            Vector3 nextPosition = _positionList[_index];
            if (Vector3.Distance(this.transform.position, nextPosition) < 1f){
                _index++;
            }
            this.transform.position += (nextPosition - this.transform.position).normalized * speed;
        }
    }

    private void OnDrawGizmos()
    {
        if(Selection.gameObjects.Count()==1&&!Application.isPlaying){
 
            var selectedGameObject = Selection.gameObjects[0];
            if (selectedGameObject == this.gameObject || selectedGameObject.transform.parent == this.gameObject.transform)
            {
				
				Gizmos.color = Color.blue;
                Gizmos.DrawLine(this.transform.position,_transformList[0].position);
                for (int i = 0; i < _transformList.Count();i++)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(_transformList[i].position, 1f);
                    if (i + 1 < _transformList.Count())
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(_transformList[i].position, _transformList[i + 1].position);
                    }
                }

            }
        }

    }

}

