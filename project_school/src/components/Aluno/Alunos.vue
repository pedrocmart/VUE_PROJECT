<template>
  <div>
    <titulo texto="Aluno" />
    <div>
      <input
        type="text"
        placeholder="Nome do Aluno"
        v-model="nome"
        @keyup.enter="addAluno()"
      />
      <button class="btn btnInput" @click="addAluno()">Adicionar</button>
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
          <td>{{ aluno.id }}</td>
          <td>{{ aluno.nome }} {{ aluno.sobrenome }}</td>
          <td>
            <button class="btn" @click="remover(aluno)">X</button>
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
      nome: "",
      alunos: [],
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then((res) => res.json())
      .then((alunos) => (this.alunos = alunos));
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
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
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: lightgreen;
  display: inline;
}
</style>
