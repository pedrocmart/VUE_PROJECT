<template>
  <div>
    <titulo
      :texto="
        teacherId != undefined ? 'Teacher: ' + teacher.name : 'All Students'
      "
    />
    <div v-if="teacherId != undefined">
      <input
        type="text"
        placeholder="Nome do Aluno"
        v-model="nome"
        @keyup.enter="addAluno()"
      />
      <button class="btn btnInput" @click="addAluno()">Add</button>
    </div>

    <table>
      <thead v-if="alunos.length">
        <th>Matricula</th>
        <th>Nome</th>
        <th>Opcoes</th>
      </thead>
      <tbody>
        <tr v-for="(aluno, index) in alunos" :key="index">
          <!-- <td>{{ aluno.id }}</td> -->
          <td class="colPequeno">{{ aluno.id }}</td>
          <router-link
            tag="td"
            :to="`/alunoDetalhe/${aluno.id}`"
            style="cursor: pointer"
          >
            {{ aluno.nome }}
            {{ aluno.sobrenome }}
          </router-link>
          <td>
            <button class="btn btnDanger" @click="remover(aluno)">X</button>
          </td>
        </tr>
      </tbody>
      <!-- poderia ser com v-else, caso o if fosse na tag anterior a esta -->
      <tfoot v-if="!alunos.length">
        Nenhum Aluno Encontrado!
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Aluno",
      teacherId: this.$route.params.teacher_id,
      nome: "",
      alunos: [],
      teacher: {},
    };
  },
  created() {
    if (this.teacherId) {
      this.$http
        .get("http://localhost:3000/alunos?teacher.id=" + this.teacherId)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
      this.loadTeachers();
    } else {
      this.$http
        .get("http://localhost:3000/alunos")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        teacher: {
          id: this.teacher.id,
          name: this.teacher.name,
        },
      };

      this.$http
        .post("http://localhost:3000/alunos", _aluno)
        .then((res) => res.json())
        .then((alunoRetornado) => {
          this.alunos.push(alunoRetornado);
          this.nome = "";
        });
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    loadTeachers() {
      this.$http
        .get("http://localhost:3000/teachers/" + this.teacherId)
        .then((res) => res.json())
        .then((teacher) => {
          this.teacher = teacher;
        });
    },
  },
};
</script>

<style scoped>
input {
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
}

.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: lightgreen;
  display: inline;
}
</style>
