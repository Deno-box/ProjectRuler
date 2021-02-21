using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    // プレイヤーに起こりうる状態
    public enum PlayerStateEnum
    {
        Idle,           // アイドル
        Move,           // 移動
        Avoidance,      // 回避
        ReceiveDamage,  // ダメージを受ける
        Jump,           // ジャンプ
        Hack,           // ハッキング
        Robbery,        // 強奪
        WeaoponAction,  // 装備のアクション
        None            // なし
    }

    // プレイヤーステートのリスト
    private Dictionary<PlayerStateEnum, IPlayerState> stateDic = new Dictionary<PlayerStateEnum, IPlayerState>();
    // 現在実行されているステート
    private IPlayerState activeState = null;
    public IPlayerState ActiveState { get { return activeState; } }
    // 1フレーム前に実行されていたステート
    private IPlayerState lastState = null;
    public IPlayerState LastState { get { return lastState; } }



    void Start()
    {
        // ステートを作成、登録
        CreateState();

        // ステートを初期化
        for (PlayerStateEnum i = 0; i < PlayerStateEnum.None; i++)
            stateDic[i].SceneStart();

        // 初期ステートを設定
        activeState = stateDic[PlayerStateEnum.Idle];

        // アクティブステートを初期化
        activeState.Initialize();


        lastState = activeState;
    }

    void Update()
    {
        // アクティブなステートを実行
        activeState.Execute();

        lastState = activeState;
    }

    // ステートを変更
    public void ChangeActiveState(PlayerStateEnum state)
    {
        activeState.Exit();
        activeState = stateDic[state];
        activeState.Initialize();
    }

    // 各ステートを作成、ステートディクショナリーに登録
    private void CreateState()
    {
        stateDic.Add(PlayerStateEnum.Idle,          new PlayerIdleState(this));
        stateDic.Add(PlayerStateEnum.Move,          new PlayerMoveState(this));
        stateDic.Add(PlayerStateEnum.Avoidance,     new PlayerAvoidanceState(this));
        stateDic.Add(PlayerStateEnum.ReceiveDamage, new PlayerReceiveDamageState(this));
        stateDic.Add(PlayerStateEnum.Jump,          new PlayerJumpState(this));
        stateDic.Add(PlayerStateEnum.Hack,          new PlayerHackState(this));
        stateDic.Add(PlayerStateEnum.Robbery,       new PlayerRobberyState(this));
        stateDic.Add(PlayerStateEnum.WeaoponAction, new PlayerWeaponActionState(this));
    }
}
