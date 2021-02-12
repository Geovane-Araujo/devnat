<template>
  <div>
    <h1>Generate Code</h1>
    <h4>Gere seu código de maneira rápido e fácil</h4>
    <div class="row" style="margin: 20px">
      <div class="col-sm-3 p-fluid cardconexao">
        <div class="p-field p-md-12 campos" >
          <span class="p-float-label">
            <Dropdown id="dropsgbd" v-model="selectsgbd" :options="sgbd" optionLabel="name" />
            <label for="dropsgbd">SGBD</label>
          </span>
        </div>
        <div class="p-field p-col-10 p-md-12" style="">
          <span class="p-float-label">
            <Imput id="banco" type="text"/>
            <label for="banco">Nome do Banco</label>
          </span>
        </div>
        <div class="p-grid p-jc-end">
          <div class="p-col-4">
            <Button label="Gerar" class="p-button-rounded" ></Button>
          </div>
        </div>
      </div>
      <div class="col-sm-9 p-fluid cardconexao">
        <div class="p-grid p-jc-end">
          <div class="p-col-3">
            <Button label="Gerar" class="p-button-rounded" ></Button>
          </div>
        </div>
      </div>
    </div>
    <div class="p-col-12 p-jc-center" style="margin: 20px">
      <div class="p-grid p-fluid">
        <div class="p-col-7 cardconexao">
          <label>SQL</label>
          <div class="p-field p-col-10 p-md-12 campos" >
            <prism-editor id="sql" v-model="code" :highlight="highlighter" line-numbers></prism-editor>
          </div>
        </div>
      </div>
    </div>
    <div class="p-grid p-fluid">
      <div class="p-col-11 cardconexao">
        <label>Resultado</label>
        <div class="p-field p-col-11 p-md-12 campos" >
          <prism-editor id="sql" v-model="code" :highlight="highlighter" line-numbers></prism-editor>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Imput from 'primevue/inputtext'
import Dropdown from 'primevue/dropdown'
import Button from 'primevue/button'
import { PrismEditor } from 'vue-prism-editor'
import 'vue-prism-editor/dist/prismeditor.min.css'
import { highlight, languages } from 'prismjs/components/prism-core'
import 'prismjs/components/prism-clike'
import 'prismjs/components/prism-javascript'
import 'prismjs/themes/prism-tomorrow.css'

export default {
  data () {
    return {
      selectsgbd: null,
      numeroLinha: true,
      code: '',
      sgbd: [
        { name: 'Postgres', code: '1' },
        { name: 'SQL Server', code: '2' },
        { name: 'MySql', code: '3' },
        { name: 'Oracle', code: '4' },
        { name: 'Sqlite', code: '5' }
      ]
    }
  },
  methods: {
    highlighter (code) {
      return highlight(code, languages.js)// languages.<insert language> to return html with markup
    }
  },
  components: {
    Imput,
    Dropdown,
    Button,
    PrismEditor
  }
}
</script>
<style lang="scss" scoped>
.campos {
  margin-top: 10px
}
.cardconexao{
  margin-top: 30px;
  background-color: #1F2D40;
}
H1{
  margin-left: 30px;
}
H4{
  margin-left: 30px;
}
.prism-editor__textarea:focus {
  outline: none;
}
#sql {
    background: #2d2d2d;
    color: #ccc;
    height: 250px;

    font-family: Fira code, Fira Mono, Consolas, Menlo, Courier, monospace;
    font-size: 14px;
    line-height: 1.5;
    padding: 5px;
  }
</style>
