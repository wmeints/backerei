using System;
using System.Collections;
using System.Collections.Generic;

namespace Backerei.Purchasing.Domain.Commands
{
    public class CreateInvoiceCommand
    {
        public CreateInvoiceCommand(
            Guid supplierId, 
            string invoiceNumber, 
            DateTime invoiceDate, 
            double totalPrice)
        {
            InvoiceNumber = invoiceNumber;
            SupplierId = supplierId;
            InvoiceDate = invoiceDate;
            TotalPrice = totalPrice;
        }

        public string InvoiceNumber { get; }
        public Guid SupplierId { get;  }
        public DateTime InvoiceDate { get; }
        public double TotalPrice { get; }
    }
}