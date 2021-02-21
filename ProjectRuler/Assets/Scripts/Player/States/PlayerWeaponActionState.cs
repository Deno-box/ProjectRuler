using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponActionState : IPlayerState
{
    // コンストラクタ
    public PlayerWeaponActionState(PlayerStateController controller)
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
    }

    // ステートを抜ける処理
    public void Exit()
    {

    }
}