Ext.Loader.setConfig({
    enabled: true
});

Ext.Loader.setPath('Ext.ux', 'extjs/ux/');

Ext.require([
  'Ext.panel.Panel',
  'Ext.ux.statusbar.StatusBar',
  'Ext.toolbar.TextItem',
]);

Ext.onReady(function(){

    var clock = Ext.create('Ext.toolbar.TextItem', {text: Ext.Date.format(new Date(), 'g:i:s A')})

    Ext.create('Ext.Panel', {
        title: 'Ext Word Processor',
        renderTo: 'word-proc',
        width: 500,
        bodyPadding: 5,
        layout: 'fit',
        bbar: Ext.create('Ext.ux.StatusBar', {
            id: 'word-status',
            items: [clock, ' ']
        }),
        
        listeners: {
            render: {
                fn: function(){
                    Ext.fly(clock.getEl().parent()).addCls('x-status-text-panel').createChild({cls:'spacer'});
                 	Ext.TaskManager.start({
                    run: function(){
                         Ext.fly(clock.getEl()).update(Ext.Date.format(new Date(), 'g:i:s A'));
                     },
                     interval: 1000
                 });
                },
                delay: 100
            }
        }
    });

   

});
