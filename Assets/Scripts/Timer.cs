namespace Hacaton
{
    public class Timer 
    {
        private float m_CurrentTime;
        public bool IsFinished => m_CurrentTime <= 0;

        private bool _IsTimerGo;

        private float timer;

        public Timer(float startTime)
        {
            Start(startTime);
            timer = startTime;
        }

        public void Start(float startTime) 
        { 
            m_CurrentTime = startTime;
            _IsTimerGo = true;
        }

        public void RemoveTime(float deltaTime) 
        {
            if (m_CurrentTime <= 0) return;
            if (_IsTimerGo)
                m_CurrentTime -= deltaTime;
            else
                return;
        }

        public void Restart()
        {
            m_CurrentTime = timer;
        }

        public void Stop()
        {
            Restart();
            _IsTimerGo = false;
        }
    }
}
