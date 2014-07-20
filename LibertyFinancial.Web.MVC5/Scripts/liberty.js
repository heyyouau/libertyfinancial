function removeNestedForm(element, container, deleteElement)
{
    $container = $('#' + container);
    $('#' + deleteElement).val('True');
    $container.hide();

}


var draggingModelId = null;
var draggingElement = null;
var draggingType = null;
var authorEditPrefix = "aedit";
var genreEditPrefix = "gedit";
var authorSelectPrefix = "aeselect";
var genreSelectPrefix = "gselect";

function startDrag(e) {
    draggingElement = e.target.id;
    draggingModelId = $('#' + draggingElement).attr("data-modelid");
    draggingType = getElementType(e);
    e.dataTransfer.setData('TEXT', draggingElement);
    e.dataTransfer.effectAllowed = 'move';
}

function allowDrop(e) {

    //if this is an author, can only drop on author adder
    //else if this is an genre, can only drop on genre adder
    var okToDrop = false;
    if (draggingType == 'author') {
        okToDrop = (e.target.id == "authorAdditions");
    }
    else if (draggingType == 'genre') {
        okToDrop = (e.target.id == "genreAdditions");
    }

    if (okToDrop) {
        e.preventDefault();
        e.target.classList.add('over');
    }
    else {
        e.target.classList.add('overError');
    }

    


    
}

function handleDragEnter(e) {
    //is this a valid drop zone for this element?
    e.target.classList.add('over');
}


function handleDragLeave(e) {
    //revert to undecorated state
    e.target.classList.remove('over');
    e.target.classList.remove('overError');
}


function dropAuthor(e) {
    //exists?
    var container = 'authorList';
    var jqcontainer = '#' + container;
    if (modelElementExists(draggingModelId, container))
    {
        var element = $('#' + container).find("#" + authorEditPrefix + "_" + draggingModelId);
        element.show();
        element.find("#Authors_" + draggingModelId + "_Delete").val('False');
    }
    else {
        //get div contents and replace 
        var insertHtml = $('#' + draggingElement)[0].outerHTML;
        insertHtml = replaceAll('#counter#', $('#authorList').children().length, insertHtml);
        insertHtml = replaceAll(authorSelectPrefix, authorEditPrefix, insertHtml);
        addElementToDomAndPrepare(insertHtml, jqcontainer, buildDomTargetId(authorEditPrefix, draggingModelId));
    }
    e.target.classList.remove('over');
}



function modelElementExists(id, container) {
    return $('#' + container).find('#' + getPrefix(container) + "_" + id).length > 0;
}

function dropGenre(e) {
    var container = 'genreList';
    var jqcontainer = '#' + container;
    if (modelElementExists(draggingModelId, container)) {
        var element = $('#' + container).find("#" + genreEditPrefix + "_" + draggingModelId);
        element.show();
        element.find("#Genres_" + draggingModelId + "_Delete").val('False');
    }
    else {
        //get div contents and replace 
        var insertHtml = $('#' + draggingElement)[0].outerHTML;
        insertHtml = replaceAll('#counter#', $('#genreList').children().length, insertHtml);
        insertHtml = replaceAll(genreSelectPrefix, genreEditPrefix, insertHtml);
        addElementToDomAndPrepare(insertHtml, jqcontainer,  buildDomTargetId(genreEditPrefix ,draggingModelId));
    }
    e.target.classList.remove('over');
}


function addElementToDomAndPrepare(insertHtml, jqcontainer, targetId) {
    var divElement = $.parseHTML(insertHtml);
    $(jqcontainer).append(divElement);
    var domTarget = $(targetId);
    domTarget.removeAttr("draggable");
    domTarget.removeAttr("ondragstart");
    domTarget.find(".deletor").removeClass("hideCollapse");
}

function getElementType(e) {
    if ($.inArray('author', e.srcElement.classList) > 0)
        return 'author';
    else if (($.inArray('genre', e.srcElement.classList)) > 0)
        return 'genre';
    return null;
}

function presetDeletorVis(container) {
    $('#' + container + " .deletor").addClass("hideCollapse");
}


function replaceAll(find, replace, str) {
    return str.replace(new RegExp(find, 'g'), replace);
}

function getPrefix(container) {
    switch (container)
    {
        case "authorList":
            return authorEditPrefix;
            break;
        case "genreList":
            return genreEditPrefix;
            break;
    
    }
}

function buildDomTargetId(type, modelId) {
    return '#' + type + '_' + modelId;
}