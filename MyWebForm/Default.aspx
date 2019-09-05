<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    <div class="form-group">
        <label>First Name</label>
        <asp:TextBox id="txtFirst" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Last Name</label>
        <asp:TextBox id="txtLast" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Age</label>
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Gender</label>
        <asp:DropDownList runat="server" id="ddlGender"/>
    </div>
    <div class="form-group">
        <label>Comment</label>
        <asp:TextBox Rows="5" runat="server" id="txtComment"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnLoad" Text="Load Grid" runat="server" OnClick="btnLoad_OnClick"/>
    </div>

    <div>
        <table class="table table-striped">
            <thead>
            <tr>
                <td>Name</td>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater id="rptCustomers" runat="server" OnItemDataBound="rptCustomers_OnItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Name") %>
                            <%--<asp:Literal id="ltrName" runat="server"></asp:Literal>--%>
                        </td>
                        <td>
                            <asp:CheckBox id="chkSel" runat="server"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>

    </div>
</asp:Content>
