/// <reference path="~/Scripts/backbone.min.js" />

; (function () {

  var DesignerModel = Backbone.Model.extend({

    initialize: function () {
      // inject self as designer into the property editor
      this.propertyEditor()._designer = this;
      // load control properties into the model for the first time
      this.refreshUI();
    },

    applyChanges: function () {
      // load the properties from model into the control
      this.properties().ListTitle = this.get("ListTitle");
      this.properties().ListType = this.get("ListType");
      
      var listItems = [];
      this.get("ListItems").each(function (listItem) {
        listItems.push(listItem.get("text"))
      });

      this.properties().ListItems = JSON.stringify(listItems);
    },

    refreshUI: function () {
      // load control properties into the model
      this.set("ListTitle", this.properties().ListTitle);
      this.set("ListType", this.properties().ListType);
    },

    properties: function () {
      return this.propertyEditor().get_control().Settings;
    },

    propertyEditor: function () {
      return Sys.Application._components.propertyEditor;
    }
  });

  var ListItem = Backbone.Model.extend({ });
  var ListItems = Backbone.Collection.extend({ });

  var DesignerView = Backbone.View.extend({

    el: ".mvc-designer",

    initialize: function () {
      
      this.model.set("ListItems", new ListItems(this.model.get("ListItems")));
      this.model.get("ListItems").bind("add", this.listItemAdded, this);

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
      "change input:radio[name=listType]": "listTypeChanged",
      "click #add-list-item" : "addListItem"
    },

    titleChanged: function (e) {
      this.model.set("ListTitle", $("#list-title").val());
    },

    listTypeChanged: function (e) {
      this.model.set("ListType", $("input:radio[name=listType][checked]").val());
    },

    addListItem: function (e) {
      e.preventDefault();
      this.model.get("ListItems").add(new ListItem({
        text: $("#newListItem").val()
      }));
    },

    listItemAdded: function (listItem) {
      var listItemView = new ListItemView({ model: listItem });
      $(this.el).find("#sortable-list").append(listItemView.render().el);      
    }

  });

  var ListItemView = Backbone.View.extend({
    tagName: "li",

    template: function () {
      return this._template = this._template || _.template($("#list-item-template").html());
    },

    render: function () {
      $(this.el).html(this.template()(this.model));
      return this;
    }
  });

  Sys.Application.add_load(function () {
    new DesignerView({ model: new DesignerModel() });
  });

})();