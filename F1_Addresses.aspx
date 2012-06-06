<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F1_Addresses.aspx.cs" Inherits="WebAppDojo.F1_Addresses" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   <link rel="stylesheet" media="all" href="css/style.css" type="text/css"/>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.2.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    
    <div id="wrapper">
	<div class="w1">
    <div id="main">
						<div id="content">
                            
							<h2>Addresses</h2>
                            
							<ul class="archive-list">
                             
                            <asp:Repeater ID="rptCommu" runat="server" >
                                <ItemTemplate>
								<li>
									<div class="household"><a href='F1_Address_Del.aspx?addressid=<%# Eval("AddressID") %>'>Del</a></div>
									<div class="title">
										<h3>
                                       
                                        
                                            <%#Eval("AddressTypeName")%>: <%#Eval("address1")%>
                                        
                                        </h3>
										
									</div>
                                    <div class="title2">
									<a href="F1_Address_Update.aspx?personid=<%= personID%>&addressid=<%# Eval("AddressID") %>&householdid=<%= householdID %>" class="link-more">Update the Address</a>
                                   
                                    </div>
								</li>
                                </ItemTemplate>
                                </asp:Repeater>
                                
								<li>
									<a href="F1_Address_Edit.aspx?personid=<%= personID %>&householdid=<%= householdID %>">Add an Address</a>
								</li>
							</ul>
						</div>
    </div>
    </div>
    </div>
    </form>

    
</body>
</html>



