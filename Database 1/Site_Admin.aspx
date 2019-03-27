<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Site_Admin.aspx.vb" Inherits="Database_1.Site_Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <p style="font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: black; font-size: 24px;">DATA LOAD</p>

    <table style="border-top: solid">
        <tr>
            <td>
                <p style="font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: black; font-size: 18px;">Current Sales Period:</p>
            </td>
            <td>
                <p style="font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: black; font-size: 18px;">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <p style="font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: black; font-size: 18px;">Reset to</p>
            </td>
            <td>
                <p style="font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: black; font-size: 18px;">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" BackColor="#843c0c" BorderColor="#843C0C" BorderStyle="None" Font-Size="Medium" ForeColor="White" OnClientClick="return confirm('Please confirm');" Text="RESET" Width="100px" />
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <p style="font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: black; font-size: 18px;">Load Non-EDI Data for</p>
            </td>
            <td>
                <p style="font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: black; font-size: 18px;">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></p>
            </td>
            <td>
                <asp:Button ID="Button5" runat="server" BackColor="#843c0c" BorderColor="#843C0C" BorderStyle="None" Font-Size="Medium" ForeColor="White" OnClientClick="return confirm('Please confirm');" Text="Run" Width="100px" />
            </td>
            <td>
                <asp:Label ID="ERR" runat="server" Style="background-color: #A40000; border: none; font-family: Trebuchet MS, Arial, Helvetica, sans-serif; color: white; font: bold;" Visible="false">Job Is Running</asp:Label>
            </td>
        </tr>

    </table>


</asp:Content>
