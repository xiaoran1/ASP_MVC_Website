<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Register</title>
    <style type="text/css">
        .formclass1 {
            position: fixed;
            top: 10%;
            bottom: 10%;
            right: 20%;
            left: 20%;
            border: solid;
        }

        .errorinfo {
            color: red;
        }

        .redalert {
            border-style: solid;
            border-color: red;
        }
    </style>
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#resetbtn").click(function () {
                $(this).closest('form').find("input[type=text], textarea").val("");
                window.location = window.location.href.split("?")[0];
            });
        });
    </script>
</head>
<body>
    <div>
        <form id="form1" method="post" class="formclass1" action="<%:Url.Action("Validate","UserInfo") %>">
            <div style="text-align: center; font-weight: bold;">
                <h1>Welcome to register page!</h1>
                <hr />
                <table align="center">
                    <tr>
                        <td>
                            <asp:Label ID="usernamelabel" runat="server" Text="Username:"></asp:Label></td>

                        <td>
                            <%:Html.TextBox("username","",new{id="username"}) %></td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                        <td>
                            <%:Html.TextBox("password","",new{id="password"}) %>   </td>
                    </tr>
                    <tr>
                        <td>Repeat your password:</td>
                        <td>
                            <%:Html.TextBox("rptpassword","",new{id="rptpassword"}) %>   </td>
                    </tr>
                    <tr>
                        <td>Email Address:</td>
                        <td>
                            <%:Html.TextBox("email","",new{id="email"}) %>   </td>
                    </tr>
                </table>
                <hr />
                <input type="submit" name="register" id="registerbtn" value="Register" />
                &nbsp;
                <input type="button" name="reset" id="resetbtn" value="Reset" />
                <br />
                <br />
                <%:Html.ActionLink("Back to login page","Index","Login",new{},new{})%>
                <br />
                <br />
                <%if (Request.QueryString["registererror"] != null)
                  { %>
                <script>
                    $("input[type=text]").addClass("redalert");
                </script>
                <span class="errorinfo"><%:Request.QueryString["registererror"].ToString() %></span>
                <% } %>
            </div>
        </form>
    </div>
</body>
</html>
