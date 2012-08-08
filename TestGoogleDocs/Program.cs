using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Client;
using Google.GData.Documents;

namespace TestGoogleDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "devandanger@gmail.com";
            string password = "**********";

            DocumentsService service = new DocumentsService("MyDocumentsListIntegration-v1");
            service.setUserCredentials(username, password);

            //DocumentsListQuery query = new DocumentsListQuery();
            TextDocumentQuery query = new TextDocumentQuery();

            // Make a request to the API and get all documents.
            DocumentsFeed feed = service.Query(query);

            // Iterate through all of the documents returned
            foreach (DocumentEntry entry in feed.Entries)
            {
                if (entry.Title.Text == "Rufo-Resume.doc")
                {
                    // Print the title of this document to the screen
                    Console.WriteLine(entry.Title.Text);
                    var stream = service.Query(new Uri(entry.Content.Src.ToString()));
                    var reader = new StreamReader(stream);
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
