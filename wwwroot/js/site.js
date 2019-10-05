// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function() {
  var calendarEl = document.getElementById('calendar');

  var calendar = new FullCalendar.Calendar(calendarEl, {
    plugins: [ 'interaction', 'dayGrid', 'timeGrid' ],
    header: {
      left: 'prev,next today',
      center: 'title',
      right: 'dayGridMonth,timeGridWeek,timeGridDay'
    },
    locale: 'es',
    defaultDate: '2019-08-12',
    navLinks: true, // can click day/week names to navigate views
    selectable: true,
    selectMirror: true,
    select: function(arg) {
      var title = prompt('Event Title:');
      if (title) {
        calendar.addEvent({
          title: title,
          start: arg.start,
          end: arg.end,
          allDay: arg.allDay
        })
      }
      calendar.unselect()
    },
    editable: true,
    eventLimit: true, // allow "more" link when too many events
    resources: [{
      id: 'a',
      title: 'Room A'
    }, {
      id: 'b',
      title: 'Room B',
      eventColor: 'green'
    }, {
      id: 'c',
      title: 'Room C',
      eventColor: 'orange'
    }, {
      id: 'd',
      title: 'Room D',
      eventColor: 'red'
    }],
    events: [
      {
        title: 'All Day Event',
        start: '2019-08-01'
      },
      {
        title: 'Long Event',
        start: '2019-08-07',
        end: '2019-08-10'
      },
      {
        groupId: 999,
        title: 'Repeating Event',
        start: '2019-08-09T16:00:00'
      },
      {
        groupId: 999,
        title: 'Repeating Event',
        start: '2019-08-16T16:00:00'
      },
      {
        title: 'Conference',
        start: '2019-08-11',
        end: '2019-08-13'
      },
      {
        title: 'Meeting',
        start: '2019-08-12T10:30:00',
        end: '2019-08-12T12:30:00'
      },
      {
        title: 'Lunch',
        start: '2019-08-12T12:00:00'
      },
      {
        title: 'Meeting',
        start: '2019-08-12T14:30:00'
      },
      {
        title: 'Happy Hour',
        start: '2019-08-12T17:30:00'
      },
      {
        title: 'Dinner',
        start: '2019-08-12T20:00:00'
      },
      {
        title: 'Birthday Party',
        start: '2019-08-13T07:00:00'
      },
      {
        title: 'Click for Google',
        url: 'http://google.com/',
        start: '2019-08-28'
      }
    ]
    ,
  select: function(start, end, jsEvent, view, resource) {
    console.log(
      'select',
      start.format(),
      end.format(),
      resource ? resource.id : '(no resource)'
    );
  },
  dayClick: function(date, jsEvent, view, resource) {
    console.log(
      'dayClick',
      date.format(),
      resource ? resource.id : '(no resource)'
    );
  }
  });

  calendar.render();
});