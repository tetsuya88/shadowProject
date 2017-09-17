using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("AIScript/AIMover")]
public class AIMover : MonoBehaviour
{
    private IAIMoveStrategy aiMoveStrategy;
    // Use this for initialization
    void Awake()
    {
        aiMoveStrategy = GetComponent<IAIMoveStrategy>();
        if(aiMoveStrategy==null){
            Debug.Log("AIの移動戦略が指定されていません。");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        aiMoveStrategy.DoMove();
    }
}
