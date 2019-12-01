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
    right: 'resourceTimeGridDay,dayGridMonth'
  },
  allDaySlot: false,
  locale: 'es',
  contentHeight: 'auto',
  eventLongPressDelay: 20,
  selectLongPressDelay: 25,

  resources: function(fetchInfo, successCallback, failureCallback) {
    let xhr = new XMLHttpRequest();
    var formData = new FormData()
    formData.append("medico", document.getElementById("IdMedicoBuscar").value);
    xhr.open('POST', '/home/getListaMedicosById');
    xhr.responseType = 'json';
    xhr.send(formData);
    xhr.onload = function() {
      successCallback(xhr.response);
    };
    xhr.onerror = function() {
      alert('Error getListaMedicosById');
    };
  },

  events: function(info, successCallback, failureCallback) {

    let xhr = new XMLHttpRequest();
    var formData = new FormData()
    formData.append("nombre", document.getElementById("ClienteBuscar").value);
    formData.append("medico", document.getElementById("IdMedicoBuscar").value);
    xhr.open('POST', '/home/getListaCitas');
    xhr.responseType = 'json';
    xhr.send(formData);
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
      document.getElementById('modal-nueva-cita').classList.add('is-active');
    }

  },

  eventClick: function(info) {
    document.getElementById("form-cita").reset();

    let xhr = new XMLHttpRequest();

    var formData = new FormData()
    formData.append("idcita", parseInt(info.event.id, 10));

    xhr.open('POST', '/home/getCitaById');
    xhr.responseType = 'json';
    xhr.send(formData);
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

window.onload = function() {

  calendar.render();

  let xhr = new XMLHttpRequest();
  xhr.open('GET', '/home/getListaMedicos');
  xhr.responseType = 'json';
  xhr.send();
  xhr.onload = function() {
    var data = xhr.response;
    html = "";
    html = "<option value='0'>Todos</option>"
    data.forEach(function(object) {
      html += "<option value=" + object.id + ">" + object.title + "</option>"
    });
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
    data.forEach(function(object) {
      html += "<option value=" + object.id + ">" + object.title + "</option>"
    });
    document.getElementById("IdTipo").innerHTML = html;
  };
  xhr2.onerror = function() {
    alert('Error getListaTipos');
  };
};

document.getElementById("btn-filtrar").onclick = function (e) {
  calendar.refetchEvents();
  calendar.refetchResources();
};

document.getElementById("btn-guardar").onclick = function (e) {
    let xhr = new XMLHttpRequest();
    var form_data = new FormData(document.getElementById("form-cita"));
    xhr.open('POST', '/home/postCita');
    xhr.send(form_data);
    xhr.onload = function() {
      var data = xhr.response;
      if (data = "1") {
        document.getElementById('modal-nueva-cita').classList.remove('is-active');
        calendar.refetchEvents();
        calendar.refetchResources();
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
      calendar.refetchEvents();
      calendar.refetchResources();
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
          document.getElementById('modal-nueva-cita').classList.remove('is-active');
          calendar.refetchEvents();
          calendar.refetchResources();
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