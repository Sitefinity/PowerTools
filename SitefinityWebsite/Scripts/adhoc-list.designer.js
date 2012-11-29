/// <reference path="~/Scripts/backbone.min.js" />

; (function () {

  var DesignerView = Backbone.View.extend({

    el: ".mvc-designer",

    initialize: function () {
      
      $("#sortable-list").sortable({ axis: "y" });

      this.model.bind("change:listTitle", function (model, newValue) {
        $("#list-title").val(newValue);
      });

      this.model.bind("change:listType", function (model, newValue) {
        $("input:radio[name=listType][value=" + newValue + "]").attr("checked", "checked");
      });

    },

    events: {
      "change #list-title": "titleChanged",
      "change input:radio[name=listType]" : "listTypeChanged"
    },

    titleChanged: function (e) {
      this.model.set("listTitle", $("#list-title").val());
    },

    listTypeChanged: function (e) {
      this.model.set("listType", $("input:radio[name=listType][checked]").val());
    }

  });

  $(document).ready(function () {
    new DesignerView({ model: new Backbone.DesignerModel() });
  });

})();