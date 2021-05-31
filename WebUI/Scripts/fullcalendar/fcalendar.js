document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        locale: 'ru',
        themeSystem: 'bootstrap',
        contentHeight: 600,
        allDaySlot: false,

        dayMaxEvents: true,
        views: {
            timeGrid: {
                dayMaxEventRow: 3
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
            $("#title").text(info.event.extendedProps.request);
            $("#eventId").text(info.event.id);

            $("#description").text(info.event.extendedProps.description);

            $("#location").text(info.event.title);
            $("#start").text("Время начала: " +moment(info.event.start).format('HH:mm'));
            $("#end").text("Время окончания: " + moment(info.event.end).format('HH:mm'));

            $("#detailModal").modal();

            // window.location.href = 'Details/' + info.event.id;
        },

        headerToolbar: {
            start: 'prev,next today addButton',
            center: '',
            end: 'dayGridMonth,timeGridWeek'
        },

        events: "GetEventData",
        displayEventEnd: true,
        eventDisplay: 'block',
        eventTimeFormat: { // like '14:30:00'
            hour: '2-digit',
            minute: '2-digit',
            meridiem: false
        }
    });
    console.log(calendar.events);
    calendar.render();
});

function OpenDetails() {
    window.location.href = 'Details/' + $("#eventId").text();
}