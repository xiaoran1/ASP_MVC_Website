<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
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

        a {
            text-decoration: none;
            color: green;
        }
        .redalert {
            border-style: solid;
            border-color:red;
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
        <form method="post" class="formclass1" action="<%: Url.Action("Validate","Login") %>">
            <div style="text-align: center;">
                <h1>Please login first</h1>
                <hr />
                <table align="center">
                    <tr>
                        <td>Username:</td>

                        <td>
                            <%:Html.TextBox("username","",new{id="username"}) %></td>
                    </tr>
                    <tr>
                        <td>Password:</td>

                        <td>
                            <%:Html.TextBox("password","",new{id="password"}) %>   </td>
                    </tr>
                </table>
                <hr />
                <input type="submit" name="login" id="loginrbtn" value="Login" />
                &nbsp;
                <input type="button" name="reset" id="resetbtn" value="Reset" />
                <br />
                <br />
                <%if (Request.QueryString["loginerror"] != null)
                  { %>
                <script>
                    $("input[type=text]").addClass("redalert");
                </script>
                    <span class="errorinfo"><%:Request.QueryString["loginerror"].ToString() %></span>
                    <br />
                    <%:Html.ActionLink("Register","RegisterRazor","UserInfo",new{},new{})%>
                <% } %>
            </div>
        </form>
    </div>
</body>
</html>
