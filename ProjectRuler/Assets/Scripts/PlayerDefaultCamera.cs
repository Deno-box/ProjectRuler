using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultCamera : MonoBehaviour
{
    // マウスの感度
    [SerializeField]
    private float sensitivity = 0.0f;
    // プレイヤーとカメラの距離
    [SerializeField]
    private float distance = 0.0f;
    // プレイヤーのトランスフォーム
    [SerializeField]
    private Transform player = null;
    // プレイヤーとカメラのオフセット
    [SerializeField]
    private Vector3 offset = Vector3.zero;

    // 水平方向のクォータニオン
    private Quaternion hRotation = Quaternion.identity;
    public Quaternion HrizontalRotation { get { return hRotation; } }
    // 垂直方向のクォータニオン
    private Quaternion vRotation = Quaternion.identity;


    void Start()
    {
        this.transform.position = player.position + offset - transform.rotation * (Vector3.forward * distance);
    }

    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        vRotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * sensitivity, 0.0f, 0.0f);
        hRotation *= Quaternion.Euler(0.0f,Input.GetAxis("Mouse X") * sensitivity, 0.0f);
        this.transform.rotation = hRotation * vRotation;

        this.transform.position = player.position + offset - transform.rotation *  (Vector3.forward * distance);
    }
}
