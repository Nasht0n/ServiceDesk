document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        locale: 'ru',
        themeSystem: 'bootstrap',
        contentHeight: 600,
        allDaySlot: false,

        views: {
            timeGrid: {
                dayMaxEventRow: 6
            }
        },

        customButtons: {
            addButton: {
                text: 'Добавить',
                click: function () {
                    $("#addModal").modal();
                }
            }
        },

        eventClick: function (info) {
            window.location.href = 'Details/' + info.event.id;
        },

        headerToolbar: {
            start: 'prev,next today addButton',
            center: '',
            end: 'dayGridMonth,timeGridWeek'
        },

        events: "GetEventData",
        eventTimeFormat: { // like '14:30:00'
            hour: '2-digit',
            minute: '2-digit',
            meridiem: false
        }
    });
    calendar.render();
});


//$('#StartDate').datetimepicker({
//    locale: 'ru'
//});