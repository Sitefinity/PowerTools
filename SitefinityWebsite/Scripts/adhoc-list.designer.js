/// <reference path="~/Scripts/backbone.min.js" />

; (function () {

  var DesignerView = Backbone.View.extend({

    el: ".mvc-designer",

    initialize: function () {
      
      $("#sortable-list").sortable({ axis: "y" });

      this.model.bind("change:listTitle", function (model, newValue) {
        $("#list-title").val(newValue);
      });

    },

    events: {
      "change #list-title" : "titleChanged"
    },

    titleChanged: function (e) {
      this.model.set("listTitle", $("#list-title").val());
    }

  });

  $(document).ready(function () {
    new DesignerView({ model: new Backbone.DesignerModel() });
  });

})();