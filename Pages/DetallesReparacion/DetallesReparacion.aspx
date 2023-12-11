<%@ Page Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="DetallesReparacion.aspx.cs" Inherits="CRUD.Pages.DetallesReparacion.DetallesReparacion" %>


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
                <label class="form-label">Reparacion</label>
                <asp:DropDownList ID="DropDownList1" class="form-control" required="true" runat="server"></asp:DropDownList>
            </div>
                        <div class="mb-3">
                <label class="form-label">Descripcion</label>
                <asp:TextBox runat="server" CssClass="form-control" required="true" ID="tbdescripcion"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Inicio</label>
                <asp:TextBox runat="server" TextMode="Date" required="true" CssClass="form-control" ID="tbfechaInicio"></asp:TextBox>
            </div>
                        <div class="mb-3">
                <label class="form-label">Fecha de Finalizacion</label>
                <asp:TextBox runat="server" TextMode="Date" required="true" CssClass="form-control" ID="tbfechaFin"></asp:TextBox>
            </div>

            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Update" Visible="false" onclick="BtnUpdate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="True" OnClick="BtnVolver_Click" />
        </div>
    </form>
</asp:Content>
