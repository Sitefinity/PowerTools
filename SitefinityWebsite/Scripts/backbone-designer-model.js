; (function () {
  Backbone.DesignerModel = Backbone.Model.extend({

    defaults: {
      "listTitle": ""
    },

    initialize: function () {
      this.get_propertyEditor()._designer = this;
    },

    applyChanges: function () {
      this.get_controlData().ListTitle = this.get("listTitle");
    },

    refreshUI: function () {
      this.set("listTitle", this.get_controlData().ListTitle);
    },

    get_controlData: function () {
      return this.get_propertyEditor().get_control().Settings;
    },

    get_propertyEditor: function () {
      return Sys.Application._components.propertyEditor;
    }
  });

})();