function Capitalize(word){
    var txt = word;
    word = txt.substring(0,1).toUpperCase() + txt.substring(1,txt.length);
   return word;
}

Ext.onReady(function () {

// first create a store to GET the data
	Ext.define('Menu', {
		extend: 'Ext.data.Model',
		fields: ['id', 'text', 'leaf','icon','hrefTarget']
	});

    var treestore = Ext.create('Ext.data.TreeStore', {
		model: 'menu',
		autoLoad: true, 
        proxy: {
            type: 'ajax',
            url: '/Home/Listar_Menu',
     		node:'id', // send the parent id through GET (default 0)
			root: 'a',
			reader: {
				type: 'json',
				root: 'a'
			}
        }
    });

	
	var tree = new Ext.tree.TreePanel({//Ext.create('Ext.tree.Panel', {
        store: treestore,
        rootVisible: false,
        renderTo: Ext.getBody(),
		border: 0,
        //width: 200,
		autoScroll: true,
        height: 220
		//root:this.getData()
	});
	tree.getSelectionModel().on('select', function(selModel, record) {
			if (record.get('leaf')) {//Si es TRUE = Submenu
					var id_tab = record.get('id');
					var title_tab = Capitalize(record.get('text'));
					var YourTabPanel = Ext.getCmp('mainpanel');
					var TabToCheck = Ext.getCmp(id_tab);
					if(TabToCheck){ //Si ya esta abierto, lo activamos
					   YourTabPanel.setActiveTab(id_tab);
					} else { //Si no lo creamos
					YourTabPanel .add({
						icon: record.get('icon'),
						title:title_tab,
						id:id_tab,
						plain:true,
						frame:true,
						//iconCls: 'tabs',
						closable:true,
						autoScroll:true,
						layout: 'fit',
						html:'<IFRAME FRAMEBORDER="0" NAME="Ifr" ID="Ifr" src="'+record.get('hrefTarget')+'" STYLE="top:0px; left:0px; width:100%; height:500; BACKGROUND-COLOR: #FFFFFF; OVERFLOW: hidden; position:relative;" SCROLLING="auto" ></IFRAME>'
						//autoLoad: {url: nombre +'.php', method: 'POST', params: {data:nombre},scripts: true, text: 'Cargando...', scope: this} 
						//autoLoad: {url: record.get('hrefTarget'), method: 'POST', scripts: true, scope: this,text: 'Cargando...'}
						}).show();
				  }
				  YourTabPanel.doLayout();
			}
		});
});