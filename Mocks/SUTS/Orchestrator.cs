using System;
using Mocks.Interfaces;

namespace Mocks
{
    public class Orchestrator
    {
        private IServices services;

        public Orchestrator(IServices services)
        {
            this.services = services;
        }

       public void Orchestrate()
        {
            services.MethodA();
            services.MethodB();
        }
    }
}
