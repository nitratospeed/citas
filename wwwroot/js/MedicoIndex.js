document.addEventListener('DOMContentLoaded', function() {

    var table = document.getElementById('table');

    $.getJSON('/medico/getListaMedicos', 
     function(data) {
      for (var key in data) {
        var tr = document.createElement('tr');
        tr.innerHTML = 
        '<td>' + data[key].nombres + '</td>';
        table.appendChild(tr);  
        }
    });
});