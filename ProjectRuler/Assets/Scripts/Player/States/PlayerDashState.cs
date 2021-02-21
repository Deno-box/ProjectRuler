using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : IPlayerState
{
    // ステートコントローラー
    private PlayerStateController stateController;
    // プレイヤーのステータスデータ
    private PlayerStatusData statusData;
    // プレイヤーのアニメーター
    private Animator aimator;
    // プレイヤーのゲームオブジェクト
    private GameObject player;
    // プレイヤーのRigidbody
    private Rigidbody rb;
    // 移動ベクトル
    private Vector3 moveVec;
    // メインカメラ
    private Camera camera;

    // ダッシュボタンが押されたか
    private bool isPushDashButton = false;

    // コンストラクタ
    public PlayerDashState(PlayerStateController controller)
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

        if (Input.GetButtonDown("Dash"))
            stateController.ChangeActiveState(PlayerStateController.PlayerStateEnum.Move);
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
            moveVec *= statusData.dashSpeed * statusData.friction;// * Time.deltaTime;
            rb.velocity = camera.GetComponent<PlayerDefaultCamera>().HrizontalRotation * moveVec;
        }

        aimator.SetFloat("MoveVel", moveVec.magnitude);
    }

    // 方向転換処理
    private void Rotate()
    {
        if (moveVec.magnitude > 0)
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation,
            Quaternion.LookRotation(camera.GetComponent<PlayerDefaultCamera>().HrizontalRotation * moveVec),
            statusData.rotSpeed);
    }
}
