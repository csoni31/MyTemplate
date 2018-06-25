<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Data_Entry.aspx.cs" Inherits="Template.Data_Entry" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <div style="width: 50%;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <legend>Enter Data</legend>
                        <table>
                            <tr>
                                <td align="right">
                                    <font size="4em">       Personnel No :</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txt_uid" runat="server" ToolTip=" Personnel No " Width="200px" TextMode="Search" AutoPostBack="true" OnTextChanged="txt_uid_TextChanged"></asp:TextBox>
                                    
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_uid" Text="*Reqiured"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <font size="4em">Name:</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_name" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <font size="4em">Select Department:</font>
                                </td>
                                <td align="left">
                                    <asp:DropDownList  runat="server" ID="drp_dept" AppendDataBoundItems="false" OnDataBound="drp_dept_DataBound"  Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <font size="4em">Date:</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txt_date" Width="200px" runat="server" AutoPostBack="true" OnTextChanged="txt_date_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender runat="server" ID="calendar1" Enabled="true" TargetControlID="txt_date" Format="dd/MM/yyyy" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>

                                    <asp:Button ID="btn_login" runat="server" Text="LogIn" Font-Bold="True"
                                        ForeColor="#383E78" OnClick="btn_login_Click" />


                                </td>
                                <td></td>
                            </tr>
                        </table>
                        <asp:Label ID="lbl_error" runat="server" Text="Please Enter Correct Credentials" ForeColor="Red" Font-Bold="true" Font-Size="Large" Visible="false"></asp:Label>

                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>


                    <div id="blur">&nbsp;</div>
                    <div id="progress" style="width: 50%; margin-top: auto;">
                        <font color="white" size="3px"><b>Please wait for Login.....</b></font>
                        <br />


                        <img src="images/Desert.jpg" style="height: 67px; width: 297px" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>


        <div align="left">
        </div>

    </div>
</asp:Content>
