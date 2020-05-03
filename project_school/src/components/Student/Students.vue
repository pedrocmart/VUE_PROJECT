<template>
  <div>
    <Title
      :texto="
        teacherId != undefined ? 'Teacher: ' + teacher.name : 'All Students'
      "
    />
    <div v-if="teacherId != undefined">
      <input
        type="text"
        placeholder="Student's Name"
        v-model="name"
        @keyup.enter="addStudent()"
      />
      <button class="btn btnInput" @click="addStudent()">Add</button>
    </div>

    <table>
      <thead v-if="students.length">
        <th>Code</th>
        <th>Name</th>
        <th>Delete</th>
      </thead>
      <tbody>
        <tr v-for="(student, index) in students" :key="index">
          <td class="colSmall">{{ student.id }}</td>
          <router-link
            tag="td"
            :to="`/studentDetail/${student.id}`"
            style="cursor: pointer"
          >
            {{ student.name }}
            {{ student.lastname }}
          </router-link>
          <td>
            <button class="btn btnDanger" @click="remove(student)">X</button>
          </td>
        </tr>
      </tbody>
      <!-- poderia ser com v-else, caso o if fosse na tag anterior a esta -->
      <tfoot v-if="!students.length">
        No Students were found!
      </tfoot>
    </table>
  </div>
</template>

<script>
import Title from "../_shared/Title";

export default {
  components: {
    Title,
  },
  data() {
    return {
      title: "Student",
      teacherId: this.$route.params.teacher_id,
      name: "",
      students: [],
      teacher: {},
    };
  },
  created() {
    if (this.teacherId) {
      this.$http
        .get("http://localhost:3000/students?teacher.id=" + this.teacherId)
        .then((res) => res.json())
        .then((students) => (this.students = students));
      this.loadTeachers();
    } else {
      this.$http
        .get("http://localhost:3000/students")
        .then((res) => res.json())
        .then((students) => (this.students = students));
    }
  },
  props: {},
  methods: {
    addStudent() {
      let _student = {
        name: this.name,
        lastname: "",
        teacher: {
          id: this.teacher.id,
          name: this.teacher.name,
        },
      };

      this.$http
        .post("http://localhost:3000/students", _student)
        .then((res) => res.json())
        .then((studentReturned) => {
          this.students.push(studentReturned);
          this.name = "";
        });
    },
    remove(student) {
      this.$http.delete(`http://localhost:3000/students/${student.id}`).then(() => {
        let indice = this.students.indexOf(student);
        this.students.splice(indice, 1);
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
