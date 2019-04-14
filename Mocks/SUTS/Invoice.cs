using System;

namespace Mocks
{
    public class Invoice
    {
        private TaxManager taxManager;

        public Invoice(TaxManager taxManager)
        {
            this.taxManager = taxManager;
        }

        internal void AddLine(Line line)
        {
            throw new NotImplementedException();
        }

        internal float GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}