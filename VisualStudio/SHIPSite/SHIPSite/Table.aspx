<%@ Page Title="Table" Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" MasterPageFile="~/Site.Master" Inherits="SHIPSite.WebForm2" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 800; height: 80%;word-wrap: break-word;">
    <asp:GridView ID="table" runat="server" SelectMethod="GetTable"
        ItemType="SHIPSite.Row" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" Height="500px" HorizontalAlign="Center" OnSelectedIndexChanged="table_SelectedIndexChanged" Width="800px">
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <RowStyle BorderStyle="Ridge" HorizontalAlign="Justify" Width="100px" Wrap="True" Height="100px" VerticalAlign="Middle" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView></div></asp:Content>
