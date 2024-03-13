namespace LoadingScreen.Factory
{
    public interface IScreenFactory
    {
        public T GetScreen<T>() where T : LoadingScreenTemplate;
    }
}