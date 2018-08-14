<%@ Page Title="Entity Detail" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Entity.aspx.cs" Inherits="Entities_Entity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    <br/><br/><br/>

    <asp:Image ID="imgEntityLogo" runat="server" />

    <br/><br/>

   &nbsp;&nbsp;<asp:Label ID="lblEntityName" runat="server" Font-Size="X-Large" ForeColor="#000066"></asp:Label>

    <br/>

    &nbsp;&nbsp;<%--<asp:HyperLink ID="hlWebsite" runat="server" Target="_blank">www.google.com</asp:HyperLink>--%>

    <asp:DataList ID="dlWebLinks" runat="server" RepeatDirection="Vertical"
        RepeatLayout="Table"  RepeatColumns="1">
        <ItemTemplate>
            <asp:Label runat="server" Text='<%# ReadWebLinkType(Eval("ID"))%>' Font-Size="X-Small" Font-Bold="True"></asp:Label>
            <asp:HyperLink runat="server" Text='<%# ReadWebLink(Eval("ID")) %>' Target="_blank" NavigateUrl='<%# "http://" + ReadWebLink(Eval("ID")) %>' ForeColor="#0066FF" Font-Size="Smaller"></asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>

    <br/><br/>
    &nbsp;&nbsp;<asp:Label ID="lblOneLiner" runat="server" Font-Size="Medium" ></asp:Label>

    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
</asp:Content>

