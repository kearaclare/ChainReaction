<%@ Page Title="Top Questions" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Questions.aspx.cs" Inherits="Questions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .FAQheader {
            font-size: 18px;
            font-weight: bold;
            text-align: center;
        }

        .FAQ a {
            text-decoration: none;
        }

        .FAQ td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
    </style>


    <br />

    <br />

    <table style="width: 100%; ">

        <tr>
            <td colspan="4">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 40px"></td>
                        <td style="font-family: Helvetica, Arial, sans-serif; font-weight: 500; line-height: 1.1; font-size: 30px; color: #333333; vertical-align: top; text-align: center; width: 300px; font-weight: bold;">Top Blockchain Questions</td>
                        <td style="width: 30px">
                            <asp:HyperLink ID="hlQuestionsEdit" runat="server" NavigateUrl="Questions_Edit" Visible="False">Edit</asp:HyperLink></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 50px;">
            <td colspan="3"></td>
            <th>&nbsp</th>

        </tr>
        <tr>

            <td style="vertical-align: top; width: 40%;">
                <asp:GridView ID="Ac1" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" OnSelectedIndexChanging="Questions_SelectedIndexChanging" ShowHeader="False" SelectedRowStyle-BackColor="#CCCCCC" BorderStyle="NotSet" CellPadding="8" CellSpacing="1" GridLines="None" OnSelectedIndexChanged="Ac1_SelectedIndexChanged" CssClass="FAQ">
                    <Columns>
                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="900px" ItemStyle-CssClass="FAQ">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandName="Select" Text='<%# ReadQuestion(Eval("Question"), Eval("Question_CN")) %>' Font-Size="Larger" Font-Bold="True" ForeColor="#0066CC" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width: 150px"></td>

            <td style="vertical-align: top;">
                <asp:PlaceHolder ID="phAnswer" runat="server" Visible="False">
                    <table style="width: 130%;">
                        <tr>
                            <td style="margin-right: -100px; margin-left: -100px; padding: 20px 50px 50px 20px; vertical-align: top; width:50%; background-color: #EBECEF;">
                                <%--<asp:Label ID="FAQheader" runat="server" Text="Answer: " CssClass="FAQheader"></asp:Label><br />--%>
                                <asp:Label ID="FAQheader" runat="server" Text=" " CssClass="FAQheader"></asp:Label><br />
                                <asp:Label ID="Answer" runat="server" Text="" Font-Size="Larger"></asp:Label>
                                <br />

                            </td>

                        </tr>
                        <tr style="height: 20px;"></tr>
                        <tr style="height: 10px;">
                            <td>
                                <asp:Label ID="lblReadMore" runat="server" Text=" " Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </td>

                        </tr>
                         <tr style="height: 10px;"></tr>
                        <tr>
                            <td>
                                <br />
                                <asp:DataList ID="gvWebLink" runat="server" RepeatDirection="Vertical"
                                    RepeatLayout="Flow" RepeatColumns="1">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" Text='<%# ReadWebLink(Eval("ID"), Eval("WebLink")) %>' Target="_blank" NavigateUrl='<%#  ReadWebLink(Eval("ID"),Eval("WebLink") ) %>' ForeColor="#0066FF" Font-Size="Medium"></asp:HyperLink>
                                        <br />
                                        <asp:Label runat="server" Text='<%# ReadWebLink(Eval("ID"), Eval("Description")) %>' Target="_blank" Font-Size="Medium"></asp:Label>
                                        <br />
                                        <asp:Label runat="server" Text='<%# ReadWebLink(Eval("ID"), Eval("Description_CN")) %>' Target="_blank" Font-Size="Medium"></asp:Label>


                                    </ItemTemplate>
                                </asp:DataList></td>
                        </tr>
                    </table>
                </asp:PlaceHolder>
            </td>
            <td style="width: 150px"></td>
        </tr>
    </table>
    <br />
    <br />
    <asp:RadioButtonList ID="rbl_BC_Language" runat="server" OnSelectedIndexChanged="rbl_BC_Language_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:ListItem Value="EN" Selected="True">English</asp:ListItem>
        <asp:ListItem Value="CN">中文</asp:ListItem>

    </asp:RadioButtonList>
</asp:Content>


