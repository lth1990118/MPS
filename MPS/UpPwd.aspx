<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpPwd.aspx.cs" Inherits="BaSoft.UI.UpPwd" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团队网络图打印</title>
    <link href="css/grid.css" rel="stylesheet" type="text/css" />
    <style>
        html
        {
            font-size: 12pt;
        }
        .grid .datatable TH
        {
            font-size:13px;
            font-weight:bold;
            letter-spacing:0px;
            text-align:left;
            padding:2px 4px;
            color:#333333;
            border-bottom:solid 2px #000000;
        }
        .grid .datatable .row TD
        {
            font-size:13px;
            text-align:left;
            padding:3px 4px;
            border-bottom:solid 1px #000000;
        }
    </style>
    <style type="text/css">
            #form1 p {
                height: 50px;
                line-height: 50px;
                text-align: center;
            }

            #form1 label {
                width: 80px
            }

            #form1 input, #form1 select {
                margin: 0px 10px;
                border: 2px solid #c5464a;
                border-radius: 5px;
                background: transparent;
                text-align: center;
                height: 50px;
                width: calc( 100% - 150px);
                text-align-last: center;
            }

            #form1 select {
                appearance: none;
                -moz-appearance: none;
                -webkit-appearance: none;
            }

        #Type option {
            color: black;
            background: #A6E1EC;
            line-height: 20px;
        }

        #form1 .button {
            width: 80%;
            background: #c5464a;
            color: #fff;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">   
    <table width="100%">
        <tr>
            <td>
               <label class="title">门店ID:</label>
                <asp:TextBox ID="txtShopID" runat="server" MaxLength="8" Width="100%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="v_txtShopID" runat="server" ControlToValidate="txtShopID" Display="Dynamic"
                    ErrorMessage="请输入正整数" SetFocusOnError="True" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
               <label class="title">门店密码:</label>
                <asp:TextBox ID="txtShopPwd" class="edit" size="40" runat="server" MaxLength="16" Width="100%" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>               
                <label class="title">会员卡号:</label>
                <asp:TextBox ID="txtUserName" class="edit" size="40" runat="server" MaxLength="16" Width="100%" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>               
                <label class="title">会员密码:</label>
                <asp:TextBox ID="txtUserPwd" class="edit" size="40" runat="server" MaxLength="16" Width="100%" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnQ" runat="server" class="button" Text="UpPwd" OnClick="btnQ_Click" />
            </td>
        </tr>
    </table>
    </form>

</body>
</html>
