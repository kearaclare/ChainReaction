<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Glossary.aspx.cs" Inherits="Glossary" %>--%>

<%@ Page Title="Blockchain Glossary" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Glossary.aspx.cs" Inherits="Glossary" ViewStateMode="Enabled" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<%--    <asp:RadioButtonList ID="rbl_BC_Language" runat="server" OnSelectedIndexChanged="rbl_BC_Language_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:ListItem Value="EN" Selected="True">English</asp:ListItem>
        <asp:ListItem Value="CN">中文</asp:ListItem>
    </asp:RadioButtonList>
    <asp:DropDownList ID="GlossaryType" runat="server" Width="200px" ></asp:DropDownList>--%>

<style>
    /*This styles the Glossary and applies ONLY when the selected language is Chinese*/

    .StyleGlossaryTextCHN {
        color: black;
        letter-spacing: 1px;
    }

    .AddChineseFont {
        font-family: 'Microsoft YaHei';
        color: black;
        letter-spacing: 1px;
    }

    .AddChineseFontC1 {
        font-family: 'Microsoft YaHei';
        color: #000066;
        letter-spacing: 1px;
    }

    .WidenHeader {
        padding: 5px;
    }
</style>
    

<div id="StylingGlossaryTop_CHN" runat="server">

    <table style="width: 100%" ID="GlossaryTable" >
        <tr >
            <td colspan="3" >
                <table style="width: 95%; text-align: center;" border="0" class="childTable">
                    <tr>
                        
                        <td style="text-align: center; width: 5%;"></td>
                        <td style="text-align: center; width: 90%;">
                            <h2>
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
                        </td>
                     
                        <td style="text-align: left; width: 5%;">
                            
                            <asp:HyperLink ID="edit" runat="server" NavigateUrl="Glossary_Edit" Target="_blank">Edit</asp:HyperLink>
                        </td>
                    </tr>
                    
                    <asp:PlaceHolder ID="phSearchResults" runat="server" Visible="False">
                        
                        <tr>
                            <td colspan="3" style="height: 5px"></td>
                        </tr>
                        <tr>
                            <td colspan="3">

                                <div style="padding: 15px; border: medium dotted #808080; height: 175px; width: 80%; text-align: left; margin-left: auto; margin-right: auto;">
                                    <asp:Label ID="lblHeader" runat="server" Text="" Font-Size="X-Large"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                                </div>

                            </td>
                        </tr>
                            
                    </asp:PlaceHolder>
                    <tr>
                        <td colspan="3" style="height: 5px">
                            
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="text-align: center; ">
                          <%-- <h4 style="color: #0c1c69 "> Filter terms by: </h4> --%>

                                         <%--Drop Down List starts here--%>

                            <%--<asp:DropDownList ID="rblGlossaryType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblGlossaryType_SelectedIndexChanged"></asp:DropDownList>--%>

                                         <%--  and ends here!--%>

                            <%--Uncomment this and Comment Drop Down list to revert to radio buttons--%>

                            <asp:RadioButtonList ID="rblGlossaryType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblGlossaryType_SelectedIndexChanged" Width="100%"></asp:RadioButtonList>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr >
            <td colspan="3" style="height: 15px"></td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: middle;">
                
                <asp:GridView ID="gvGlossary" runat="server" align="center" DataKeyNames="ID" Width="95%" AutoGenerateColumns="False" BackColor="White" BorderColor="lightgrey" BorderStyle="Solid" BorderWidth="2px" CssClass="AddCellPadding" OnRowDataBound="gvGlossary_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="300" ItemStyle-VerticalAlign="Top">
                            <HeaderTemplate>
                                <div class="WidenHeader">
                                <%--!! Doesn't have a Chinese name associated yet !!--%>
                                <asp:Label runat="server" Text="Term" Font-Size="Medium"></asp:Label>
                                    </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# ReadName(Eval("Name"), Eval("Name_CN")) %>' Font-Bold="True" Font-Size="Medium" />                                   
                            </ItemTemplate>

                            <ItemStyle VerticalAlign="Top" Width="300px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                            <HeaderTemplate>
                                <div class="WidenHeader">
                                <asp:Label runat="server" Text='<%# ReadDescriptionHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                                    </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# ReadDescription(Eval("Description"), Eval("Description_CN")) %>' />
                            </ItemTemplate>

                            <ItemStyle VerticalAlign="Top"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="200" ItemStyle-VerticalAlign="Top">
                            <HeaderTemplate>
                                <div class="WidenHeader">
                                <asp:Label runat="server"  Text='<%# ReadTypeHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                                    </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# ReadType(Eval("TypeName"), Eval("TypeName_CN")) %>' />

                            </ItemTemplate>

                            <ItemStyle VerticalAlign="Top" Width="200px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#00547E" Font-Bold="True" ForeColor="white"  />
                    <%--<HeaderStyle BackColor="black" Font-Bold="True" ForeColor="Aqua" />--%>
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>

            </td>


        </tr>
    </table>

</div>
</asp:Content>


