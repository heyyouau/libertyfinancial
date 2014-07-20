function removeNestedForm(element, container, deleteElement)
{
    $container = $('#' + container);
    $('#' + deleteElement).val('True');
    $container.hide()
}
