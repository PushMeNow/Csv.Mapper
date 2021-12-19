namespace Csv.Mapper.Tests.Fixtures
{
    public abstract class FixtureBase<TService>
    {
        private TService _service;

        public TService Service
        {
            get
            {
                if (_service is null)
                {
                    _service = CreateService();
                }

                return _service;
            }
        }

        protected abstract TService CreateService();
    }
}