<%@ Page Title="Данные веб-сервиса" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Weather.Default"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtCity" runat="server" Text="" />
    <hr />
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" ><ContentTemplate>
          <asp:Button Text="Получить данные" runat="server" OnClick="GetWeatherInfo" />
          <br></br>
    <table id="tblWeather" runat="server" border="0" cellpadding="0" cellspacing="0" visible="false">
        <tr>
            <th colspan="2">
               Openweathermap.org
            </th>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Image ID="imgWeatherOpenweatherIcon" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity_Country" runat="server" />
                <asp:Image ID="imgCountryFlag" runat="server" />
                <asp:Label ID="lblDescription" runat="server" />
                Влажность:
                <asp:Label ID="lblHumidity" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Температура: (Min:
                <asp:Label ID="lblTempMin" runat="server" />
                Max:
                <asp:Label ID="lblTempMax" runat="server" />
                Day:
                <asp:Label ID="lblTempDay" runat="server" />
                Night:
                <asp:Label ID="lblTempNight" runat="server" />)
            </td>
        </tr>
    </table>
        </br>
   

         <table id="tblWeather2" runat="server" border="0" cellpadding="0" cellspacing="0" visible="false">
        <tr>
            <th colspan="2">
               Meteoservice.ru
            </th>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Image ID="imgWeatherMeteoserviceIcon" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMeteoTown" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Температура:
                <asp:Label ID="lblMeteoTemperature" runat="server" />
                 Осадки:
                <asp:Label ID="lblMeteoOsadki" runat="server" />
                 Ветер:
                <asp:Label ID="lblMeteoWind" runat="server" />
            </td>
        </tr>
    </table>
</ContentTemplate></asp:UpdatePanel>  


</asp:Content>
