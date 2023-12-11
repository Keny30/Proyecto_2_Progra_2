<%@ Page Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Reparaciones.aspx.cs" Inherits="CRUD.Pages.Reparaciones.Reparaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
             <div class="mb-3">
                <label class="form-label">Equipo</label>
                <asp:DropDownList ID="DropDownList1" class="form-control" required="true" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Solicitud</label>
                <asp:TextBox runat="server" TextMode="Date" required="true" CssClass="form-control" ID="tbfechasolicitud"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <asp:DropDownList ID="ddEstado" CssClass="form-control" required="true"  runat="server">
                <asp:ListItem Text="Activo" Value="1" />
                <asp:ListItem Text="Inactivo" Value="0" />
            </asp:DropDownList>
            </div>

            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Update" Visible="false" onclick="BtnUpdate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="True" OnClick="BtnVolver_Click" />
        </div>
    </form>
</asp:Content>