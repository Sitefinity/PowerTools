/// <reference path="~/Scripts/backbone.min.js" />

; (function () {

  var adhocListDesigner = {
    initialize: function () {
      $("#sortable-list").sortable({ axis: "y" });
    }
  };

  adhocListDesigner.initialize();

})();