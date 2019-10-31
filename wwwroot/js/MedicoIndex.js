document.addEventListener('DOMContentLoaded', function() {

    var table = document.getElementById('table');

    $.getJSON('/medico/getListaMedicos', 
     function(data) {
      for (var key in data) {
        var tr = document.createElement('tr');
        tr.innerHTML = 
        '<td>' + data[key].Nombres + '</td>' +
        '<td>' + data[key].Horarios.HoraInicio + '</td>' +
        '<td>' + data[key].Horarios.HoraFin + '</td>';
        table.appendChild(tr);  
        }
    });
});