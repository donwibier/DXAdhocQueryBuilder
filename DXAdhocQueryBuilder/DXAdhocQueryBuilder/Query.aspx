<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="DXAdhocQueryBuilder.Query" %>

<%@ Register assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxQueryBuilder ID="ASPxQueryBuilder1" runat="server" OnSaveQuery="ASPxQueryBuilder1_SaveQuery">
        </dx:ASPxQueryBuilder>
    
    </div>
    </form>
</body>
</html>
