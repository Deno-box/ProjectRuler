﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    // ステートコントローラー
    private PlayerStateController stateController;
    // プレイヤーのステータスデータ
    private PlayerStatusData statusData;
    // プレイヤーのアニメメーター
    private Animator aimator;
    // プレイヤーのゲームオブジェクト
    private GameObject player;
    // プレイヤーのRigidbody
    private Rigidbody rb;
    // 移動ベクトル
    private Vector3 moveVec;
    // メインカメラ
    private Camera camera;


    // コンストラクタ
    public PlayerMoveState(PlayerStateController controller)
    {
        stateController = controller;
    }

    // シーン読み込み時の初期化処理
    public void SceneStart()
    {
        // データを取得
        statusData = stateController.GetComponent<PlayerStatus>().StatusData;
        aimator = stateController.GetComponent<PlayerStatus>().PlayerAnimator;
        player = stateController.gameObject;
        rb = stateController.GetComponent<Rigidbody>();
        moveVec = Vector3.zero;
        camera = Camera.main;
    }

    // ステート遷移時の初期化処理
    public void Initialize()
    {
        
    }

    // ステートの実行処理
    public void Execute()
    {
        Move();
        Rotate();

        // ダッシュボタンを押したらダッシュ移動へ
        if (Input.GetButtonDown("Dash"))
            stateController.ChangeActiveState(PlayerStateController.PlayerStateEnum.Dash);

        AnimParameterSet();
    }

    // ステートを抜ける処理
    public void Exit()
    {

    }

    // 移動処理
    private void Move()
    {
        moveVec = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (moveVec.magnitude > 0)
        {
            moveVec *= statusData.moveSpeed * statusData.friction;// * Time.deltaTime;
            rb.velocity = camera.GetComponent<PlayerDefaultCamera>().HrizontalRotation * moveVec;
        }
    }

    // 方向転換処理
    private void Rotate()
    {
        if (moveVec.magnitude > 0)
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, 
            Quaternion.LookRotation(camera.GetComponent<PlayerDefaultCamera>().HrizontalRotation * moveVec),
            statusData.rotSpeed);
    }

    // アニメーションのパラメーターを設定
    private void AnimParameterSet()
    {
        // TODO : 検討中 移動方向に応じてアニメーションを変更
        Vector3 cameraVec = camera.GetComponent<PlayerDefaultCamera>().HrizontalRotation * Vector3.forward;
        float angle = Vector3.Angle(moveVec, cameraVec);
        aimator.SetFloat("MoveDir", angle);
        aimator.SetFloat("MoveVel", moveVec.magnitude);
    }
}