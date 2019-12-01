window.onload = function() {
    var table = document.getElementById('table');

    let xhr = new XMLHttpRequest();
    xhr.open('GET', '/medico/getListaMedicos');
    xhr.responseType = 'json';
    xhr.send();
    xhr.onload = function() {
        var data = xhr.response;
        data.forEach(function(object) {
          var tr = document.createElement('tr');
          tr.innerHTML = 
          '<td>' + object.nombres + '</td>';
          table.appendChild(tr); 
        });
    };
    xhr.onerror = function() {
      alert('Error getListaMedicos');
    };
};