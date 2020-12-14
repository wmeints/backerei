using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Backerei.Purchasing.Domain.Commands;
using Backerei.Purchasing.Domain.Common;

namespace Backerei.Purchasing.Domain.Entities
{
    public class Invoice : AggregateRoot<int>
    {
        private Invoice()
        {

        }

        public Invoice(int id, Guid supplierId, DateTime invoiceDate, string invoiceNumber, double totalPrice) : base(id)
        {
            SupplierId = supplierId;
            InvoiceDate = invoiceDate;
            InvoiceNumber = invoiceNumber;
            TotalPrice = totalPrice;
        }

        public Guid SupplierId { get; private set; }

        public DateTime InvoiceDate { get; private set; }

        public string InvoiceNumber { get; private set; }

        public double TotalPrice { get; private set; }

        public static Invoice Create(CreateInvoiceCommand cmd)
        {
            var invoice = new Invoice(
                0, 
                cmd.SupplierId,
                cmd.InvoiceDate,
                cmd.InvoiceNumber, 
                cmd.TotalPrice);

            return invoice;
        }

    }
}