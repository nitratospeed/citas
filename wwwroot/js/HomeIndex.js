$(document).ready(function () {
    var calendarEl = document.getElementById('calendar');
  
    var hoy = new Date();

    var calendar = new FullCalendar.Calendar(calendarEl, {
      schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
      plugins: [ 'interaction', 'resourceDayGrid', 'resourceTimeGrid' ],
      defaultView: 'dayGridMonth',
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
      resources: '/home/getListaMedicos',
      events: '/home/getListaCitas',
      eventTimeFormat: { 
        hour: '2-digit',
        minute: '2-digit',
        hour12:false
      },
      slotLabelFormat: {
        hour: '2-digit',
        minute: '2-digit',
        hour12:false
      },
      minTime: "09:00:00",
      maxTime: "20:00:00",
      select: function(arg) {
        document.getElementById("form-cita").reset();
        $('#modal-nueva-cita').modal('show')
  
  /*         calendar.addEvent({
            title: title,
            start: arg.start,
            end: arg.end,
            allDay: arg.allDay
          })
  
        calendar.unselect() */
      },
      eventClick: function(info) {
        document.getElementById("form-cita").reset();
        
        $.getJSON('/home/getCitaById', 
          {
            IdCita: info.event.id
          }, 
          function(data) {
            document.getElementById('IdCita').value = data.idCita
            document.getElementById('IdMedico').value = data.idMedico
            document.getElementById('FechaCita').value = data.fechaCita
            document.getElementById('NombreCliente').value = data.nombreCliente
            document.getElementById('CorreoCliente').value = data.correoCliente
            document.getElementById('Duracion').value = data.duracion
            document.getElementById('Tipo').value = data.tipo
            document.getElementById('Comentarios').value = data.comentarios

            $('#modal-nueva-cita').modal('show');
          });
        }
    });

    calendar.render();
  });