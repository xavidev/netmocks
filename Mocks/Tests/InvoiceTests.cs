using System;
using NUnit.Framework;

namespace Mocks.Tests
{
    [TestFixture]
    public class InvoiceTests
    {
        [Test]
        public void CalculateTaxes()
        {
            Stock stock = new Stock();
            Product product = stock.GetProductWithCode("xlabc3t3c");
            Line line = new Line();
            int quantity = 10;
            line.AddProducts(product, quantity);
            Invoice invoice = new Invoice(new TaxManager());
            invoice.AddLine(line);

            float total = invoice.GetTotal();

            Assert.Greater(quantity * product.Price, total);
        }
    }
}

/* Es importante ver, que en este caso no necesitamos utilizar
un Doble para el TaxManager ya que la respuesta de este colaborador
de la clase Invoice es rápida. No utiliza ningúna llamada a un servicio
externo ni persistencia en BDD/ficheros.

Al no tener el TaxManager doblado podemos pensar que el test podría
ser más frágil al no tener el 100% de garantias que el TaxManager 
funcione de la forma esperada. En parte es cierto, pero en este
caso nuestro SUT es la clase Invoice, y es esta la que tenemos que 
probar y asegurarnos de su correcto funcionamiento. Utilizar el
colaborador real TaxManager nos puede servir para ir descubriendo errores
en su comportamiento que iremos arreglando en el transcurso de los Test.
*/