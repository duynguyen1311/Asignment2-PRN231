// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ConvertToJson(selector) {
    return JSON.stringify($(selector).serializeArray()
        .reduce(function (json, { name, value }) {
            if (name == '__RequestVerificationToken') {
                return json;
            }
            var type = $('[name="' + name + '"]').attr('type');
            if (type === 'date') {
                var dateValue = new Date(value);
                value = dateValue.toISOString().replace('.000Z', 'Z');
            }
            if (type === 'number') {
                json[name] = parseFloat(value);
            }
            else {
                json[name] = value;
            }
            return json;
        }, {}));
}