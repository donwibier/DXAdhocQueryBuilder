<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cards.aspx.cs" Inherits="DXAdhocQueryBuilder.Cards" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [Id], [Title], [FirstName], [LastName], [FullName], [HomePhone], [MobilePhone], [Email] FROM [Employees]"></asp:SqlDataSource>
        <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Query Builder">
        </dx:ASPxButton>
        <dx:ASPxCardView ID="ASPxCardView1" runat="server" DataSourceID="SqlDataSource1" OnDataBinding="ASPxCardView1_DataBinding">
            <Settings ShowHeaderPanel="True" />
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            <SettingsSearchPanel Visible="True" />
        </dx:ASPxCardView>
    </div>
    </form>
</body>
</html>
