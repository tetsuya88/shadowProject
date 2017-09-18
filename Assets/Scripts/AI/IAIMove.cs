using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIMoveStrategy {
    float GetSpeed();
    void SetSpeed(float speed);
    float DoMove();//毎フレームコール
    void Destory();
}
