namespace Services.PauseService
{
    public interface IPauseService
    {
        void PauseGame(bool value);
        void AddPauseListener(IPause pause);
    }
}