<%@ Page Title="People" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="SHIPSite.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%: Title %>.</h1>
        <h2>A list of people</h2>
        <div id="PersonMenu" style="text-align: center">       
        <asp:GridView ID="grdEmployee" runat="server" SelectMethod="GetPeople"
        ItemType="SHIPSite.Models.Person">
        </asp:GridView>
        </div>
</asp:Content>