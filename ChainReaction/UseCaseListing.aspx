<%@ Page Title="Use Case Listing" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UseCaseListing.aspx.cs" Inherits="Blockchain_UseCaseListing" %>

<%--<%@ OutputCache Duration="60" VaryByParam="None" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <style type="text/css">
        fieldset {
            border: medium none;
        }

        .fieldset {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 2px dashed #000000;
            font-size: 90%;
            padding: 1.5em 1em 0.5em 1em;
            position: relative;
            width: 23em;
        }

        legend span {
            color: #000000;
            font-weight: bold;
            left: 1em;
            position: absolute;
            text-align: center;
            border-bottom: none;
            top: 0.5em;
            /*width: 15em;*/
        }

        .two legend span {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 0;
            left: 1em;
            padding: 0 0.2em;
            top: -0.75em;
        }

        .fieldset.two {
            padding-top: 1.5em;
        }

    </style>




    <div style="border-style: none; width: 100%; height: 30px; text-align: right;">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl="~/Blockchain/EditUseCases.aspx" Target="_blank" Visible="False">Edit</asp:HyperLink>
    </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div style="border-style: none; width: 100%;  overflow:hidden;">


                <div style="border-width: thin; border-style: none; width: 270px; float: left; overflow: hidden;">
                    
                    <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="3000" />
                    <asp:UpdatePanel ID="StockPricePanel" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" />
                        </Triggers>
                        <ContentTemplate>
                    <asp:PlaceHolder ID="phStart" runat="server" Visible="False">
                        <div style="width: 150px; height: 0px; border-style: none; border-width: thin; position: relative; top: 0px; float: right;">

                            <br />
                            <br />
                            &nbsp;&nbsp;
                                <asp:Image ID="imgLeftArrow" runat="server" ImageUrl="~/App_Themes/Default/left_arrow.gif" Height="35" Width="80" />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblStartHere" runat="server" Text="Start Here" Font-Size="Large" Font-Bold="True" ForeColor="#666666" Font-Italic="True" Font-Names="Calibri"></asp:Label>
                        </div>
                    </asp:PlaceHolder>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:ListBox ID="lb_xxxUseCase_BC_Level1xxx" runat="server" AutoPostBack="True"
                        Rows="6" Width="250px" OnSelectedIndexChanged="lb_xxxUseCase_BC_Level1xxx_SelectedIndexChanged" Font-Size="X-Large" Font-Bold="True"></asp:ListBox>
                    <br />
                    <br />
                    <asp:ListBox ID="lb_xxxUseCase_BC_Level2xxx" runat="server" AutoPostBack="True"
                        Rows="10" Width="250px" OnSelectedIndexChanged="lb_xxxUseCase_BC_Level2xxx_SelectedIndexChanged" Font-Size="Larger" Visible="True"></asp:ListBox>
                    <br />
                    <br />
                    <asp:ListBox ID="lb_xxxUseCase_BC_Level3xxx" runat="server" AutoPostBack="True"
                        Rows="10" Width="250px" OnSelectedIndexChanged="lb_xxxUseCase_BC_Level3xxx_SelectedIndexChanged" Font-Size="Larger" Visible="True"></asp:ListBox>

                </div>



        <div style="border-width: thin; border-style: none; overflow: hidden;">


            <br/>

<%--            <asp:PlaceHolder ID="phAllUseCases" runat="server" Visible="False">
                <uc1:WUC_All_UseCases ID="WUC_All_UseCases1" runat="server" />
            </asp:PlaceHolder>--%>

            <asp:DataList ID="dlUseCases" runat="server" align="center" RepeatDirection="Horizontal"
                RepeatLayout="Table" RepeatColumns="3" Width="100%" DataKeyField="id" CellSpacing="5" CellPadding="5">
                <ItemTemplate>

                    <div class="fieldset two" style="border: 2px dashed #808080;">
                        <fieldset>
                            <legend style="border-style: none; width: 90px;">
                                <asp:Label runat="server" Text='<%# ReadLevelName(Eval("Name"), Eval("Name_CN"))%>' Font-Size="16px" Font-Bold="True"></asp:Label>
                            </legend>
                            <asp:DataList runat="server" DataSource='<%# LoadUseCase_BC_Level2(Eval("id")) %>'
                                RepeatDirection="Vertical" RepeatLayout="Flow" RepeatColumns="1" CellSpacing="10" CellPadding="10">
                                <ItemTemplate>
                                    <div class="fieldset two" style="border-style: dotted; border-width: thin">
                                        <fieldset>
                                            <legend style="border-style: none">
                                                <asp:Label runat="server" Text='<%# ReadLevelName(Eval("Name"), Eval("Name_CN"))%>' Font-Size="Small" Font-Bold="True"></asp:Label>
                                            </legend>
                                            <asp:DataList runat="server" align="center" DataSource='<%# LoadLevel2EntityList(Eval("id")) %>'
                                                RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="4" CellSpacing="2" CellPadding="2">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# ReadUrlPath(Eval("EntityID")) %>' 
                                                        ToolTip='<%#  ReadEntityName2(Eval("EntityID"), Eval("Name"), Eval("Name_CN"), Eval("OneLiner"), Eval("OneLiner_CN")) %>'>
                                                        <asp:Image runat="server" ImageUrl='<%#  ReadLogoPath2(Eval("EntityID"), Eval("FileExtension"), Eval("LogoType")) %>' Width="50" />
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <br />
                                        </fieldset>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            <br />
                            <br />
                        </fieldset>
                    </div>


                    <br />
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:DataList>


            <asp:DataList ID="dlUseCasesLevel2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" 
                RepeatColumns="3" CellSpacing="15" CellPadding="5" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <div class="fieldset two" style="border-style: dotted; border-width: thin; ">
                        <fieldset>
                            <legend style="border-style: none">
                                <asp:Label runat="server" Text='<%# ReadLevelName(Eval("Name"), Eval("Name_CN")) %>' Font-Size="Small" Font-Bold="True"></asp:Label>
                            </legend>

                            <table class="UseCaseIcons">
                                <tr>
                                    <td>
                            <asp:DataList runat="server" align="center" DataSource='<%# LoadLevel2EntityList(Eval("id")) %>'
                                RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="4" CellSpacing="5" CellPadding="5">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# ReadUrlPath(Eval("EntityID")) %>' 
                                        ToolTip='<%#  ReadEntityName2(Eval("EntityID"), Eval("Name"), Eval("Name_CN"), Eval("OneLiner"), Eval("OneLiner_CN")) %>'>
                                                        <asp:Image runat="server" 
                                                            ImageUrl='<%#  ReadLogoPath2(Eval("EntityID"), Eval("FileExtension"), Eval("LogoType")) %>' Width="50"  />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>

                            <br />
                        </fieldset>
                    </div>
                </ItemTemplate>
            </asp:DataList>




            <asp:PlaceHolder ID="phLevel2NoLevel3" runat="server" Visible="False">
            <table style="width: 100%;">
                <tr>
                    
                    <td>
                        <div class="fieldset two" style="border-style: dotted; border-width: thin; width: 99%; position: relative; left: 3px;">
                            <fieldset>

                                <asp:DataList ID="dlShowEntitiesNoLevel3" runat="server" align="left" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="10" CellSpacing="20" CellPadding="10">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# ReadUrlPath(Eval("EntityID")) %>' 
                                            ToolTip='<%#  ReadEntityName2(Eval("EntityID"), Eval("Name"), Eval("Name_CN"), Eval("OneLiner"), Eval("OneLiner_CN")) %>'>
                                                        <asp:Image runat="server" 
                                                            ImageUrl='<%#  ReadLogoPath2(Eval("EntityID"), Eval("FileExtension"), Eval("LogoType")) %>' Width="50" />
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:DataList>
                                
                            </fieldset>
                        </div>
                    </td>
                </tr>
            </table>
            <br/>
            </asp:PlaceHolder>

            <asp:DataList ID="dlShowEntities" runat="server" align="center" Width="100%" 
                RepeatDirection="Horizontal" RepeatLayout="Table" RepeatColumns="3" CellSpacing="5" CellPadding="5" ItemStyle-VerticalAlign="Top" ItemStyle-Width="285px">
                <ItemTemplate>
                    <div class="fieldset two" style="border-style: dotted; border-width: thin; width: 100%;">
                        <fieldset>
                            <legend style="border-style: none">
                                <asp:Label runat="server" Text='<%# ReadLevelName(Eval("Name"), Eval("Name_CN")) %>' Font-Size="Small" Font-Bold="True"></asp:Label>
                            </legend>
                            <asp:DataList runat="server" align="center" DataSource='<%# LoadLevel3EntityList(Eval("id")) %>' 
                                RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="4" CellSpacing="5" CellPadding="5" Width="100%">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" Target="_blank" 
                                        NavigateUrl='<%# ReadUrlPath(Eval("EntityID")) %>' 
                                        ToolTip='<%#  ReadEntityName2(Eval("EntityID"), Eval("Name"), Eval("Name_CN"), Eval("OneLiner"), Eval("OneLiner_CN")) %>'>
                                           <asp:Image runat="server" 
                                               ImageUrl='<%#  ReadLogoPath2(Eval("EntityID"), Eval("FileExtension"), Eval("LogoType")) %>' Width="50" />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:DataList>
                            
                        </fieldset>
                    </div>
                </ItemTemplate>
            </asp:DataList>




            <asp:DataList ID="dlOnlyLevel3" runat="server" align="left" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="1" CellSpacing="20" CellPadding="10">
                <ItemTemplate>
                    <table style="width: 100%;" border="0">
                        <tr>
                            <td style="width: 5px"></td>
                            <td style="vertical-align: top; width: 130px; text-align: left;">
                               
                                <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# ReadUrlPath(Eval("EntityID")) %>' >
                               <asp:Image runat="server" ImageUrl='<%#  ReadLogoPath2(Eval("EntityID"), Eval("FileExtension"), Eval("LogoType")) %>' Width="120" ImageAlign="NotSet" BorderStyle="None" />
                                </asp:HyperLink>
                                 
                            </td>
                            <td style="width: 15px"></td>
                            <td style="vertical-align: top">
                                <table style="width: 90%;" border="0">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text='<%#  ReadEntityNameOnly(Eval("EntityID")) %>' Font-Size="X-Large" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList runat="server" RepeatDirection="Vertical"
                                                RepeatLayout="Flow" DataSource='<%# LoadWebLinkList(Eval("EntityID")) %>' RepeatColumns="1">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# ReadWebLinkType(Eval("ID"))%>' Font-Size="Small" Font-Bold="True"></asp:Label>
                                                    <asp:HyperLink runat="server" Text='<%# ReadWebLink(Eval("ID")) %>' Target="_blank" NavigateUrl='<%# "http://" + ReadWebLink(Eval("ID")) %>' ForeColor="#0066FF" Font-Size="Medium"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text='<%#  ReadEntityOneLinerOnly(Eval("EntityID")) %>' Font-Size="Medium"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                </ItemTemplate>
            </asp:DataList>




        </div>

    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    <br/><br/>
</asp:Content>

