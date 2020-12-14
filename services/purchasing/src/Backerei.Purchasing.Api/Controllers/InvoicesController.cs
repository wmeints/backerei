using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.Models;
using Backerei.Purchasing.Domain.Commands;
using Backerei.Purchasing.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backerei.Purchasing.Api.Controllers
{
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly FormRecognizerClient _formRecognizerClient;

        public InvoicesController(FormRecognizerClient formRecognizerClient)
        {
            _formRecognizerClient = formRecognizerClient;
        }

        [HttpPost]
        [Route("/api/invoices")]
        [Consumes("application/octet-stream")]
        public async Task<ActionResult<Invoice>> PostImage()
        {
            var invoiceContentStream = new MemoryStream();

            // This extra step is required to make the content seekable for the form recognizer client.
            // It does require more memory to process the incoming data.
            await Request.Body.CopyToAsync(invoiceContentStream);
            invoiceContentStream.Seek(0, SeekOrigin.Begin);

            // Start the recognizer operation. This will fire off the REST request to the form recognizer.
            // The response here is an "awaitable response" with a pending status. Sort of a task if you will. 
            var recognizeContentOperation = await _formRecognizerClient.StartRecognizeInvoicesAsync(
                invoiceContentStream,
                new RecognizeInvoicesOptions()
                {
                    ContentType = FormContentType.Pdf
                });

            // We can give the user some information, or we can wait for the operation to complete on the server.
            // Note: this will take a while! So be patient and grab a coffee or cold beverage.
            var recognizerResponse = await recognizeContentOperation.WaitForCompletionAsync();
            var form = recognizerResponse.Value.FirstOrDefault();

            // In some cases the cognitive service doesn't recognize the content as an invoice.
            // We should do something to let the user know it's not going to work out between them and the computer.
            if (form == null)
            {
                ModelState.AddModelError("", "The invoice was not recognized. Please process it manually.");
                return BadRequest(ModelState);
            }

            double? invoiceTotal = null;
            string invoiceNumber = null;
            DateTime? invoiceDate = null;

            // Extract the fields and put them into a structured form.
            // This is tedious if you ask me, so you'll have to write some
            // kind of wrapper and decide what your QA level is here.
            if (form.Fields.TryGetValue("InvoiceTotal", out var invoiceTotalField))
            {
                invoiceTotal = invoiceTotalField.Value.AsFloat();
            }

            if (form.Fields.TryGetValue("InvoiceId", out var invoiceIdField))
            {
                invoiceNumber = invoiceIdField.Value.AsString();
            }

            if (form.Fields.TryGetValue("InvoiceDate", out var invoiceDateField))
            {
                invoiceDate = invoiceDateField.Value.AsDate();
            }

            var invoice = Invoice.Create(new CreateInvoiceCommand(
                    Guid.NewGuid(), invoiceNumber ?? "",
                    invoiceDate ?? DateTime.UtcNow, invoiceTotal ?? 0.0));

            return Ok(invoice);
        }
    }
}