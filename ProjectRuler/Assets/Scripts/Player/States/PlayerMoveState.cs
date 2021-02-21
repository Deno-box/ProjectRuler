using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    // コンストラクタ
    public PlayerMoveState(PlayerStateController controller)
    {
        stateController = controller;
    }

    // ステートコントローラー
    private PlayerStateController stateController;

    // シーン読み込み時の初期化処理
    public void SceneStart()
    {
    }

    // ステート遷移時の初期化処理
    public void Initialize()
    {
        Debug.Log("Move Initialize");
    }

    // ステートの実行処理
    public void Execute()
    {
        Debug.Log("Move Execute");
    }

    // ステートを抜ける処理
    public void Exit()
    {

    }
}