<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F1_Address_Edit.aspx.cs" Inherits="WebAppDojo.F1_Address_Edit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" media="all" href="css/style.css" type="text/css"/>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    address1: <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
     <asp:Button ID="btn1" runat="server" Text="Creat an Address" OnClientClick="return(Validation_Check());" OnClick="BtnSubmit_Click" />
    
        
    </div>
    </form>
    <script type="text/javascript">

        function Validation_Check() {
            var txtName = $('#txtSearch');
            if (txtName.val() == '') {
                alert("Please enter something!");
                return false;
            }


        }


    </script>
</body>
</html>
