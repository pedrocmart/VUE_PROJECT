<template>
  <div>
    <Title texto="Teachers" />
    <table>
      <thead v-if="teachers.length">
        <th>Code</th>
        <th>Name</th>
        <th>Qty Students</th>
      </thead>
      <tbody>
        <tr v-for="(teacher, index) in teachers" :key="index">
          <td class="colPequeno">{{ teacher.id }}</td>

          <router-link v-bind:to="`/aluno/${teacher.id}`" tag="td" style="cursor: pointer">
            {{ teacher.name }} {{ teacher.lastname }}
          </router-link>
          <td>
            {{ teacher.qtyStudents }}
          </td>
        </tr>
      </tbody>
      <!-- poderia ser com v-else, caso o if fosse na tag anterior a esta -->
      <tfoot v-if="!teachers.length">
        Nenhum teacher Encontrado!
      </tfoot>
    </table>
  </div>
</template>

<script>
import Title from "../_shared/Titulo";

export default {
  components: {
    Title,
  },
  data() {
    return {
      teachers: [],
      Alunos: [],
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then((res) => res.json())
      .then((alunos) => {
        this.Alunos = alunos;
        this.loadTeachers();
      });
  },
  props: {},
  methods: {
    getQtyStudentsByTeacher() {
      this.teachers.forEach((teacher, index) => {
        teacher = {
          id: teacher.id,
          name: teacher.name,
          qtyStudents: this.Alunos.filter(
            (aluno) => aluno.teacher.id == teacher.id
          ).length,
        };
        this.teachers[index] = teacher;
      });
    },
    loadTeachers() {
      this.$http
        .get("http://localhost:3000/teachers")
        .then((res) => res.json())
        .then((teacher) => {
          this.teachers = teacher;
          this.getQtyStudentsByTeacher();
        });
    },
  },
};
</script>

<style lang="scss" scoped></style>
