namespace Game.SceneLoading
{
    public interface ISceneLoadingManager
    {
        string CurrentScene { get; }
        void LoadGameScene(string key);
        void LoadMenu();
    }
}