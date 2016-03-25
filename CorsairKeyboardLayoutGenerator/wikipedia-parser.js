

var s = parseTable($('#Latin_letters').parent().next(), 'Letters');
s += '\r\n';
s += parseTable($('#Digits').parent().next(), 'Digits');
console.log(s);

function parseTable(table, name) {
    var headers = [];
    var i;

    table.find('tr:has(th)').each(function () {
        i = 0;
        $(this).find('th').each(function () {
            var count = parseInt($(this).attr('colspan')) || 1;
            var text = $(this).text();
            for (var j = 0; j < count; j++) {
                headers[i + j] = $.trim((headers[i + j] || '') + ' ' + text).replace(/'\r/g, '').replace(/\n/g, ' ').replace('- ', '-');
            }
            i += count;
        });
    });

    var result = [];
    table.find('tr:has(td)').each(function() {
        $(this).find('td').each(function (i) {
            var codePoint = parseInt((($(this).attr('title') || '').match(/U\+(\w+):/) || {})[1], 16);
            if (!codePoint) return;

            (result[i] || (result[i] = [])).push(codePoint);
        });
    });

    var str = 'public static readonly Dictionary<string, int[]> ' + name + ' = new Dictionary<string, int[]>\r\n{\r\n';

    for (i = 0; i < headers.length; i++) {
        if (!result[i]) continue;
        str += '{ "' + headers[i] + '", new int[] { ';
        str += result[i].join(', ');
        str += ' } },\r\n';
    }

    str += '};';

    return str;
}