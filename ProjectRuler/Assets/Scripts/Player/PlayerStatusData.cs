using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreatePlayerStatusAsset")]
public class PlayerStatusData : ScriptableObject
{
    // 移動加速度
    public float moveSpeed;
    // ダッシュ時の速度
    public float dashSpeed;
    // 移動時の摩擦係数
    public float friction;
    // 方向転換時の回転速度
    public float rotSpeed;
}
