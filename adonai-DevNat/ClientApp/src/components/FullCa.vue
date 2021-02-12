<template>
  <div class="layout-content">
    <div class="content-section implementation">
      <div class="card">
        <FullCalendar :events="events" :options="options" />
      </div>
    </div>
  </div>
</template>

<script>
import '@fullcalendar/common'
import '@fullcalendar/core'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'

export default {
  data () {
    return {
      options: {
        plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
        initialDate: '2017-02-01',
        headerToolbar: {
          left: 'prev,next',
          center: 'title',
          right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        editable: true
      },
      events: null
    }
  },
  eventService: null
}
</script>

<style lang="scss" scoped>
@media screen and (max-width: 960px) {
  ::v-deep(.fc-header-toolbar) {
    display: flex;
    flex-wrap: wrap;
  }
}
.card {
  margin-bottom: 2rem;
}

.layout-content {

    .content-section {
        padding: 2rem;

        &.introduction {
            background-color: #f8f9fa;
            color: #495057;
            padding-bottom: 0;
            display: flex;
            align-items: top;
            justify-content: space-between;
        }

        &.implementation {
            background-color: #f8f9fa;;
            color: #495057;

            +.documentation {
                padding-top: 0;
            }
        }
    }

    .card {
        background: #ffffff;
        padding: 2rem;
        box-shadow: 0 2px 1px -1px rgba(0,0,0,.2), 0 1px 1px 0 rgba(0,0,0,.14), 0 1px 3px 0 rgba(0,0,0,.12);
        border-radius: 4px;
        margin-bottom: 2rem;
    }
}
</style>
