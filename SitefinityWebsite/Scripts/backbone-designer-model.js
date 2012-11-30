; (function () {
  Backbone.DesignerModel = Backbone.Model.extend({

    initialize: function () {
      this.get_propertyEditor()._designer = this;

      // load control properties into the model for the first time
      var properties = this.get_controlData();
      for (var prop in properties) {
        this.set(prop, properties[prop]);
      }
      
    },

    applyChanges: function () {
      // load the properties from model into the control
      var properties = this.get_controlData();
      for (var prop in properties) {
        if (this.get(prop)) {
          properties[prop] = this.get(prop);
        }
      }
    },

    refreshUI: function () {
      // load control properties into the model
      var properties = this.get_controlData();
      for (var prop in properties) {
        this.set(prop, properties[prop]);
      }
    },

    get_controlData: function () {
      return this.get_propertyEditor().get_control().Settings;
    },

    get_propertyEditor: function () {
      return Sys.Application._components.propertyEditor;
    }
  });

})();