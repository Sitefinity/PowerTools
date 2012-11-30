/// <reference path="~/Scripts/backbone.min.js" />

; (function () {

  var DesignerView = Backbone.View.extend({

    el: ".mvc-designer",

    initialize: function () {
      
      $("#sortable-list").sortable({ axis: "y" });

      this.model.bind("change:ListTitle", function (model, newValue) {
        $("#list-title").val(newValue);
      });

      this.model.bind("change:ListType", function (model, newValue) {
        $("input:radio[name=listType][value=" + newValue + "]").attr("checked", "checked");
      });

      $("#list-title").val(this.model.get("ListTitle"));
      $("input:radio[name=listType][value=" + this.model.get("ListType") + "]").attr("checked", "checked");

    },

    events: {
      "change #list-title": "titleChanged",
      "change input:radio[name=listType]" : "listTypeChanged"
    },

    titleChanged: function (e) {
      this.model.set("ListTitle", $("#list-title").val());
    },

    listTypeChanged: function (e) {
      this.model.set("ListType", $("input:radio[name=listType][checked]").val());
    }

  });

  Sys.Application.add_load(function () {
    new DesignerView({ model: new Backbone.DesignerModel() });
  });

})();