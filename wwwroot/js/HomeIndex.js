document.addEventListener('DOMContentLoaded', function() {

  var xhr = new XMLHttpRequest();
  xhr.open("GET", '/home/getListaMedicos', true);
  xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
  xhr.onreadystatechange = function() {
      if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
        html = "";
        html = "<option value='0'>Todos</option>"
        for (var key in this.response) {
          html += "<option value=" + this.response[key].id + ">" + this.response[key].title + "</option>"
        }
        document.getElementById("IdMedico").innerHTML = html;
        document.getElementById("IdMedicoBuscar").innerHTML = html;
      }
      else if (this.readyState === XMLHttpRequest.DONE && this.status != 200) {
        alert('Ocurrió un error.');
      }
  }
  xhr.send();

/*   $.getJSON('/home/getListaMedicos', 
   function(data) {
    html = "";
    html = "<option value='0'>Todos</option>"
    for (var key in data) {
      html += "<option value=" + data[key].id + ">" + data[key].title + "</option>"
    }
    document.getElementById("IdMedico").innerHTML = html;
    document.getElementById("IdMedicoBuscar").innerHTML = html;
  }); */

  $.getJSON('/home/getListaTipos', 
  function(data) {
   html = "";
   html = "<option value='0'>Seleccione</option>"
   for (var key in data) {
     html += "<option value=" + data[key].id + ">" + data[key].title + "</option>"
   }
   document.getElementById("IdTipo").innerHTML = html;
  });

  var calendarEl = document.getElementById('calendar');

  var hoy = new Date();

  var calendar = new FullCalendar.Calendar(calendarEl, {
    schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
    plugins: ['interaction', 'resourceDayGrid', 'resourceTimeGrid'],
    defaultView: 'resourceTimeGrid',
    defaultDate: hoy,
    editable: true,
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
      $.ajax({
        url: '/home/getListaMedicosById',
        data: {
          medico: $('#IdMedicoBuscar').val()
        }
      }).done(function(response) {
        successCallback(response);
      });
    },

    events: function(info, successCallback, failureCallback) {
      $.ajax({
        url: '/home/getListaCitas',
        data: {
          nombre: $('#ClienteBuscar').val(),
          medico: $('#IdMedicoBuscar').val()
        }
      }).done(function(response) {
        successCallback(response);
      })
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
      document.getElementById('FechaInicioCita').value = arg.startStr.replace('T',' ').substring(0, 16);
      document.getElementById('FechaFinCita').value = arg.endStr.replace('T',' ').substring(0, 16);
      document.getElementById("IdMedico").value = arg.resource.id;
      document.getElementById("IdTipo").value = 1;
      $('#modal-nueva-cita').modal('show');
    },

    eventClick: function(info) {
      document.getElementById("form-cita").reset(); 
      $.getJSON('/home/getCitaById', 
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
          document.getElementById('FechaFinCita').value = data.fechaFinCita.replace('T',' ').substring(0, 16);
          document.getElementById('IdTipo').value = data.idTipo;
          document.getElementById('Comentarios').value = data.comentarios;

          $('#modal-nueva-cita').modal('show');
        });
      }
    });

    $('#modal-nueva-cita').on('hidden.bs.modal', function() {
      calendar.refetchEvents();
      calendar.refetchResources();
    });

    $('#btn-filtrar').on('click', function() {
      calendar.refetchEvents();
      calendar.refetchResources();
    });

    calendar.render();
  });

  $(document).on("click", '#btn-guardar', function (e) {

    $.post('/home/postCita', 
    {
      IdCita: document.getElementById('IdCita').value,
      IdMedico: document.getElementById('IdMedico').value,
      NombreCliente: document.getElementById('NombreCliente').value,
      CorreoCliente: document.getElementById('CorreoCliente').value,
      Movil: document.getElementById('Movil').value,
      FechaInicioCita: document.getElementById('FechaInicioCita').value,
      FechaFinCita: document.getElementById('FechaFinCita').value,
      IdTipo: document.getElementById('IdTipo').value,
      Comentarios: document.getElementById('Comentarios').value
    }, 
    function(data) {
      if (data = "1") {
        $('#modal-nueva-cita').modal('hide');
      }
      else{
        alert('Error al guardar cita');
      }
    });
  });

  document.getElementById("btn-cancelar").onclick = function fun() {

    var idCita = document.getElementById('IdCita').value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", '/home/deleteCita', true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function() {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
          $('#modal-nueva-cita').modal('hide');
        }
        else if (this.readyState === XMLHttpRequest.DONE && this.status != 200) {
          alert('Ocurrió un error.');
        }
    }
    xhr.send("idCita="+idCita);
  };