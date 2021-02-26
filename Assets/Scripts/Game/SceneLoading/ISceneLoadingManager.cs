namespace Game.SceneLoading
{
    public interface ISceneLoadingManager
    {
        void LoadMenuFromSplash();
        void LoadGameFromMenu();
        float GetProgress();
        void LoadMenuFromGame();

        void LoadSplashFromMenu();
    }
}