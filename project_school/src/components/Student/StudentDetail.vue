<!-- vbase -->
<template>
  <div>
    <Title :texto="`Student: ${student.name}`" :btnBack="!view">
      <button v-show="view" @click="loadEditMode()" class="btn btnEdit">
        Edit
      </button>
    </Title>

    <table>
      <tbody>
        <tr>
          <td class="colSmall">Code:</td>
          <td>
            <label>{{ student.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colSmall">Name:</td>
          <td>
            <label v-if="view">{{ student.name }}</label>
            <input v-else type="text" v-model="student.name" />
          </td>
        </tr>
        <tr>
          <td class="colSmall">Lastname:</td>
          <td>
            <label v-if="view">{{ student.lastname }}</label>
            <input v-else type="text" v-model="student.lastname" />
          </td>
        </tr>
        <tr>
          <td class="colSmall">Date of Birth:</td>
          <td>
            <label v-if="view">{{ student.dtBirth }}</label>
            <input v-else type="text" v-model="student.dtBirth" />
          </td>
        </tr>
        <tr>
          <td class="colSmall">Teacher:</td>
          <td>
            <label v-if="view">{{ student.teacher.name }}</label>
            <select v-else v-model="student.teacher">
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
        <button class="btn btnSave" @click="save(student)">Save</button>
        <button class="btn btnCancel" @click="cancel()">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script>
import Title from "../_shared/Title";

export default {
  components: {
    Title,
  },
  data() {
    return { student: {}, id: this.$route.params.id, teachers: [], view: true };
  },
  created() {
    this.$http
      .get("http://localhost:3000/students/" + this.id)
      .then((res) => res.json())
      .then((student) => (this.student = student));

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
        name: _student.name,
        lastname: _student.lastname,
        dtBirth: _student.dtBirth,
        teacher: _student.teacher,
      };

      this.$http.put(`http://localhost:3000/students/${_edition.id}`, _edition);
      this.view = !this.view;
    },
    cancel() {
      this.view = !this.view;
    },
  },
};
</script>

<style scoped>
.colSmall {
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
