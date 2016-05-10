<%@ Page Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="WebForm123.Grid" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"> 
        </asp:ScriptManager> 
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" Height="100%" Width="100%" 
            AllowPaging="False" AllowSorting="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableTheming="True" 
            GridLines="Vertical" ShowFooter="True"  
            onrowcommand="GridView1_RowCommand" onrowcreated="GridView1_RowCreated"  
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onrowdatabound="GridView1_RowDataBound" 
            onrowediting="GridView1_RowEditing" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleted="GridView1_RowDeleted" onrowdeleting="GridView1_RowDeleting" 
            onrowupdated="GridView1_RowUpdated" onrowupdating="GridView1_RowUpdating" AutoGenerateColumns="false">
             <Columns>
                <asp:TemplateField HeaderText="列1" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label runat="server"  ID="colShow1" Text='<%# Eval("col1") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="colEdit1"  Text='<%# Eval("col1") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="列2" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label runat="server"  ID="colShow2" Text='<%# Eval("col2") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="colEdit2"  Text='<%# Eval("col2") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="列3" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label runat="server"  ID="colShow3" Text='<%# Eval("col3") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <%--<asp:TextBox runat="server" ID="colEdit3"  Text='<%# Eval("col3") %>'></asp:TextBox>--%>
                        <select ID="colEdit3" runat="server" value='<%# Eval("col3") %>'>
                            <option value="中国">中国</option>
                            <option value="美国">美国</option>
                            <option value="加拿大">加拿大</option>
                        </select>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField HeaderText="操作" 
                 ShowDeleteButton="true" ShowEditButton="true" ShowInsertButton="true" ShowCancelButton="true" UpdateText="提交" />
            </Columns>
            
            <AlternatingRowStyle BackColor="Gainsboro" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
