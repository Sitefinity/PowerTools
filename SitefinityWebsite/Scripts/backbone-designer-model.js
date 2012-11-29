; (function () {
  Backbone.DesignerModel = Backbone.Model.extend({

    initialize: function () {
      this.get_propertyEditor()._designer = this;
      this.set("listTitle", this.get_controlData().ListTitle);
      this.set("listType", this.get_controlData().ListType);
    },

    applyChanges: function () {
      this.get_controlData().ListTitle = this.get("listTitle");
      this.get_controlData().ListType = this.get("listType");
    },

    refreshUI: function () {
      this.set("listTitle", this.get_controlData().ListTitle);
      this.set("listType", this.get_controlData().ListType);
    },

    get_controlData: function () {
      return this.get_propertyEditor().get_control().Settings;
    },

    get_propertyEditor: function () {
      return Sys.Application._components.propertyEditor;
    }
  });

})();