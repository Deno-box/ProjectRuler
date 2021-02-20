using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : MonoBehaviour, IPlayerState
{
    // ステートコントローラー
    private PlayerStateController stateController;

    // シーン読み込み時の初期化処理
    public void SceneStart()
    {
        stateController = this.GetComponent<PlayerStateController>();
    }

    // ステート遷移時の初期化処理
    public void Initialize()
    {

    }

    // ステートの実行処理
    public void Execute()
    {
        if (Input.GetButtonDown("Horizontal"))
            stateController.ChangeActiveState(PlayerStateController.PlayerStateEnum.Move);
    }

    // ステートを抜ける処理
    public void Exit()
    {

    }
}
