<template>
  <div>
    <h1>Generate Code</h1>
    <h4>Gere seu código de maneira rápida e fácil</h4>
    <div class="carda" style="margin: 37px">
      <div class="row">
        <div class="col-sm-4 p-fluid">
          <div class="card carda">
            <div class="card-body">
              <div class="p-field p-md-12 campos" >
                <span class="p-float-label">
                  <Dropdown id="dropsgbd" v-model="form.server" :options="sgbd" optionLabel="name" />
                  <label for="dropsgbd">SGBD</label>
                </span>
              </div>
              <div class="p-field p-col-12 p-md-12">
                <span class="p-float-label">
                  <InputText id="banco" v-model="form.tableName" type="text"/>
                  <label for="banco">Nome do Tabela</label>
                </span>
              </div>
              <div class="p-field p-md-12 campos" >
                <span class="p-float-label">
                  <Dropdown id="dropsgbd" v-model="form.language" :options="language" optionLabel="name" />
                  <label for="dropsgbd">Linguagem</label>
                </span>
              </div>
            </div>
          </div>
        </div>
        <div class="col-sm-4 p-fluid">
          <div class="card carda">
            <div class="card-body">
              <div class="p-field p-md-12 campos" >
                <span class="p-float-label">
                  <InputText id="pack" v-model="form.package" />
                  <label for="pack">Package</label>
                </span>
              </div>
              <div class="p-field p-md-12 campos">
                <span class="p-float-label">
                  <InputText id="pack" v-model="form.className" />
                  <label for="pack">Classe</label>
                </span>
              </div>
              <div class="p-field p-md-12 campos" >
                <span class="p-float-label">
                  <InputText id="end" v-model="form.routeName" />
                  <label for="end">Route</label>
                </span>
              </div>
            </div>
          </div>
        </div>
        <div class="col-sm-4 p-fluid">
          <div class="card carda">
            <div class="card-body">
              <div class="row">
                <div class="col-sm-6">
                  <div class="p-field-radiobutton">
                    <RadioButton id="tipo1" name="city" v-model="form.tipo" value="1"/>
                    <label for="tipo1">Hibernate</label>
                  </div>
                  <div class="p-field-radiobutton">
                    <RadioButton id="tipo2" name="city" v-model="form.tipo" value="2"/>
                    <label for="tipo2">JDBC/SQLClient</label>
                  </div>
                  <div class="p-field-radiobutton">
                    <RadioButton id="tipo3" name="city" v-model="form.tipo" value="3"/>
                    <label for="tipo3">Pain-Crud</label>
                  </div>
                </div>
                <div class="col-sm-6">
                  <div class="p-field-checkbox">
                    <Checkbox id="model1" name="city"  v-model="form.model" value="1"/>
                    <label for="model1">Model</label>
                  </div>
                  <div class="p-field-checkbox">
                    <Checkbox id="model2" name="city" v-model="form.resource" value="1"/>
                    <label id="model2" for="city1">Resource</label>
                  </div>
                  <div class="p-field-checkbox">
                    <Checkbox id="model3" name="city" v-model="form.controller" value="1"/>
                    <label id="model3" for="city1">Controller</label>
                  </div>
                  <div class="p-field-checkbox">
                    <Checkbox id="model3" name="city" v-model="form.requerToken" value="1"/>
                    <label id="model3" for="city1">Requer Authorization</label>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row" style="margin: 20px">
      <div class="col-sm-12 p-fluid">
        <div class="card carda">
          <div class="card-body">
            <Editor v-model="form.code" editorStyle="height: 320px">
              <template #toolbar>
                <span class="ql-formats">
                  <label>SQL / JSON</label>
                </span>
              </template>
            </Editor>
            <div class="p-grid p-jc-end" style="margin-top: 10px;">
              <div class="p-col-1">
                <Button label="Gerar" @click="getCode(form)" class="p-button-rounded" ></Button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script src="./Code.js">
</script>
<style lang="scss" scoped>
.carda{
  background-color: #1F2D40;
}
.card {
  border: none;
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
.height-300 {
  height: 300px;
}
.my-editor {
  background: #2d2d2d;
  color: #ccc;

  font-family: Fira code, Fira Mono, Consolas, Menlo, Courier, monospace;
  font-size: 14px;
  line-height: 1.5;
  padding: 5px;
}
</style>
