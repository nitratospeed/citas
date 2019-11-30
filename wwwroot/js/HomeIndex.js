document.addEventListener('DOMContentLoaded', function() {
  let xhr = new XMLHttpRequest();
  xhr.open('GET', '/home/getListaMedicos');
  xhr.responseType = 'json';
  xhr.send();
  xhr.onload = function() {
    var data = xhr.response
    html = "";
    html = "<option value='0'>Todos</option>"
    for (var key in data) {
      html += "<option value=" + data[key].id + ">" + data[key].title + "</option>"
    }
    document.getElementById("IdMedico").innerHTML = html;
    document.getElementById("IdMedicoBuscar").innerHTML = html;
  };
  xhr.onerror = function() {
    alert('Error getListaMedicos');
  };

  let xhr2 = new XMLHttpRequest();
  xhr2.open('GET', '/home/getListaTipos');
  xhr2.responseType = 'json';
  xhr2.send();
  xhr2.onload = function() {
    var data = xhr2.response
    html = "";
    html = "<option value='0'>Seleccione</option>"
    for (var key in data) {
      html += "<option value=" + data[key].id + ">" + data[key].title + "</option>"
    }
    document.getElementById("IdTipo").innerHTML = html;
  };
  xhr2.onerror = function() {
    alert('Error getListaTipos');
  };

  var calendarEl = document.getElementById('calendar');

  var hoy = new Date();

  var calendar = new FullCalendar.Calendar(calendarEl, {
    schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
    plugins: ['interaction', 'resourceDayGrid', 'resourceTimeGrid'],
    defaultView: 'resourceTimeGrid',
    defaultDate: hoy,
    //editable: true,
    selectable: true,
    eventLimit: true,
    header: {
      left: 'prev,next today',
      center: 'title',
      right: 'resourceTimeGridDay,timeGridWeek,dayGridMonth'
    },
    allDaySlot: false,
    locale: 'es',
    contentHeight: 'auto',
    eventLongPressDelay: 20,
    selectLongPressDelay: 25,

    resources: function(fetchInfo, successCallback, failureCallback) {
      let xhr = new XMLHttpRequest();
      let json = JSON.stringify({
        medico: document.getElementById("IdMedicoBuscar").value
      });
      xhr.open('POST', '/home/getListaMedicosById');
      xhr.responseType = 'json';
      xhr.send(json);
      xhr.onload = function() {
        successCallback(xhr.response);
      };
      xhr.onerror = function() {
        alert('Error getListaMedicosById');
      };
    },

    events: function(info, successCallback, failureCallback) {
      let xhr = new XMLHttpRequest();
      let json = JSON.stringify({
        nombre: document.getElementById("ClienteBuscar").value,
        medico: document.getElementById("IdMedicoBuscar").value
      });
      xhr.open('GET', '/home/getListaCitas');
      xhr.responseType = 'json';
      xhr.send(json);
      xhr.onload = function() {
        successCallback(xhr.response);
      };
      xhr.onerror = function() {
        alert('Error getListaCitas');
      };
    },
    eventTimeFormat: {
      hour: '2-digit',
      minute: '2-digit',
      hour12: false
    },
    slotLabelFormat: {
      hour: '2-digit',
      minute: '2-digit',
      hour12: false
    },
    minTime: "09:00:00",
    maxTime: "20:00:00",

    select: function(arg) {
      document.getElementById("form-cita").reset();
      document.getElementById('btn-actualizar').style.display = 'none';
      document.getElementById('btn-cancelar').style.display = 'none';
      document.getElementById('btn-guardar').style.display = 'block';
      document.getElementById('FechaInicioCita').value = arg.startStr.replace('T',' ').substring(0, 16);
      //document.getElementById('FechaFinCita').value = arg.endStr.replace('T',' ').substring(0, 16);   
      document.getElementById("IdTipo").value = 1;

      var restaFechas = Math.abs(new Date(arg.endStr.replace('T',' ').substring(0, 16)) - new Date(arg.startStr.replace('T',' ').substring(0, 16)));
      var minutos = Math.floor(restaFechas / 60000);
      document.getElementById("Duracion").value = minutos;

      if (arg.resource != null) {
        document.getElementById("IdMedico").value = arg.resource.id;
        //$('#modal-nueva-cita').modal('show');
        document.getElementById('modal-nueva-cita').classList.add('is-active');
      }

    },

    eventClick: function(info) {
      document.getElementById("form-cita").reset(); 
/*       $.getJSON('/home/getCitaById', 
        {
          IdCita: info.event.id
        }, 
        function(data) {
          document.getElementById('IdCita').value = data.idCita;
          document.getElementById('IdMedico').value = data.idMedico;
          document.getElementById('NombreCliente').value = data.nombreCliente;
          document.getElementById('Movil').value = data.movil;
          document.getElementById('CorreoCliente').value = data.correoCliente;
          document.getElementById('FechaInicioCita').value = data.fechaInicioCita.replace('T',' ').substring(0, 16);
          //document.getElementById('FechaFinCita').value = data.fechaFinCita.replace('T',' ').substring(0, 16);
          document.getElementById('Duracion').value = data.duracion;
          document.getElementById('IdTipo').value = data.idTipo;
          document.getElementById('Comentarios').value = data.comentarios;
          document.getElementById('btn-guardar').style.display = 'none';
          document.getElementById('btn-actualizar').style.display = 'block';
          document.getElementById('btn-cancelar').style.display = 'block';
          $('#modal-nueva-cita').modal('show');
        }); */
        let xhr = new XMLHttpRequest();
        xhr.open('GET', '/home/getCitaById');
        xhr.responseType = 'json';
        xhr.send(info.event.id);
        xhr.onload = function() {
          var data = xhr.response;
          document.getElementById('IdCita').value = data.idCita;
          document.getElementById('IdMedico').value = data.idMedico;
          document.getElementById('NombreCliente').value = data.nombreCliente;
          document.getElementById('Movil').value = data.movil;
          document.getElementById('CorreoCliente').value = data.correoCliente;
          document.getElementById('FechaInicioCita').value = data.fechaInicioCita.replace('T',' ').substring(0, 16);
          //document.getElementById('FechaFinCita').value = data.fechaFinCita.replace('T',' ').substring(0, 16);
          document.getElementById('Duracion').value = data.duracion;
          document.getElementById('IdTipo').value = data.idTipo;
          document.getElementById('Comentarios').value = data.comentarios;
          document.getElementById('btn-guardar').style.display = 'none';
          document.getElementById('btn-actualizar').style.display = 'block';
          document.getElementById('btn-cancelar').style.display = 'block';

          document.getElementById('modal-nueva-cita').classList.add('is-active');
        };
        xhr.onerror = function() {
          alert('Error getCitaById');
        };
      }
  });

/*   $('#modal-nueva-cita').on('hidden.bs.modal', function() {
    calendar.refetchEvents();
    calendar.refetchResources();
  }); */

  document.getElementById("btn-filtrar").onclick = function (e) {
    calendar.refetchEvents();
    calendar.refetchResources();
  };

  calendar.render();
});

document.getElementById("btn-guardar").onclick = function (e) {
    let xhr = new XMLHttpRequest();
    var form_data = new FormData(document.getElementById("form-cita"));
    xhr.open('POST', '/home/postCita');
    xhr.send(form_data);
    xhr.onload = function() {
      var data = xhr.response;
      if (data = "1") {
        document.getElementById('modal-nueva-cita').classList.remove('is-active');
      }
      else{
        alert('Error al guardar cita');
      }
    };
    xhr.onerror = function() {
      alert('Error postCita');
    };
  };

document.getElementById("btn-actualizar").onclick = function (e) {
  let xhr = new XMLHttpRequest();
  var form_data = new FormData(document.getElementById("form-cita"));
  xhr.open('POST', '/home/updateCita');
  xhr.send(form_data);
  xhr.onload = function() {
    var data = xhr.response;
    if (data = "1") {
      document.getElementById('modal-nueva-cita').classList.remove('is-active');
    }
    else{
      alert('Error al guardar cita');
    }
  };
  xhr.onerror = function() {
    alert('Error updateCita');
  };
};

document.getElementById("btn-cancelar").onclick = function (e) {
  var result = confirm("¿Estás seguro de eliminar esta cita?");
  if (result) {
    var idCita = document.getElementById('IdCita').value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", '/home/deleteCita', true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onload = function() {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
          $('#modal-nueva-cita').modal('hide');
        }
        else if (this.readyState === XMLHttpRequest.DONE && this.status != 200) {
          alert('Ocurrió un error.');
        }
    };
    xhr.onerror = function() {
      alert('Error');
    };
    xhr.send("idCita="+idCita);
  }
};