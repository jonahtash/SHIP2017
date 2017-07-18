<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SHIPSite.WebForm3" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <script type="text/javascript">
    function button_click(objTextBox,objBtnID){
        if(window.event.keyCode==13)
        {
            document.getElementById(objBtnID).focus();
            document.getElementById(objBtnID).click();
            return;
        }
       if (document.getElementById('<%= SearchText.ClientID%>').value.length > 0) {
           document.getElementById('<%=Submit.ClientID%>').disabled = false;
       } else {
            document.getElementById('<%=Submit.ClientID%>').disabled = true;
       }

    }

    function searchText_click() {
        if (document.getElementById('<%= SearchText.ClientID%>' ).value.includes("Search...")) {
            document.getElementById('<%= SearchText.ClientID%>').value="";
        }
    }
    </script>
    <style>
        .padding {padding:.5em;}
        .padding:focus{ outline: none;}
        .SubmitButton:focus{outline: none;}
    </style>        
    <div aria-orientation="vertical" style="height: 491px; text-align: center; margin: 0 auto; clip: rect(auto, 0px, auto, auto);">
                <div style="position: relative; top: 50%;">
            <asp:TextBox ID="SearchText" runat="server" Height="30px" Width="309px"  CssClass="padding" AutoPostback="False" OnClick="searchText_click()">Search...</asp:TextBox>

                    <asp:Button ID="Submit" runat="server" BackColor="#0099FF" BorderStyle="None" Height="31px" Text="Go" Width="61px" onclick="Submit_Click" CssClass="SubmitButton"/>

                </div>
            </div>

</asp:Content>


