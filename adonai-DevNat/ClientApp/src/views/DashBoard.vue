<template>
  <div>
    <H1 class="textColors">Compromissos</H1>
    <FullCalendar :events="eventos"/>
  </div>
</template>

<script>
import FullCalendar from 'primevue/fullcalendar'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'

export default {
  data () {
    return {
      eventos: [
        {
          id: 1,
          title: 'teste',
          start: '2021-02-11'
        },
        {
          id: 2,
          title: 'teste',
          start: '2021-02-13'
        }
      ]
    }
  },
  components: [
    FullCalendar,
    dayGridPlugin,
    timeGridPlugin,
    interactionPlugin
  ]
}
</script>
<style lang="scss" scoped>
</style>
