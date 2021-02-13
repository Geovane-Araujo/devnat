<template>
  <Menubar class="p-tabmenu" :model="items">
    <template #start>
        <!-- <Button @click="visivel=true;" icon="pi pi-align-justify" :style="{'margin-left': '0 .5em'}"/> -->
    </template>
  </Menubar>
  <BlockUI :blocked="visivel" :fullScreen="true">
    <Sidebar v-model:visible="visivel" :baseZIndex="1000">
      <h3>Code Express</h3>
    </Sidebar>
  </BlockUI>
  <router-view/>
</template>

<script>
import Menubar from 'primevue/menubar'
/// import InputText from 'primevue/inputtext'
// import Button from 'primevue/button'
import Sidebar from 'primevue/sidebar'
import BlockUI from 'primevue/blockui'

export default {
  data () {
    return {
      visivel: false,
      items: [
        {
          label: 'Generate Code',
          icon: 'pi pi-fw pi-calendar',
          to: '/code'
        },
        {
          label: 'Downloads',
          icon: 'pi pi-fw pi-calendar'
        }
      ]
    }
  },
  components: {
    Menubar,
    // InputText,
    // Button,
    Sidebar,
    BlockUI
  }
}
</script>

<style lang="sass" scoped>
</style>
