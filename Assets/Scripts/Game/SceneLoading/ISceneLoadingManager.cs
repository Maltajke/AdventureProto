namespace Game.SceneLoading
{
    public interface ISceneLoadingManager
    {
        string CurrentScene { get; }
        void LoadScene(string key);
    }
}