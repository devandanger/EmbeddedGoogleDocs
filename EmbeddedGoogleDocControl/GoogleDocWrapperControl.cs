using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Google.GData.Client;
using Google.GData.Documents;
using System.Security.Permissions;
using System.Web.UI;

namespace EmbeddedGoogleDocControl
{
    //[
    //    AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal),
    //    AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal),
    //    ToolboxData("<{0}:GoogleDocWrapperControl runat=\"server\"> </{0}:GoogleDocWrapperControl>")
    //]

    public class GoogleDocWrapperControl : Control
    {
        private string docName;
        [
        Bindable(true),
        Description("The Google Doc to be wrapped")
        ]
        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(this.DocName))
            {
                base.Render(writer);
                return;
            }
            string username = "***************";
            string password = "***********";

            DocumentsService service = new DocumentsService("MyDocumentsListIntegration-v1");
            service.setUserCredentials(username, password);

            //DocumentsListQuery query = new DocumentsListQuery();
            TextDocumentQuery query = new TextDocumentQuery();

            // Make a request to the API and get all documents.
            DocumentsFeed feed = service.Query(query);

            // Iterate through all of the documents returned
            foreach (DocumentEntry entry in feed.Entries)
            {
                if (entry.Title.Text == this.DocName)
                {
                    writer.Write("<div class='gdoc'>");
                    Stream stream = service.Query(new Uri(entry.Content.Src.ToString()));
                    StreamReader reader = new StreamReader(stream);
                    writer.Write(reader.ReadToEnd());
                    writer.Write("</div>");
                    break;
                }
            }

            base.Render(writer);
        }
    }
}
