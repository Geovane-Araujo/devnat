<template>
  <div class="p-grid p-fluid" style="height:91%;width: 100%">
    <div class="p-col-2" style="margin: 3% 0% 2% 2%;background-color: #1F2D40;">
      <dir style=""></dir>
    </div>
  </div>
</template>
<script>
// import FullCalendar from 'primevue/fullcalendar'
/* import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'
import ptLocale from '@fullcalendar/core/locales/pt-br' */
// <FullCalendar :options="options"/>
export default {
  data () {
    return {
      options: {
        // plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
        initialDate: new Date(),
        // locale: ptLocale,
        aspectRatio: 3,
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
  components: {
    // FullCalendar
  }
}
</script>
<style lang="scss" scoped>
</style>
