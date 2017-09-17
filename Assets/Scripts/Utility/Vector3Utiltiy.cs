using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Utiltiy {
    public static Vector3 ReturnNormalizedYZeroVec3(Vector3 vec){
        return new Vector3(vec.x, 0, vec.z).normalized;
    }//yを0にした後
}
