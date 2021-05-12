document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        locale: 'ru',
        themeSystem: 'bootstrap',
        contentHeight: 600,
        selectable: true,
        unselectAuto: true,
        select: function () {

        },

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
            alert('Event: ' + info.event.id);
            

            // change the border color just for fun
            info.el.style.borderColor = 'red';
        },

        headerToolbar: {
            start: 'prev,next today addButton',
            center: '',
            end: 'dayGridMonth,timeGridWeek'
        },

        events: "GetEventData"   
    });
    calendar.render();
});


//$('#StartDate').datetimepicker({
//    locale: 'ru'
//});