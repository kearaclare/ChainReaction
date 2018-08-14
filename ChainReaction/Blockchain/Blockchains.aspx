<%@ Page Title="Blockchain List" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Blockchains.aspx.cs" Inherits="Blockchains_Blockchains" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<%--    <asp:RadioButtonList ID="rbl_BC_Language" runat="server" OnSelectedIndexChanged="rbl_BC_Language_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:ListItem Value="EN" Selected="True">English</asp:ListItem>
        <asp:ListItem Value="CN">中文</asp:ListItem>

    </asp:RadioButtonList>--%>
<%--    <br/>
    <center>
    <h2><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
    </center>--%>
    

    <table style="width: 100%" >

        <tr >
            <td colspan="3" >
                <table style="width: 95%; text-align: center;" border="0">
                    <tr>
                        <td style="text-align: center; width: 5%;"></td>
                        <td style="text-align: center; width: 90%;">
                            <h2>
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
                        </td>
                        <td style="text-align: left; width: 5%;">
                            <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl="Blockchains_Edit" Target="_blank" Visible="False">Edit</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="text-align: center; ">
                            <asp:RadioButtonList ID="rblBlockchainType" runat="server" RepeatDirection="Horizontal" 
                                AutoPostBack="True"  RepeatLayout="Flow" CellSpacing="15" CellPadding="15"
                                 Enabled="True" OnSelectedIndexChanged="rblBlockchainType_SelectedIndexChanged"></asp:RadioButtonList>
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
            <td style="vertical-align: middle;">
                <asp:GridView ID="Blockchains_GV" runat="server" DataKeyNames="ID" align="center"
                    width="95%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <%--<asp:boundfield datafield="Symbol" headertext="Symbol"  />--%>
                        <asp:TemplateField ItemStyle-Width="200px" HeaderText=""  ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <%--displays the name of the blockchain--%>
                            <asp:Hyperlink Text='<%# ReadField(Eval("Name"), Eval("Name_CN")) %>' runat="server"
                            NavigateUrl='<%# "~/Blockchain/BlockchainList.aspx/" + ReadField(Eval("Name"), Eval("Name_CN")) %>' Font-Size="Medium" ForeColor="#000099" Font-Bold="True"></asp:Hyperlink>

<%--                            <asp:Hyperlink Text='<%# Eval("Name") %>' runat="server"
                            NavigateUrl='<%# "~/Entities/Entity.aspx?EntityID=" + Eval("id") %>' Font-Size="Medium" ForeColor="#000099" Font-Bold="True"></asp:Hyperlink>--%>



                                <%--<asp:Label runat="server" Text='<%# ReadField(Eval("Name"), Eval("Name_CN")) %>' Font-Bold="True" Font-Size="Medium" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="150" ItemStyle-VerticalAlign="Top">
                            <HeaderTemplate>
                               <%-- displays the concensus type header--%>
                                <asp:Label runat="server" Text='<%# ReadPosTypeHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                               <%-- displays the consensus type data--%>
                                <asp:Label runat="server" Text='<%#  ReadPosType(Eval("ConsensusType"), Eval("PosType")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                            <HeaderTemplate>
                                <asp:Label runat="server" Text='<%# ReadHashTypeHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#  ReadHash(Eval("HashType")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:boundfield datafield="Prog_Lang" headertext='<%# ReadProgramLangHeader(Eval("id")) %>'    ItemStyle-Width="200" />--%>
                        <asp:TemplateField ItemStyle-Width="200" ItemStyle-VerticalAlign="Top">
                            <HeaderTemplate>
                                <asp:Label runat="server" Text='<%# ReadProgramLangHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#  Eval("Prog_Lang") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField ItemStyle-Width="105" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right">
                            <HeaderTemplate>
                                <div style="text-align:right;">
                                    <asp:Label runat="server" Text='<%# ReadTPSHeader(Eval("id")) %>'  Font-Size="Medium" />
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#  Eval("Transactions_per_Second") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<HeaderStyle HorizontalAlign="Right" ></HeaderStyle>--%>
                        </asp:TemplateField>
                        
                        <asp:TemplateField ItemStyle-Width="220"  ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <div style="text-align:left;">
                                    <asp:Label runat="server" Text='<%# ReadBlockTimeHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#  ReadBlockInfo(Eval("Genesis"), Eval("BlockSize"), Eval("BlockTime")) %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Website" ItemStyle-VerticalAlign="Top">
                            <HeaderTemplate>
                                <asp:Label runat="server" Text='<%# ReadWebsiteHeader(Eval("id")) %>' Font-Size="Medium"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HyperLink Text='<%# GeneralClass.Truncate(Eval("Website").ToString(), 23) %>' runat="server" Target="_blank" NavigateUrl='<%# Eval("Website") %>' ForeColor="Blue" Font-Size="Small"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
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

</asp:Content>

