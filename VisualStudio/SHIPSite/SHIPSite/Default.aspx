<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SHIPSite.WebForm3" MasterPageFile="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit" TagPrefix="ajaxTookit" %>
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
        .padding {padding:.5em; font-family:HelvLight; font-size:18px; width:500px;min-width:400px;}
        .padding:focus{ outline: none;}
        .SubmitButton{min-width:65px;}
        .SubmitButton:focus{outline: none;}
        .drop{
            font-family:HelvLight;
            background-color:white;
            font-size:14px;
            padding-bottom:.5em;
        }
        .drop_highlight{
            background-color:#5381cc;
            color:white;
            font-family:HelvLight;
            padding-bottom:.5em;
            font-size:14px;
        }
    </style>        
    <div aria-orientation="vertical" style="height: 491px; text-align: center; margin: 0 auto; clip: rect(auto, 0px, auto, auto);">
                <div style="position: relative; top: 50%; display:inline-flex">
            <asp:TextBox ID="SearchText" runat="server" Height="50px" CssClass="padding" AutoPostback="False" OnClick="searchText_click()">Search...</asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender 
    runat="server" 
    ID="autoComplete1" 
    TargetControlID="SearchText"
    ServiceMethod="GetCompletionList"
    ServicePath="AutoComplete.asmx"
    MinimumPrefixLength="1" 
    CompletionInterval="250"
    EnableCaching="true"
    CompletionSetCount="10" 
    ShowOnlyCurrentWordInCompletionListItem="true" CompletionListItemCssClass="drop" CompletionListHighlightedItemCssClass="drop_highlight" >
</ajaxToolkit:AutoCompleteExtender>
                    <asp:Button ID="Submit" runat="server" BackColor="#0099FF" BorderStyle="None" Height="50px" Text="Go" Width="65px" onclick="Submit_Click" CssClass="SubmitButton"/>

                </div>
            </div>

</asp:Content>


