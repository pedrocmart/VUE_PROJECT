<!-- vbase -->
<template>
  <div>
    <Titulo :texto="`Aluno: ${aluno.nome}`" :btnBack="!view">
      <button v-show="view" @click="loadEditMode()" class="btn btnEdit">
        Edit
      </button>
    </Titulo>

    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matricula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="view">{{ aluno.nome }}</label>
            <input v-else type="text" v-model="aluno.nome" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="view">{{ aluno.sobrenome }}</label>
            <input v-else type="text" v-model="aluno.sobrenome" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="view">{{ aluno.dtNasc }}</label>
            <input v-else type="text" v-model="aluno.dtNasc" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Teacher:</td>
          <td>
            <label v-if="view">{{ aluno.teacher.name }}</label>
            <select v-else v-model="aluno.teacher">
              <option
                v-for="teacher in teachers"
                :key="teacher.id"
                v-bind:value="teacher"
              >
                {{ teacher.name }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
    <div style="margin-top: 10px">
      <div v-if="!view">
        <button class="btn btnSave" @click="save(aluno)">Save</button>
        <button class="btn btnCancel" @click="cancel()">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return { aluno: {}, id: this.$route.params.id, teachers: [], view: true };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos/" + this.id)
      .then((res) => res.json())
      .then((aluno) => (this.aluno = aluno));

    this.$http
      .get("http://localhost:3000/teachers")
      .then((res) => res.json())
      .then((teacher) => {
        this.teachers = teacher;
      });
  },
  methods: {
    loadEditMode() {
      this.view = !this.view;
    },
    save(_student) {
      let _edition = {
        id: _student.id,
        nome: _student.nome,
        sobrenome: _student.sobrenome,
        dtNasc: _student.dtNasc,
        teacher: _student.teacher,
      };

      this.$http.put(`http://localhost:3000/alunos/${_edition.id}`, _edition);
      this.view = !this.view;
    },
    cancel() {
      this.view = !this.view;
    },
  },
};
</script>

<style scoped>
.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  width: 95%;
}

select {
  height: 38px;
  width: 50%;
}

.btnEdit {
  float: right;
  background-color: rgb(76, 186, 249);
}
.btnSave {
  float: right;
  background-color: rgb(79, 196, 68);
}
.btnCancel {
  float: left;
  background-color: rgb(249, 186, 92);
}
</style>
