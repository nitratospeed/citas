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
      eventLimit: true, // allow "more" link when too many events
      header: {
        left: 'prev,next today',
        center: 'title',
        right: 'resourceTimeGridDay,timeGridWeek,dayGridMonth'
      },
  
      //// uncomment this line to hide the all-day slot
      allDaySlot: false,
      locale: 'es',
      resources: '/home/getListaMedicos',
      events: '/home/getListaCitas',
  
      select: function(arg) {
        
        $('#modal-nueva-cita').modal('show')
  
  /*         calendar.addEvent({
            title: title,
            start: arg.start,
            end: arg.end,
            allDay: arg.allDay
          })
  
        calendar.unselect() */
      },
  /*     dateClick: function(arg) {
        console.log(
          'dateClick',
          arg.date,
          arg.resource ? arg.resource.id : '(no resource)'
        );
      } */
    });
  
    calendar.render();
  });