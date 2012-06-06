<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F1_Search.aspx.cs" Inherits="WebAppDojo.F1_Search" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>F1 Search</title>
   <link rel="stylesheet" media="all" href="css/style.css" type="text/css"/>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.2.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    
    <div id="wrapper">
	<div class="w1">
    <div id="main">
						<div id="content">
                            <div id="SearchSection">
                            <p>total records: <%= count %></p>
    
                            Seach: 
                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>

                            <asp:Button ID="btn1" runat="server" Text="submit" OnClientClick="return(Validation_Check());" OnClick="BtnSubmit_Click" />
    
    
                            <asp:Button ID="Button1" runat="server" Text="Refresh" OnClick="BtnRefresh_Click" />
                            <p></p>
  
   
                            </div>
							<h2>Search Results</h2>
							<ul class="archive-list">
                             <asp:Repeater ID="rptResults" runat="server">
                            <ItemTemplate>
								<li>
									<div class="household"><a href="F1_Household.aspx?id=<%#Eval("HouseholdID")%> " class="link-more">HousehoID</a></div>
									<div class="title">
										<h3><%#Eval("LastName")%>, <%#Eval("FirstName")%></h3>
										
									</div>
                                    <div class="title2">
									<a href="F1_Addresses.aspx?id=<%#Eval("ID")%>" class="link-more">View Addresses</a>
                                    <a href="F1_Communications.aspx?id=<%#Eval("ID")%>" class="link-more">View Communications</a>
                                    </div>
								</li>
                                </ItemTemplate>
                                </asp:Repeater>
								<li>
									
								</li>
							</ul>
						</div>
    </div>
    </div>
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

