<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingGoogleControl.aspx.cs" Inherits="EmbeddedGoogleDocs.UsingGoogleControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="Styles/default.css" />
</head>
<body>
    <form runat="server">        
        <Doc:GoogleDocWrapperControl runat="server" DocName="Roboguice" />
    </form>
</body>
</html>
