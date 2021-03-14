import RadioButton from 'primevue/radiobutton'
import InputText from 'primevue/inputtext'
import Checkbox from 'primevue/checkbox'
import Dropdown from 'primevue/dropdown'
import Button from 'primevue/button'
import Editor from 'primevue/editor'
import axios from 'axios'

export default {
  data () {
    return {
      form: {
        server: 0,
        dataBaseName: '',
        tableName: 'Pessoa',
        package: '',
        className: '',
        routeName: '',
        tipo: 0,
        model: 0,
        controller: 0,
        resource: 0,
        requerToken: 0,
        language: '',
        code: ''
      },
      sgbd: [
        { name: 'Postgres', code: '1' },
        { name: 'SQL Server', code: '2' },
        { name: 'MySql', code: '3' },
        { name: 'Oracle', code: '4' },
        { name: 'Sqlite', code: '5' }
      ],
      language: [
        { name: 'Java', code: '1' },
        { name: 'C#', code: '2' },
        { name: 'Python', code: '3' }
      ]
    }
  },
  methods: {
    getCode (form) {
      axios.post('/api/v1/createcode', form).then(res => {
        alert(res.data)
      })
    }
  },
  components: {
    Dropdown,
    Button,
    RadioButton,
    Checkbox,
    InputText,
    Editor
  }
}
