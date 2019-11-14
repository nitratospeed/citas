document.addEventListener('DOMContentLoaded', function() {

    var table = document.getElementById('table');

    $.getJSON('/medico/getListaMedicos', 
     function(data) {
      for (var key in data) {
        var tr = document.createElement('tr');
        tr.innerHTML = 
        '<td>' + data[key].nombres + '</td>' +
        '<td>' + data[key].especialidad + '</td>' +
        '<td>' + data[key].correo + '</td>' +
        '<td>' + data[key].celular + '</td>' +
        '<td>' + data[key].direccion + '</td>' +
        '<td>' + data[key].fechaNac + '</td>';
        table.appendChild(tr);  
        }
    });
});