﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    // コンストラクタ
    public PlayerIdleState(PlayerStateController controller) 
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
    }

    // ステートの実行処理
    public void Execute()
    {
        // 移動ステートへ遷移
        if (Input.GetButtonDown("Horizontal"))
            stateController.ChangeActiveState(PlayerStateController.PlayerStateEnum.Move);
        else
        if (Input.GetButtonDown("Vertical"))
            stateController.ChangeActiveState(PlayerStateController.PlayerStateEnum.Move);
    }

    // ステートを抜ける処理
    public void Exit()
    {

    }
}
