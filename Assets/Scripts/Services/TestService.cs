using UnityEngine;

namespace Services
{
    public interface ITestService
    {
        void DoShit();
    }
    
    public class TestService : ITestService
    {
        public void DoShit()
        {
            Debug.Log("I AM SHIT!");
        }
    }
}