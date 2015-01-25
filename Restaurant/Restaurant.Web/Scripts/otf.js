;$(function()
{
    var ajaxFormSubmit = function () {
        var form = $(this);
        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data: form.serialize()
        };
      
        $.ajax(options).done(function (data) {
            var target = $(form.attr("data-otf-target"));
           
            var htmlData = $(data);
            target.replaceWith(htmlData);
            htmlData.show("fold");
        });

        return false;
    };

    var submitRestSearchForm = function (event, ui) {
        var input = $(this);

        input.val(ui.item.label);

        var form = input.parents("form:first");
        form.submit();
    };

    var createSearchingFilds = function () {
        var input = $(this);
        var options = {
            source: input.attr("data-otf-restaurantsearch"),
            
            select: submitRestSearchForm
        }

        input.autocomplete(options);
    };

    var paginateClick = function () {
        var a = $(this);
        var options = {
            url: a.attr("href"),
            type: "get"
        }
        
       // alert(a.parents("div.pagedList").attr("data-otf-target"));
        $.ajax(options).done(function (data) {
            var target = $(a.parents("div.pagedList").attr("data-otf-target"));
           // alert("asdasd");
            var htmlData = $(data);
            target.replaceWith(htmlData);
            htmlData.show("highlight");
        });

        return false;
    };


    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);

    $("input[data-otf-restaurantsearch]").each(createSearchingFilds);

    $(".main-content").on("click", ".pagedList a", paginateClick);
});