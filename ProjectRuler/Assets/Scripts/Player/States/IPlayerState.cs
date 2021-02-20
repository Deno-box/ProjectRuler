public interface IPlayerState
{
    // シーン読み込み時の初期化処理
    void SceneStart();
    // ステート遷移時の初期化処理
    void Initialize();
    // ステートの実行処理
    void Execute();
    // ステートを抜ける処理
    void Exit();
}
