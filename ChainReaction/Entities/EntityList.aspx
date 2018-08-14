<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EntityList.aspx.cs" Inherits="Entities_EntityList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--    <h2 class="EntitiesLabel"> Entities </h2>--%>
    <style type="text/css">
        .watermark {
            color: Gray;
            background-color: #dddddd;
            font-size: smaller;
            font-style: italic;
        }
        .WidenHeader {
            padding: 5px;
        }

        .EntitiesLabel {
            text-align: center;
            font-weight: bold;
            margin-bottom: -10px;
        }

        .EntitesRadioButtons {
            margin: -15px;
        }

        input[type=radio] {
            margin: 0 10px 0 10px;
        }

        .EntitiesFooter td {
            border: none;
        }

        .EntitiesFooter th {
            border: none;
        }
        .FPNL td a:hover {
            text-decoration: none;
        }

        .FPNL td a:active {
            text-decoration: none;
        }

        .FPNL td a:visited {
            text-decoration: none;
        }

    </style>


    <div style="border-style: none; width: 100%; height: 25px; text-align: right;">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl="~/Entities/Companies.aspx" Visible="False">Edit</asp:HyperLink>
    </div>

    <div style="border-style: none; width: 100%; height: 30px; text-align: center;">
        
        <asp:TextBox ID="txtSearchEntity" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="btnSearchEntity" runat="server" Text="Search" OnClick="btnSearchEntity_Click" /><br />
        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
            TargetControlID="txtSearchEntity" WatermarkText="Search Entities" WatermarkCssClass="watermark" />

        &nbsp;&nbsp;<asp:Label ID="lblSearchResult" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="EntitesRadioButtons" >
        <asp:RadioButtonList ID="rblEntityPosition" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellSpacing="10"></asp:RadioButtonList>
            </div>
        <br />
    </div>

        <div style="border-style: none; width: 100%; height: 60px; ">

    </div>

    <div style="border-style: none; width: 100%; overflow: hidden;">

        <asp:GridView ID="gvDataGrid" runat="server" DataKeyNames="id" AutoGenerateColumns="False" CssClass="AddCellPadding"
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnRowCommand="GvDataGrid_RowCommand" OnRowDataBound="GvDataGrid_RowDataBound" OnDataBound="GvDataGrid_OnDataBound"
            OnPageIndexChanging="gvDataGrid_PageIndexChanging" PageSize="15" AllowPaging="True"  Width="100%" class="GVpager" ShowFooter="false" OnSelectedIndexChanged="gvDataGrid_SelectedIndexChanged" >
           <%-- <PagerSettings Mode="NextPreviousFirstLast" FirstPageText=" " PreviousPageText=""  NextPageText=" " LastPageText=" " />--%>
            <%--place this inside of gridview to keep a count of all of the pages. OnRowCreated="gvDataGrid_RowCreated"--%>
            


            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Image runat="server" ImageUrl='<%#  ReadLogoPath(Eval("id")) %>'
                            Width="90" />
                    </ItemTemplate>
                    <ItemStyle Width="100" VerticalAlign="Top"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div class="WidenHeader">
                        <asp:Label runat="server" Text='<%# ReadNameHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                            </div>
                    </HeaderTemplate>
                    <%--<HeaderStyle Width ="700" />--%>
                    <ItemTemplate>
                        <%--Hyperlinked Name--%>
                        <asp:Hyperlink Text='<%# Eval("Name") %>' runat="server"
                            NavigateUrl='<%# "~/Entities/Entity.aspx?EntityID=" + Eval("id") %>' Font-Size="Medium" ForeColor="#000099" Font-Bold="True"></asp:Hyperlink>

                        <asp:Label runat="server" Text='<%# ReadEntityBasic(Eval("DateFounded")) %>' Font-Size="X-Small"></asp:Label>
                        <br />
                        <asp:DataList runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" DataSource='<%# LoadEntityTypeList(Eval("id")) %>' RepeatColumns="3">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("Name") + ";" %>' Font-Size="X-Small" ForeColor="#996600" Font-Italic="True"></asp:Label>
                                <ItemStyle Width="500" VerticalAlign="Top"></ItemStyle>
                            </ItemTemplate>
                            <ItemStyle Width="100" VerticalAlign="Top"></ItemStyle>
                        </asp:DataList>
                        <asp:DataList runat="server" RepeatDirection="Vertical"
                            RepeatLayout="Flow" DataSource='<%# LoadWebLinkList(Eval("id")) %>' RepeatColumns="1">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# ReadWebLinkType(Eval("ID"))%>' Font-Size="X-Small" Font-Bold="True"></asp:Label>
                                <asp:HyperLink runat="server" Text='<%# ReadWebLink(Eval("ID")) %>' Target="_blank" NavigateUrl='<%# "http://" + ReadWebLink(Eval("ID")) %>' ForeColor="#0066FF" Font-Size="Small"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                    <ItemStyle Width="200" VerticalAlign="Top"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <div class="WidenHeader">
                        <asp:Label runat="server" Text='<%# ReadDescriptionHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                            </div>
                    </HeaderTemplate>
                    <HeaderStyle Width ="600" />    <%--This changes the width of "Description"--%>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# ReadOneLiner(Eval("OneLiner")) %>' Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="250" VerticalAlign="Top"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField >
                    <HeaderTemplate>
                        <div class="WidenHeader">
                        <asp:Label runat="server" Text='<%# ReadUseCaseHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                            </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:DataList runat="server" RepeatDirection="Vertical"
                            RepeatLayout="Flow" DataSource='<%# Load_BC_UseCase_List(Eval("id")) %>' RepeatColumns="1">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl='<%# "~/Blockchain/UseCaseListing.aspx?Level3_ID=" + Eval("Level3_ID") %>'>
                                <asp:Label runat="server" Text='<%# Read_BC_UseCase(Eval("Level1_ID"), Eval("Level2_ID"), Eval("Level3_ID")) %>' Font-Size="Smaller" Font-Bold="True"></asp:Label>
                                </asp:HyperLink>
                            </ItemTemplate>
                            <FooterTemplate>
                               
                            </FooterTemplate>
                        </asp:DataList>

                        <%--                                        <asp:DataList runat="server" RepeatDirection="Vertical"
                                            RepeatLayout="Flow" DataSource='<%# LoadAddressList(Eval("id")) %>' RepeatColumns="1">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# "Address: " + ReadAddress2(Eval("Address"), Eval("CountryID"), Eval("RegionID"), Eval("CityID"))%>' Font-Size="X-Small"></asp:Label>
                                            </ItemTemplate>
                                        </asp:DataList>--%>
                    </ItemTemplate>
                  
                    <ItemStyle VerticalAlign="Top"></ItemStyle>
                </asp:TemplateField>

                <%--                                <asp:TemplateField HeaderText="Contact">
                                    <ItemTemplate>
                                        <asp:DataList runat="server" RepeatDirection="Vertical"
                                            RepeatLayout="Flow" DataSource='<%# LoadPhoneList(Eval("id")) %>' RepeatColumns="1">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# ReadPhoneType(Eval("ID")) + " " + ReadCountryCode(Eval("ID")) + " " + ReadAreaCode(Eval("ID")) + " " + ReadPhoneNumber(Eval("ID"))%>' Font-Size="X-Small"></asp:Label>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <br />
                                        <asp:DataList runat="server" RepeatDirection="Vertical"
                                            RepeatLayout="Flow" DataSource='<%# LoadEmailList(Eval("id")) %>' RepeatColumns="1">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# "Email: " + ReadEmail(Eval("ID"))%>' Font-Size="X-Small"></asp:Label>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ItemTemplate>
                                    <ItemStyle Width="175" VerticalAlign="Top"></ItemStyle>
                                </asp:TemplateField>--%>


            </Columns>
            <PagerTemplate>
                <table style ="width: 100%" class="FPNL">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbFirst" runat="server" Text="first" CommandName="FirstButton"></asp:LinkButton>
                            <asp:LinkButton ID="lbPrevious" runat="server" CommandName="PreviousButton" Text="< previous &nbsp&nbsp"></asp:LinkButton>
                            <asp:LinkButton ID="lbNext" runat="server" Text=" next>" CommandName="NextButton"></asp:LinkButton>
                            <asp:LinkButton ID="lbLast" runat="server" Text="last>>" CommandName="LastButton"></asp:LinkButton>
                            <asp:Label ID="AddSpace" CommandName="testme" runat="server" Text="&nbsp&nbsp&nbsp&nbsp&nbsp"></asp:Label>
                            <asp:Label ID="PageCounter" runat="server" Text="Page x/xx"></asp:Label>
                        </td>
                    </tr>

                </table>
            </PagerTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#00547E" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
</asp:Content>

