<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SHIPSite.WebForm4"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="MainContent" runat="server" contentplaceholderid="MainContent">

    <style>
    table {
     table-layout:fixed;
    }

    td {
        word-wrap: break-word !important; white-space: normal !important;
    }

    </style>


    <div style="height: 506px">
    <div style="position: relative; top: 50%; text-align: center; left: -7px;">
        <asp:GridView ID="GridView1" runat="server" SelectMethod="GetRows"
        ItemType="SHIPSite.Row" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" OnRowDataBound="GridView1_RowDataBound">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"/>
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</div>









</asp:Content>