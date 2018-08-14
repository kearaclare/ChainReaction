<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BlockchainList.aspx.cs" Inherits="Blockchain_BlockchainList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <style>
/*Sets the width of and places the div that encompasses the logo, header, short and long description*/
        .BCHeaderAndDescription {
            width: 550px;
            float: left;
            margin-top: 100px;
        }

/*Adds an underline to the Logo, header, and description*/
        .BC_LHD {
            display: inline-block;
            border-bottom: solid;
            border-bottom-color: lightsteelblue;
            padding: 10px;
        }
/*Styles the table column names*/
        .BC_TH {
            font-weight: bold;
            width: 150px;
        }
/*Adds a border around the table*/
        .leftTable td {
            border: 1px solid deepskyblue;
            padding: 5px;
        }

        .rightTable {
            margin-left: -5px;
        }

        .rightTable td {
            border: 1px solid deepskyblue;
            padding: 5px;
        }

/*uncomment the following to alternate the background color of the chart*/
        
        /*.leftTable tr:nth-child(odd) {
            background-color: #4c8bf5;
        }

        .rightTable tr:nth-child(odd) {
            background-color: #4c8bf5;
        }*/
        

    </style>
    
    <br />
<%--Template for LHD (Logo, Header, Description)--%>
    <div class="BC_LHD">
        <img src="~/images/bc.png" runat="server" style="float: left;" />

        <div class="BCHeaderAndDescription">
            <asp:Label ID="BC_CompanyName" runat="server" Text="Bitcoin" Font-Size="24px" Font-Bold="True"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Descrion placeholder" ForeColor="gray"></asp:Label><br />
            <asp:Label ID="BC_CompanyDescription" runat="server" Text="This company is a cryptocurrency, which is a digital asset designed to work as a medium of exchange 
        using cryptography to secure the transactions and to control the creation of additional units of the currency."></asp:Label><br />
        </div>
    </div>


    <table>
        <%--        <tr>
            <td>
                <div class="BC_LHD">
                    <img src="~/images/bc.png" runat="server" style="float: left;" />

                    <div class="BCHeaderAndDescription">
                        <asp:Label ID="BC_CompanyName" runat="server" Text="Bitcoin" Font-Size="24px" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="BC_CompanyDescription" runat="server" Text="This company is a cryptocurrency, which is a digital asset designed to work as a medium of exchange 
                        using cryptography to secure the transactions and to control the creation of additional units of the currency."></asp:Label>
                    </div>
                </div>
            </td>
            </tr>--%>

        <tr>
            <td>
                <%-- Entire Blockchain Table starts here--%>
                <table runat="server" style="width: 800px;" class="BCHyperlinkTable">
                    <tr>
                        <td>
                            <%--Left half of the table starts here--%>
                            <table class="leftTable">
                                <tr>
                                    <td runat="server" class="BC_TH">
                                        <asp:Label ID="Label13" runat="server" Text="Symbol"></asp:Label>
                                    </td>
                                    <td runat="server" style="width: 250px;">
                                        <asp:Label ID="Label14" runat="server" Text="SName"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="ConsensusType" class="BC_TH"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="CTName"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Hash Type" class="BC_TH"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="HTName"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <%--Left half of the table ends here--%>
                        </td>
                        <td>
                            <%--Right half of the table starts here--%>
                            <table class="rightTable">
                                <tr>
                                    <td runat="server" style="width: 150px;" class="BC_TH">
                                        <asp:Label ID="Label19" runat="server" Text="Hash Type"></asp:Label>
                                    </td>
                                    <td runat="server" style="width: 250px;">
                                        <asp:Label ID="Label20" runat="server" Text="Sha 256"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" class="BC_TH" runat="server" Text="TPS"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label22" runat="server" Text="7"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" class="BC_TH" Text="ATFBC"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="10 minutes"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <%--Right half of the table ends here--%>
                        </td>
                    </tr>
                </table>
                <%--  Entire Blockchain Table ends here--%>
            </td>
            <td style="width: 150px"></td>
            <td>
                <table style="width: 100%; margin-top: -200px; height: 350px; width: 250px;">
                    <tr>
                        <td style="margin-right: -200px; margin-left: -200px; margin-top: -500px; vertical-align: top; background-color: #EBECEF;">
                            <asp:Label ID="Advertisements" runat="server" Text="Advertisements Placeholder"></asp:Label><br />
                            <br />

                        </td>

                    </tr>
                </table>
            </td>
        </tr>
    </table>

    
</asp:Content>
