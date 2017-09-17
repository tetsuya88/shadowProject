using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
[AddComponentMenu("AIScript/AINodeMove")]
[DisallowMultipleComponent]
public class AINodeMove : MonoBehaviour ,IAIMoveStrategy{
    public List<Transform> _transformList;
	[SerializeField] private float speed;
    private List<Vector3> _positionList;
    private int _index = 0;
	// Use this for initialization
	void Start () {
        _positionList = new List<Vector3>(_transformList.Select(t=>t.position));
	}


    public void DoMove(){
		if (_index < _positionList.Count)
		{
			Vector3 nextPosition = _positionList[_index];
			if (Vector3.Distance(this.transform.position, nextPosition) < 1f)
			{
				_index++;
			}
            this.transform.position += Vector3Utiltiy.ReturnNormalizedYZeroVec3(nextPosition - this.transform.position) * speed;
		}
    }

    private void OnDrawGizmos()
    {
        if (_transformList.Count()==0) return;
        if (Application.isPlaying) return;


        if(Selection.gameObjects.Count()==1){
 
            var selectedGameObject = Selection.gameObjects[0];
            if (selectedGameObject == this.gameObject || selectedGameObject.transform.parent == this.gameObject.transform)
            {

                if (_transformList[0] == null) return;
				Gizmos.color = Color.blue;
                Gizmos.DrawLine(this.transform.position,_transformList[0].position);
                for (int i = 0; i < _transformList.Count();i++)
                {
                    if (_transformList[i] == null) break;
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

