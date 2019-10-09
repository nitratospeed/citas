// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function() {
  var calendarEl = document.getElementById('calendar');

  var calendar = new FullCalendar.Calendar(calendarEl, {
    schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
    plugins: [ 'interaction', 'resourceDayGrid', 'resourceTimeGrid' ],
    defaultView: 'resourceTimeGridDay',
    defaultDate: '2019-08-07',
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
    resources: [
      { id: 'a', title: 'Room A' },
      { id: 'b', title: 'Room B', eventColor: 'green' },
      { id: 'c', title: 'Room C', eventColor: 'orange' },
      { id: 'd', title: 'Room D', eventColor: 'red' }
    ],
    events: [
      { id: '1', resourceId: 'a', start: '2019-08-06', end: '2019-08-08', title: 'event 1' },
      { id: '2', resourceId: 'a', start: '2019-08-07T09:00:00', end: '2019-08-07T14:00:00', title: 'event 2' },
      { id: '3', resourceId: 'b', start: '2019-08-07T12:00:00', end: '2019-08-08T06:00:00', title: 'event 3' },
      { id: '4', resourceId: 'c', start: '2019-08-07T07:30:00', end: '2019-08-07T09:30:00', title: 'event 4' },
      { id: '5', resourceId: 'd', start: '2019-08-07T10:00:00', end: '2019-08-07T15:00:00', title: 'event 5' }
    ],

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