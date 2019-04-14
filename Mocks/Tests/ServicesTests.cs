using System;
using Mocks.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace Mocks.Tests
{
    [TestFixture]
    public class ServicesTests
    {
        [Test]
        public void OrchestratorCallsA()
        {
            IServices servicesMock =
                MockRepository.GenerateStrictMock<IServices>();
            servicesMock.Expect(
                a => a.MethodA());
            servicesMock.Stub(
                b => b.MethodB());

            Orchestrator orchestrator =
                new Orchestrator(servicesMock);
            orchestrator.Orchestrate();

            servicesMock.VerifyAllExpectations();
        }

        [Test]
        public void OrchestratorCallsB()
        {
            IServices serviesMock =
                MockRepository.GenerateStrictMock<IServices>();
            serviesMock.Expect(
                b => b.MethodB());
            serviesMock.Stub(
                a => a.MethodA());

            Orchestrator orchestrator =
                new Orchestrator(serviesMock);
            orchestrator.Orchestrate();

            serviesMock.VerifyAllExpectations();
        }
    }
}

/*
 * En este caso usamos Stubs para poder testear las dos llamadas
del Orchestrator de forma separada.
El primer test tan sólo se encarga de probar que el servicio A
se llama, mientras que con la ayuda del stub, le decimos al framework
que nos da igual lo que se haga con el método B.

Estamos diseñando qué elementos toman parte en la orquestración
y no tanto el orden mismo. Así el test no es tan frágil y la posibilidad
de romper los test por cambios en el SUT disminuye.
*/
