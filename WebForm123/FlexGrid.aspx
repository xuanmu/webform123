<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlexGrid.aspx.cs" MasterPageFile="~/Site.Master" Inherits="WebForm123.FlexGrid" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jquery-2.2.3.min.js"></script>
    <script type="text/javascript" src="Scripts/Flexigrid/js/flexigrid.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="Scripts/Flexigrid/css/flexigrid.pack.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table id="flex1" style="display:none"></table>
    <script type="text/javascript">
        var addFormData = function () {
            return true;
        }
        $("#flex1").flexigrid({
	        url: '/AjaxApi/DemoData.ashx?action=demo1',
	        dataType: 'json',
	        colModel : [
		        {display: 'ISO', name : 'iso1', width : 40, sortable : true, align: 'center'},
		        {display: '名称', name : 'name', width : 180, sortable : true, align: 'left'},
		        {display: '打印名称', name : 'name2', width : 120, sortable : true, align: 'left'},
		        {display: 'ISO3', name : 'iso2', width : 130, sortable : true, align: 'left', hide: true},
		        {display: '编号', name : 'numcode', width : 80, sortable : true, align: 'right'}
		        ],
	        searchitems : [
		        {display: 'ISO', name : 'iso'},
		        { display: '名称', name: 'name', isdefault: true }
		        ],
	        sortname: "iso",
	        sortorder: "asc",
	        usepager: true,
	        title: '明细信息表',
	        useRp: true,
	        rp: 15,
	        showTableToggleBtn: true,
	        width: 700,
	        onSubmit: addFormData,
	        height: 200,
            rpOptions: [10, 15, 20, 30, 50],
            pagestat: '显示 {from} 到 {to} 总计：{total}',
        });
        </script>
</asp:Content>