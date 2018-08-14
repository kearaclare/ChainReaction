<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .watermark {
            color: Gray;
            background-color: #dddddd;
            font-size: smaller;
            font-style: italic;
        }
        .DefaultPage td {
            padding-right: 10px;
        }
        .UseCaseIcons th, td {
            padding: 5px;
        }
    </style>


    <table style="width: 100%;" border="0">
        <tr>
            <td colspan="2" style="height: 20px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 30%; vertical-align: top;">
                <div style="text-align: center;">

                    <asp:Label ID="lblGlossary" runat="server" Text="Top Blockchain Vocabulary" Font-Size="Larger" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:ListView ID="lvGlossary" runat="server">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/Listing/Glossary/Glossary.aspx?id=" + Eval("id") %>'>
                                    <asp:Label runat="server"
                                        Text='<%# ReadGlossary(Eval("Name"), Eval("Name_CN")) %>' BackColor="#dddddd" Font-Underline="False" Font-Bold="False" ForeColor="Black" Font-Size="Medium" />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:ListView>
                    <br />
                    <br />
                    <asp:TextBox ID="txtSearchGlossary" runat="server" Width="225px"></asp:TextBox>
                    <asp:Button ID="btnSearchGlossary" runat="server" Text="Search" OnClick="btnSearchGlossary_Click" />
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                        TargetControlID="txtSearchGlossary" WatermarkText="Search Glossary" WatermarkCssClass="watermark" />
                </div>
                <br />
                <br />
                <br />
                <div style="text-align: center;">

                    <asp:Label ID="lblPeople" runat="server" Text="Blockchain People" Font-Size="Larger" Font-Bold="True" />
                    <br />
                    <br />
                    <asp:DataList runat="server" ID="dlPeople"
                        RepeatDirection="Horizontal" RepeatLayout="Table" RepeatColumns="3"
                        CellSpacing="1" CellPadding="1" GridLines="None" Width="95%" HorizontalAlign="Center">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <table style="width: 100%;" border="0">
                                <tr>
                                    <td style="text-align: center; vertical-align: middle; height: 75px; width: 75px;">
                                        <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# "~/People/Person.aspx?PersonID=" + Eval("id") %>'>
                                        <asp:Image runat="server" ImageUrl='<%#  ReadImagePath(Eval("id")) %>'
                                        Width='<%# SetImageWidth(Eval("id")) %>' />
                                        </asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="height: 5px"></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Label runat="server" Text='<%# ReadFullName(Eval("FirstName"), Eval("LastName"), Eval("AkaName"), Eval("FirstName_CN"), Eval("LastName_CN"), Eval("AkaName_CN")) %>' Font-Size="Small"></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </td>
            <td style="vertical-align: top">
                <table style="width: 100%;" border="0" class="DefaultPage">
                    <tr>
                        <td style="text-align: center; height: 90px; vertical-align: middle;">

                            <div style="margin: 0 auto; width: 95%; height: 100%; background-color: #C0C0C0;">
                                <br />
                                <asp:Label ID="lblBanner" runat="server" Text="Top Banner" Font-Size="X-Large" ForeColor="#333333"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">&nbsp;</td>
                    </tr>
                 <%--   This is where it is!--%>
                    <tr>
                        <td>
                            <div style="border-style: none; width: 50%; float: left; overflow: hidden;">
                                <div style="clip: rect(20px, auto, auto, auto); text-align: center; width: 100%;">
                                    <asp:Label ID="lblLastestStartups" runat="server" Text="Disruptors of The Week" Font-Size="Larger" Font-Bold="True" />
                                    <br />
                                    <br />
                                    <asp:DataList ID="dlLastestStartups" runat="server" align="center" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="5" CellSpacing="20" CellPadding="10">
                                        <EditItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# ReadUrlPath(Eval("EntityID")) %>' 
                                                ToolTip='<%#  ReadEntityName2(Eval("EntityID"), Eval("Name"), Eval("Name_CN"), Eval("OneLiner"), Eval("OneLiner_CN")) %>'>
                                                  <asp:Image runat="server" ImageUrl='<%# ReadLogoPath2(Eval("EntityID"), Eval("FileExtension"), Eval("LogoType")) %>' Width="50" />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                                <br />
                                <br />
                                <div style="text-align: center;">
                                    <asp:Label ID="lblLatestUseCase" runat="server" Text="Latest Blockchain Use Cases" Font-Size="Larger" Font-Bold="True" />
                                    <br />
                                    <br />
                                    <asp:DataList ID="dlUseCasesLatest" runat="server" DataKeyField="id"
                                        RepeatDirection="Vertical" RepeatLayout="Table"
                                        RepeatColumns="1" CellSpacing="1" CellPadding="1"
                                        HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" Width="90%">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# "~/Blockchain/UseCaseListing.aspx?Level3_ID=" + Eval("ID") %>'>
                                            <asp:Label runat="server" Text='<%#  ReadUseCases(Eval("Name"), Eval("Name_CN"), Eval("ID"), Eval("Level1_ID"), Eval("Level2_ID")) %>'></asp:Label>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                            <div style="border-style: none; overflow: hidden;">
                                <div style="text-align: center;">
                                    <asp:Label ID="lblQuestions" runat="server" Text="Top Blockchain Questions" Font-Size="Larger" Font-Bold="True"></asp:Label><br />
                                    <br />
                                    <asp:DataList ID="dlQuestions" runat="server" DataKeyField="id"
                                        RepeatDirection="Vertical" RepeatLayout="Table"
                                        RepeatColumns="1" CellSpacing="1" CellPadding="5"
                                        HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" Width="90%">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Listing/Questions/Questions.aspx?QuestionID=" + Eval("ID") %>' Text='<%#  ReadQuestions(Eval("Question"), Eval("Question_CN")) %>' Font-Size="Medium" Font-Bold="True" />
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                                <br />
                                <div style="border: thin dotted #00FF00; text-align: center; margin: 0 auto; width: 95%; vertical-align: middle; background-color: #333333;">
                                    <br />
                                    <asp:LinkButton ID="btnUnderstandBlockchain" runat="server" Text="Understand Blockchain in 3 Minutes" ForeColor="#CCCCCC" Font-Size="XX-Large" Width="80%" OnClick="btnUnderstandBlockchain_Click" /><br />
                                    <br />
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Blockchain Essentials" Visible="False"></asp:Label></td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 15px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
